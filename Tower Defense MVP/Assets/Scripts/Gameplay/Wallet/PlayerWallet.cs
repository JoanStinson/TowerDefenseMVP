using System;
using UnityEngine;

namespace JGM.Gameplay.Wallet
{
    public class PlayerWallet : MonoBehaviour
    {
        public event Action<int> OnWalletChange;
        public int Coins => coins;

        private int coins = 50;

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
