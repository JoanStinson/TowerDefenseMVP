using JGM.Gameplay.Base;
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
        private Transform creepsParent;

        public void Spawn(IReadOnlyList<ICreep> creeps, float delayBetweenCreeps)
        {
            creepsParent ??= new GameObject("Creeps").transform;
            StartCoroutine(SpawnCreeps(creeps, delayBetweenCreeps));
        }

        private IEnumerator SpawnCreeps(IReadOnlyList<ICreep> creeps, float delayBetweenCreeps)
        {
            foreach (var creep in creeps)
            {
                var spawnedCreep = Instantiate(creep.GameObject, creepsParent, false);
                int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                spawnedCreep.transform.position = spawnPoints[randomSpawnPoint].position;

                var activeCreep = spawnedCreep.GetComponent<ICreep>();
                activeCreep.Initialize(this, playerBase);
                activeCreeps.Add(activeCreep);
                yield return new WaitForSeconds(delayBetweenCreeps);
            }
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
