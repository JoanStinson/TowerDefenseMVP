using JGM.Gameplay.Wallet;
using TMPro;
using UnityEngine;

namespace JGM.UI.Wallet
{
    public class PlayerWalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsAmountText;
        [SerializeField] private PlayerWallet playerWallet;

        private void Start()
        {
            coinsAmountText.text = playerWallet.Coins.ToString("000");
        }

        private void OnEnable()
        {
            playerWallet.OnWalletChange += OnAddedCoins;
        }

        private void OnDisable()
        {
            playerWallet.OnWalletChange -= OnAddedCoins;
        }

        private void OnAddedCoins(int coins)
        {
            coinsAmountText.text = coins.ToString("000");
        }
    }
}
