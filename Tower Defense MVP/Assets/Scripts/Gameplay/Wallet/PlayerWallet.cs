using System;

namespace JGM.Gameplay.Wallet
{
    public class PlayerWallet
    {
        public event Action<int> OnWalletChange;
        public int Coins { get; private set; }

        public PlayerWallet(int coins)
        {
            Coins = coins;
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
            OnWalletChange?.Invoke(Coins);
        }

        public void RemoveCoins(int amount)
        {
            Coins -= amount;
            OnWalletChange?.Invoke(Coins);
        }
    }
}
