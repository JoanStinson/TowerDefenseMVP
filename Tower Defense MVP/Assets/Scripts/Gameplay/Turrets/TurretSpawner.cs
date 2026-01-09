using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class TurretSpawner : MonoBehaviour
    {
        [SerializeField] private Turret turretPrefab;

        public void Spawn(Vector3 spawnPosition)
        {
            var spawnedTurret = Instantiate(turretPrefab, transform, false);
            spawnedTurret.transform.position = spawnPosition;
        }
    }
}
