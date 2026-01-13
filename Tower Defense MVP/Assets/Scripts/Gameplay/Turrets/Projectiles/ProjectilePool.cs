using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace JGM.Gameplay.Turrets.Projectiles
{
    public class ProjectilePool
    {
        private Dictionary<GameObject, ObjectPool<IProjectile>> pools = new();

        private Transform rootParent;
        private List<Transform> poolParents = new();

        public ProjectilePool(ProjectilePoolConfig config)
        {
            rootParent = new GameObject("ProjectilePools").transform;

            foreach (var prefab in config.Configs)
            {
                CreatePool(prefab);
            }
        }

        private void CreatePool(ProjectilePoolConfig.BasicPoolConfig prefab)
        {
            var poolParent = new GameObject($"{prefab.ProjectilePrefab.name}Pool").transform;
            poolParent.SetParent(rootParent, false);
            poolParents.Add(poolParent);

            ObjectPool<IProjectile> pool = null;
            pool = new ObjectPool<IProjectile>
            (
                () => OnCreate(prefab, poolParent, pool), OnGet, OnRelease, OnDestroy, Debug.isDebugBuild, prefab.PoolCount
            );
            pools.Add(prefab.ProjectilePrefab, pool);
        }

        private IProjectile OnCreate(ProjectilePoolConfig.BasicPoolConfig poolConfig, Transform poolParent, ObjectPool<IProjectile> pool)
        {
            var projectile = GameObject.Instantiate(poolConfig.ProjectilePrefab, poolParent, false);
            if (projectile.TryGetComponent<IProjectile>(out var projectileComponent))
            {
                projectileComponent.SetPool(pool);
                return projectileComponent;
            }

            Debug.LogError($"Prefab {poolConfig.ProjectilePrefab.name} doesn't have a IProjectile script attached to it");
            return null;
        }

        private void OnGet(IProjectile projectile)
        {
            projectile.GameObject.SetActive(true);
        }

        private void OnRelease(IProjectile projectile)
        {
            projectile.GameObject.SetActive(false);
        }

        private void OnDestroy(IProjectile projectile)
        {
            GameObject.Destroy(projectile.GameObject);
        }

        public IProjectile Get(GameObject projectile)
        {
            if (pools.TryGetValue(projectile, out var projectilePool))
            {
                return projectilePool.Get();
            }

            Debug.LogWarning($"No available pool item for prefab {projectile.name}");
            return null;
        }
    }
}
