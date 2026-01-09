using JGM.Gameplay.Creeps;
using System;
using UnityEngine;

namespace JGM.Gameplay.Waves
{
    public class WavesController : MonoBehaviour
    {
        public event Action<int> OnWaveComplete;
        public event Action OnAllWavesComplete;
        public int WavesCount => waveList.Waves.Length;

        [SerializeField] private WaveList waveList;
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
            currentWave = waveList.Waves[currentWaveIndex];
            creepSpawner.Spawn(currentWave);
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
            return currentWaveIndex > waveList.Waves.Length - 1;
        }

        private void StartNextWave()
        {
            currentWave = waveList.Waves[currentWaveIndex];
            creepSpawner.Spawn(currentWave);
            OnWaveComplete?.Invoke(currentWaveIndex);
        }
    }
}
