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
        private bool canDrag;

        public void Initialize(TurretShop turretShop, PlayerWallet playerWallet)
        {
            this.turretShop = turretShop;
            this.playerWallet = playerWallet;
            playerWallet.OnWalletChange += UpdateCanDrag;
            UpdateCanDrag(playerWallet.Coins);
        }

        private void UpdateCanDrag(int coins)
        {
            canDrag = (coins >= price);
            canvasGroup.alpha = canDrag ? 1f : 0.5f;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!canDrag)
            {
                return;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canDrag)
            {
                return;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!canDrag)
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
