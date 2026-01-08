using JGM.Gameplay.Base;
using UnityEngine;

namespace JGM.Gameplay.Creeps
{
    public class CreepSpawner : MonoBehaviour
    {
        [SerializeField] private Creep creepPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform target;
        [SerializeField] private PlayerBase playerBase;

        public void Spawn()
        {
            var spawnedCreep = Instantiate(creepPrefab, spawnPoints[1], false);
            var creepModel = new CreepModel(target, 5f, 5f, playerBase, 1f);
            spawnedCreep.Initialize(creepModel);
        }
    }
}
