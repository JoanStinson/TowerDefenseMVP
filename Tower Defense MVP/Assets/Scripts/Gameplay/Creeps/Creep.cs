using JGM.Gameplay.Base;
using JGM.Gameplay.Combat;
using System;
using System.Collections;
using UnityEngine;

namespace JGM.Gameplay.Creeps
{
    public class Creep : MonoBehaviour, IDamageable
    {
        public event Action<int> OnTakeDamage;
        public int MaxHealth { get; private set; }
        public int CoinReward { get; private set; }

        [SerializeField]
        private CreepConfig config;

        private CreepSpawner creepSpawner;
        private PlayerBase playerBase;
        private int health;
        private bool initialized;
        private bool isAttacking;

        public void Initialize(CreepSpawner creepSpawner, PlayerBase playerBase)
        {
            this.creepSpawner = creepSpawner;
            this.playerBase = playerBase;
            health = config.Health;
            MaxHealth = config.Health;
            CoinReward = config.CoinReward;
            transform.LookAt(playerBase.transform.position);
            initialized = true;
        }

        private void Update()
        {
            if (!initialized)
            {
                return;
            }

            if (!ReachedPlayerBase())
            {
                MoveTowardsPlayerBase();
            }
            else
            {
                AttackPlayerBase();
            }
        }

        private bool ReachedPlayerBase()
        {
            return Vector3.Distance(transform.position, playerBase.transform.position) <= config.StopDistance;
        }

        private void MoveTowardsPlayerBase()
        {
            var speed = config.MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerBase.transform.position, speed);
        }

        private void AttackPlayerBase()
        {
            if (!isAttacking)
            {
                StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            isAttacking = true;

            while (playerBase.CurrentHealth > 0)
            {
                playerBase.TakeDamage(config.AttackDamage);
                yield return new WaitForSeconds(config.AttackSpeed);
            }

            isAttacking = false;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            OnTakeDamage?.Invoke(health);

            if (health <= 0)
            {
                creepSpawner.KillCreep(this);
            }
        }
    }
}
