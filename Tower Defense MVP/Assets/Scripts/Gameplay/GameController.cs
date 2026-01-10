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

        private PlayerWallet playerWallet;
        private WavesController wavesController;

        private void Start()
        {
            var serviceLocator = ServiceLocator.Instance;
            playerWallet = serviceLocator.Get<PlayerWallet>();
            wavesController = serviceLocator.Get<WavesController>();
            var creepSpawner = serviceLocator.Get<CreepSpawner>();
            creepSpawner.OnCreepKill += OnCreepKill;
            StartGame();
        }

        private void OnCreepKill(ICreep creep)
        {
            playerWallet.AddCoins(creep.CoinReward);
        }

        private void StartGame()
        {
            wavesController.StartGame();
            OnGameStart?.Invoke();
        }
    }
}
