using JGM.Gameplay.Creeps;
using UnityEngine;

namespace JGM.Gameplay.Turrets
{
    public class TurretSpawner : MonoBehaviour
    {
        [SerializeField]
        private CreepSpawner creepSpawner;

        private Transform turretsParent;

        public void Spawn(ITurret turret, Vector3 position)
        {
            turretsParent ??= new GameObject("Turrets").transform;
            var spawnedTurret = Instantiate(turret.GameObject, turretsParent, false);
            spawnedTurret.transform.position = position;
            spawnedTurret.GetComponent<ITurret>().Initialize(creepSpawner);
        }
    }
}
