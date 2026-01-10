using JGM.Gameplay.Combat;
using System.Collections.Generic;
using UnityEngine;

namespace JGM.Gameplay.Turrets.Projectiles
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        public GameObject GameObject => gameObject;

        [SerializeField]
        private ProjectileConfig config;

        private Transform target;
        private List<ICombatEffect> effects = new();

        public void Initialize(Transform target)
        {
            this.target = target;

            foreach (var effectConfig in config.Effects)
            {
                effects.Add(effectConfig.CreateEffect());
            }
        }

        private void Update()
        {
            if (target != null)
            {
                MoveTowardsTarget();
            }
        }

        private void MoveTowardsTarget()
        {
            var speed = config.MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            foreach (var effect in effects)
            {
                effect.Apply(other.gameObject);
            }

            //Destroy(gameObject);
        }
    }
}
