using JGM.Gameplay.Creeps;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JGM.Gameplay.Waves
{
    public class WavesController : MonoBehaviour
    {
        public event Action<int> OnWaveStart;
        public event Action OnAllWavesComplete;
        public int WavesCount => waveList.Waves.Length;

        [SerializeField] private WaveList waveList;
        [SerializeField] private CreepSpawner creepSpawner;

        private Wave currentWave;
        private int currentWaveIndex;

        public void StartGame()
        {
            currentWaveIndex = 0;
            currentWave = waveList.Waves[currentWaveIndex];
            StartCoroutine(StartWave());
            creepSpawner.OnAllCreepsKilled += OnWaveCleared;
        }

        private IEnumerator StartWave()
        {
            OnWaveStart?.Invoke(currentWaveIndex);
            yield return new WaitForSeconds(currentWave.StartWaveDelay);
            creepSpawner.Spawn(GetCreepsToSpawn(), currentWave.DelayBetweenCreeps);
        }

        private IReadOnlyList<ICreep> GetCreepsToSpawn()
        {
            int totalCreeps = 0;
            foreach (var creep in currentWave.Creeps)
            {
                totalCreeps += creep.CreepsCount;
            }

            var creepsToSpawn = new List<ICreep>(totalCreeps); // pre-allocate for performance

            foreach (var creep in currentWave.Creeps)
            {
                for (int i = 0; i < creep.CreepsCount; i++)
                {
                    creepsToSpawn.Add(creep.CreepPrefab.Value);
                }
            }

            creepsToSpawn.Shuffle();
            return creepsToSpawn;
        }

        private void OnWaveCleared()
        {
            if (ClearedLastWave())
            {
                OnAllWavesComplete?.Invoke();
            }
            else
            {
                currentWaveIndex++;
                currentWave = waveList.Waves[currentWaveIndex];
                StartCoroutine(StartWave());
            }
        }

        private bool ClearedLastWave()
        {
            return currentWaveIndex >= waveList.Waves.Length - 1;
        }
    }
}
