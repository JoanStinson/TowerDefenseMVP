using JGM.Gameplay.Combat;
using UnityEngine;

namespace JGM.Gameplay.Turrets.Projectiles
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        public GameObject GameObject => gameObject;

        [SerializeField]
        private ProjectileConfig config;

        private Transform target;

        public void Initialize(Transform target)
        {
            this.target = target;
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
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(config.DamageAmount);
                Destroy(gameObject);
            }
        }
    }
}
