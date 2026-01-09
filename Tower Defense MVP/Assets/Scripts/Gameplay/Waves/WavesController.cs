using JGM.Gameplay.Creeps;
using System;
using UnityEngine;

namespace JGM.Gameplay.Waves
{
    public class WavesController : MonoBehaviour
    {
        public event Action<int> OnWaveComplete;
        public event Action OnAllWavesComplete;
        public int WavesCount => wavesList.Waves.Length;

        [SerializeField] private WavesList wavesList;
        [SerializeField] private CreepSpawner creepSpawner;

        private Wave currentWave;
        private int currentWaveIndex;

        public void StartGame()
        {
            StartFirstWave();
            creepSpawner.OnAllCreepsKilled += OnWaveCleared;
        }

        private void StartFirstWave()
        {
            currentWaveIndex = 0;
            currentWave = wavesList.Waves[currentWaveIndex];
            creepSpawner.Spawn(currentWave.CreepsCount);
        }

        private void OnWaveCleared()
        {
            currentWaveIndex++;

            if (LastWaveCleared())
            {
                OnAllWavesComplete?.Invoke();
            }
            else
            {
                StartNextWave();
            }
        }

        private bool LastWaveCleared()
        {
            return currentWaveIndex > wavesList.Waves.Length - 1;
        }

        private void StartNextWave()
        {
            currentWave = wavesList.Waves[currentWaveIndex];
            creepSpawner.Spawn(currentWave.CreepsCount);
            OnWaveComplete?.Invoke(currentWaveIndex);
        }
    }
}
