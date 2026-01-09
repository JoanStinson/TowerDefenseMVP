using System;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class Projectile : MonoBehaviour
    {
        private Transform target;
        private float speed = 7f;
        private int damageAmount = 1;

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        private void Update()
        {
            if (target == null)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }
    }
}
