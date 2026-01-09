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
        private bool playerCanBuyCard;

        public void Initialize(TurretShop turretShop, PlayerWallet playerWallet)
        {
            this.turretShop = turretShop;
            this.playerWallet = playerWallet;
            playerWallet.OnWalletChange += CheckCanPlayerBuyCard;
            CheckCanPlayerBuyCard(playerWallet.Coins);
        }

        private void CheckCanPlayerBuyCard(int coins)
        {
            playerCanBuyCard = (coins >= price);
            canvasGroup.alpha = playerCanBuyCard ? 1f : 0.5f;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!playerCanBuyCard)
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
