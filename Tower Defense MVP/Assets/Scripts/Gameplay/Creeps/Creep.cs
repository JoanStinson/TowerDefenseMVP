using JGM.Gameplay.Base;
using System;
using System.Collections;
using UnityEngine;

namespace JGM.Gameplay.Creeps
{
    public class Creep : MonoBehaviour, IDamageable
    {
        private Transform target;
        private float speed;
        private float stopDistance;
        private PlayerBase playerBase;
        private float hitDelay;
        private CreepSpawner creepSpawner;
        private bool initialized;
        private bool isAttacking;
        private int health = 3;
        public int MaxHealth { get; } = 3;
        public event Action<int> OnHealthDecreased;

        public void Initialize(CreepModel model, CreepSpawner creepSpawner)
        {
            target = model.Target;
            speed = model.Speed;
            stopDistance = model.StopDistance;
            playerBase = model.PlayerBase;
            hitDelay = model.HitDelay;
            this.creepSpawner = creepSpawner;
            transform.LookAt(target.position);
            initialized = true;
        }

        private void Update()
        {
            if (!initialized)
            {
                return;
            }

            if (!ReachedTarget())
            {
                MoveToTarget();
            }
            else
            {
                HitTarget();
            }
        }

        private bool ReachedTarget()
        {
            return Vector3.Distance(transform.position, target.position) <= stopDistance;
        }

        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        private void HitTarget()
        {
            if (!isAttacking)
            {
                StartCoroutine(DecreaseTargetHealth());
            }
        }

        private IEnumerator DecreaseTargetHealth()
        {
            isAttacking = true;

            while (playerBase.CurrentHealth > 0)
            {
                playerBase.DecreaseHealth();
                yield return new WaitForSeconds(hitDelay);
            }

            isAttacking = false;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            OnHealthDecreased?.Invoke(health);

            if (health <= 0)
            {
                creepSpawner.RemoveActiveCreep(this);
                Destroy(gameObject);
            }
        }
    }
}
