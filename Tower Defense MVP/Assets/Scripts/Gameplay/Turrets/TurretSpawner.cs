using JGM.Gameplay.Creeps;
using JGM.Gameplay.Turrets.Projectiles;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class TurretSpawner
    {
        private CreepSpawner creepSpawner;
        private ProjectilePool projectilePool;
        private Transform turretsParent;

        public TurretSpawner(CreepSpawner creepSpawner, ProjectilePool projectilePool)
        {
            this.creepSpawner = creepSpawner;
            this.projectilePool = projectilePool;
        }

        public void Spawn(ITurret turret, Vector3 position)
        {
            turretsParent ??= new GameObject("Turrets").transform;
            var spawnedTurret = GameObject.Instantiate(turret.GameObject, turretsParent, false);
            spawnedTurret.transform.position = position;
            spawnedTurret.GetComponent<ITurret>().Initialize(creepSpawner, projectilePool);
        }
    }
}
