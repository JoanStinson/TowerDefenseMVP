using JGM.Gameplay.Creeps;
using JGM.Gameplay.Wallet;
using JGM.Gameplay.Waves;
using System;
using UnityEngine;

namespace JGM.Gameplay
{
    public class GameController : MonoBehaviour
    {
        public event Action OnGameStart;

        [SerializeField] private WavesController wavesController;
        [SerializeField] private CreepSpawner creepSpawner;
        [SerializeField] private PlayerWallet playerWallet;

        private void Awake()
        {
            creepSpawner.OnCreepKill += OnCreepKill;
        }

        private void OnCreepKill(ICreep creep)
        {
            playerWallet.AddCoins(creep.CoinReward);
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            wavesController.StartGame();
            OnGameStart?.Invoke();
        }
    }
}
