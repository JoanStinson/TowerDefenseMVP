using JGM.Gameplay.Wallet;
using UnityEngine;
using UnityEngine.EventSystems;

namespace JGM.UI.Turrets
{
    public class TurretCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private int price = 5;

        private TurretShop turretShop;
        private PlayerWallet playerWallet;
        private bool canBuy;

        public void Initialize(TurretShop turretShop, PlayerWallet playerWallet)
        {
            this.turretShop = turretShop;
            this.playerWallet = playerWallet;
            playerWallet.OnWalletChange += CheckCanPlayerBuyCard;
            CheckCanPlayerBuyCard(playerWallet.Coins);
        }

        private void CheckCanPlayerBuyCard(int coins)
        {
            canBuy = (coins >= price);
            canvasGroup.alpha = canBuy ? 1f : 0.5f;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!canBuy)
            {
                return;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canBuy)
            {
                return;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!canBuy)
            {
                return;
            }

            bool dropped = turretShop.OnTurretCardDropped(eventData.position);
            if (dropped)
            {
                playerWallet.RemoveCoins(price);
            }
        }
    }
}
