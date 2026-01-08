using JGM.Gameplay.Creeps;
using System;
using UnityEngine;

namespace JGM.Gameplay
{
    public class GameController : MonoBehaviour
    {
        public event Action OnGameStarted;

        [SerializeField]
        private CreepSpawner creepSpawner;

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            creepSpawner.Spawn();
            OnGameStarted?.Invoke();
        }
    }
}
