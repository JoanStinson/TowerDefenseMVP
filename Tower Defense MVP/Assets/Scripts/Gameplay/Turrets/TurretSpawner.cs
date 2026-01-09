using JGM.Gameplay.Creeps;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class TurretSpawner : MonoBehaviour
    {
        [SerializeField]
        private CreepSpawner creepSpawner;

        public void Spawn(ITurret turret, Vector3 position)
        {
            var spawnedTurret = Instantiate(turret.GameObject, transform, false);
            spawnedTurret.transform.position = position;
            spawnedTurret.GetComponent<ITurret>().Initialize(creepSpawner);
        }
    }
}
