using JGM.Gameplay.Creeps;
using System;
using UnityEngine;

namespace JGM.Gameplay.Wallet
{
    public class PlayerWallet : MonoBehaviour
    {
        public event Action<int> OnWalletChange;

        [SerializeField]
        private CreepSpawner creepSpawner;

        private int coins = 50;

        public int Coins => coins;

        private void Awake()
        {
            creepSpawner.OnCreepKilled += OnCreepKilled;
        }

        private void OnCreepKilled()
        {
            AddCoins(1);
        }

        private void AddCoins(int amount)
        {
            coins += amount;
            OnWalletChange?.Invoke(coins);
        }

        public void RemoveCoins(int amount)
        {
            coins -= amount;
            OnWalletChange?.Invoke(coins);
        }
    }
}
