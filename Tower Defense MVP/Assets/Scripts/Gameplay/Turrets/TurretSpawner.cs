using JGM.Gameplay.Creeps;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class TurretSpawner : MonoBehaviour
    {
        [SerializeField] private Turret turretPrefab;
        [SerializeField] private CreepSpawner creepSpawner;

        public void Spawn(Vector3 spawnPosition)
        {
            var spawnedTurret = Instantiate(turretPrefab, transform, false);
            spawnedTurret.transform.position = spawnPosition;
            spawnedTurret.Initialize(creepSpawner);
        }
    }
}
