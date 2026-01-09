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
        public event Action<Creep> OnCreepKill;
        public event Action OnAllCreepsKilled;

        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform target;
        [SerializeField] private PlayerBase playerBase;

        public List<Creep> activeCreeps = new();

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
                spawnedCreep.Initialize(this, playerBase);
                activeCreeps.Add(spawnedCreep);
                yield return new WaitForSeconds(wave.DelayBetweenCreeps);
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

        public void KillCreep(Creep creep)
        {
            activeCreeps.Remove(creep);
            Destroy(creep.gameObject);
            OnCreepKill?.Invoke(creep);

            if (activeCreeps.Count == 0)
            {
                OnAllCreepsKilled?.Invoke();
            }
        }
    }
}
