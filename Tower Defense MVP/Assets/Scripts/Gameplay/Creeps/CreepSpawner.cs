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
        public event Action<ICreep> OnCreepKill;
        public event Action OnAllCreepsKilled;

        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private PlayerBase playerBase;

        private List<ICreep> activeCreeps = new();

        public void Spawn(Wave wave)
        {
            StartCoroutine(SpawnCreeps(wave));
        }

        private IEnumerator SpawnCreeps(Wave wave)
        {
            foreach (var creep in GetCreepsToSpawn(wave))
            {
                var spawnedCreep = Instantiate(creep.GameObject, transform, false);
                int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                spawnedCreep.transform.position = spawnPoints[randomSpawnPoint].position;

                var activeCreep = spawnedCreep.GetComponent<ICreep>();
                activeCreep.Initialize(this, playerBase);
                activeCreeps.Add(activeCreep);
                yield return new WaitForSeconds(wave.DelayBetweenCreeps);
            }
        }

        private IEnumerable<ICreep> GetCreepsToSpawn(Wave wave)
        {
            int totalCreeps = 0;
            foreach (var creep in wave.Creeps)
            {
                totalCreeps += creep.CreepsCount;
            }

            var creepsToSpawn = new List<ICreep>(totalCreeps); // pre-allocate for performance

            foreach (var creep in wave.Creeps)
            {
                for (int i = 0; i < creep.CreepsCount; i++)
                {
                    creepsToSpawn.Add(creep.CreepPrefab.Value);
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

        public IEnumerable<ICreep> GetActiveCreeps()
        {
            foreach (var creep in activeCreeps)
            {
                yield return creep;
            }
        }
    }
}
