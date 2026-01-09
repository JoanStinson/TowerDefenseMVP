using JGM.Gameplay.Creeps;
using System;
using UnityEngine;

namespace JGM.Gameplay.Wallet
{
    public class PlayerWallet : MonoBehaviour
    {
        public event Action<int> OnWalletChange;
        public int Coins => coins;

        [SerializeField]
        private CreepSpawner creepSpawner;

        private int coins = 50;

        private void Awake()
        {
            creepSpawner.OnCreepKill += OnCreepKill;
        }

        private void OnCreepKill(Creep creep)
        {
            AddCoins(creep.CoinReward);
        }

        public void AddCoins(int amount)
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
