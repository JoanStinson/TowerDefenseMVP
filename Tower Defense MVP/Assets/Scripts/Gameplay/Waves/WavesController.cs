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

        private int currentWaveIndex;

        public void StartGame()
        {
            StartFirstWave();
            creepSpawner.OnAllCreepsKilled += OnWaveCleared;
        }

        private void StartFirstWave()
        {
            currentWaveIndex = 0;
            creepSpawner.Spawn(waveList.Waves[0]);
        }

        private void OnWaveCleared()
        {
            if (ClearedLastWave())
            {
                OnAllWavesComplete?.Invoke();
            }
            else
            {
                StartNextWave();
            }
        }

        private bool ClearedLastWave()
        {
            return currentWaveIndex + 1 > waveList.Waves.Length - 1;
        }

        private void StartNextWave()
        {
            currentWaveIndex++;
            creepSpawner.Spawn(waveList.Waves[currentWaveIndex]);
            OnWaveComplete?.Invoke(currentWaveIndex);
        }
    }
}
