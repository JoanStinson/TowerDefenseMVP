using System;

namespace JGM.Gameplay.Wallet
{
    public class PlayerWallet
    {
        public event Action<int> OnWalletChange;
        public int Coins => coins;

        private int coins;
        private readonly int startingCoins;

        public PlayerWallet(int coins)
        {
            this.coins = coins;
            startingCoins = coins;
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

        public void Restart()
        {
            coins = startingCoins;
            OnWalletChange?.Invoke(coins);
        }
    }
}
