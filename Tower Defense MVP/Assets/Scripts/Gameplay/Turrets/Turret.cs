using JGM.Gameplay.Creeps;
using JGM.Gameplay.Turrets.Projectiles;
using System.Collections;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class Turret : MonoBehaviour, ITurret
    {
        public GameObject GameObject => gameObject;

        [SerializeField]
        private TurretConfig config;

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
                yield return new WaitForSeconds(config.ShootSpeed);
                var closestTarget = GetClosestTarget();
                SpawnProjectile(closestTarget);
            }
        }

        private Transform GetClosestTarget()
        {
            Transform closestTarget = null;
            float closestSqrDistance = float.MaxValue;
            Vector3 myPos = transform.position;

            foreach (var target in creepSpawner.GetActiveCreeps())
            {
                Vector3 targetPos = target.GameObject.transform.position;
                float sqrDistance = (targetPos - myPos).sqrMagnitude;

                if (sqrDistance < closestSqrDistance)
                {
                    closestSqrDistance = sqrDistance;
                    closestTarget = target.GameObject.transform;
                }
            }

            return closestTarget;
        }

        private void SpawnProjectile(Transform target)
        {
            if (target != null)
            {
                var spawnedProjectile = Instantiate(config.ProjectilePrefab.Value.GameObject, null, false);
                spawnedProjectile.transform.position = transform.position;
                spawnedProjectile.GetComponent<IProjectile>().Initialize(target);
            }
        }
    }
}
