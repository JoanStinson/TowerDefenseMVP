using JGM.Gameplay.Base;
using JGM.Gameplay.Waves;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JGM.Gameplay.Creeps
{
    public class CreepSpawner : MonoBehaviour
    {
        public event Action OnCreepKilled;

        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform target;
        [SerializeField] private PlayerBase playerBase;

        public List<Creep> activeCreeps = new();

        private int delayBetweenCreeps = 2;

        public event Action OnAllCreepsKilled;

        public void Spawn(Wave wave)
        {
            StartCoroutine(SpawnCreeps(wave));
        }

        private IEnumerator SpawnCreeps(Wave wave)
        {
            foreach (var creep in GetCreepsToSpawn(wave))
            {
                var spawnedCreep = Instantiate(creep, transform, false);
                int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                spawnedCreep.transform.position = spawnPoints[randomSpawnPoint].position;
                var creepModel = new CreepModel(target, 5f, 5f, playerBase, 1f);
                spawnedCreep.Initialize(creepModel, this);
                activeCreeps.Add(spawnedCreep);
                yield return new WaitForSeconds(delayBetweenCreeps);
            }
        }

        private IEnumerable<Creep> GetCreepsToSpawn(Wave wave)
        {
            int totalCreeps = 0;
            foreach (var creep in wave.Creeps)
            {
                totalCreeps += creep.CreepsCount;
            }

            var creepsToSpawn = new List<Creep>(totalCreeps); // pre-allocate for performance

            foreach (var creep in wave.Creeps)
            {
                for (int i = 0; i < creep.CreepsCount; i++)
                {
                    creepsToSpawn.Add(creep.CreepPrefab);
                }
            }

            creepsToSpawn.Shuffle();
            return creepsToSpawn;
        }

        public void RemoveActiveCreep(Creep creep)
        {
            activeCreeps.Remove(creep);
            OnCreepKilled?.Invoke();

            if (activeCreeps.Count == 0)
            {
                OnAllCreepsKilled?.Invoke();
            }
        }
    }
}
