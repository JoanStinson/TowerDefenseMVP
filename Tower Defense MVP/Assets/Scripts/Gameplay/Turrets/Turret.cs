using JGM.Gameplay.Creeps;
using System.Collections;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private Projectile projectilePrefab;

        private CreepSpawner creepSpawner;
        private bool turnedOn;

        public void Initialize(CreepSpawner creepSpawner)
        {
            this.creepSpawner = creepSpawner;
            turnedOn = true;
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            while (turnedOn)
            {
                yield return new WaitForSeconds(2);
                var closestTarget = GetClosestTarget();
                SpawnProjectile(closestTarget);
            }
        }

        private Transform GetClosestTarget()
        {
            Transform closestTarget = null;

            foreach (var target in creepSpawner.GetActiveCreeps())
            {
                if (closestTarget == null)
                {
                    closestTarget = target.GameObject.transform;
                    continue;
                }

                var distanceToNewTarget = Vector3.Distance(transform.position, target.GameObject.transform.position);
                var distanceToCurrentTarget = Vector3.Distance(transform.position, closestTarget.position);

                if (distanceToNewTarget < distanceToCurrentTarget)
                {
                    closestTarget = target.GameObject.transform;
                }
            }

            return closestTarget;
        }

        private void SpawnProjectile(Transform target)
        {
            if (target != null)
            {
                var spawnedProjectile = Instantiate(projectilePrefab, null, false);
                spawnedProjectile.transform.position = transform.position;
                spawnedProjectile.SetTarget(target);
            }
        }
    }
}
