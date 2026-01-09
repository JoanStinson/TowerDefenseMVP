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
        public event Action OnCreepKilled;

        [SerializeField] private Creep creepPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Transform target;
        [SerializeField] private PlayerBase playerBase;

        public List<Creep> activeCreeps = new();

        private int delayBetweenCreeps = 2;

        public event Action OnAllCreepsKilled;

        public void Spawn(int creepsCount)
        {
            StartCoroutine(SpawnCreeps(creepsCount));
        }

        private IEnumerator SpawnCreeps(int creepsCount)
        {
            for (int i = 0; i < creepsCount; i++)
            {
                var spawnedCreep = Instantiate(creepPrefab, transform, false);
                int randomSpawnPoint = Random.Range(0, spawnPoints.Length - 1);
                spawnedCreep.transform.position = spawnPoints[randomSpawnPoint].position;
                var creepModel = new CreepModel(target, 5f, 5f, playerBase, 1f);
                spawnedCreep.Initialize(creepModel, this);
                activeCreeps.Add(spawnedCreep);
                yield return new WaitForSeconds(delayBetweenCreeps);
            }
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
