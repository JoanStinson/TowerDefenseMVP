using JGM.Gameplay.Turrets;
using JGM.Gameplay.Wallet;
using UnityEngine;

namespace JGM.UI.Turrets
{
    public class TurretShop : MonoBehaviour
    {
        [Header("Turret Cards")]
        [SerializeField] private TurretList turretList;
        [SerializeField] private TurretCard turretCardPrefab;
        [SerializeField] private Transform turretCardsParent;

        [Header("Other")]
        [SerializeField] private TurretSpawner turretSpawner;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PlayerWallet playerWallet;

        private void Start()
        {
            SpawnTurretCards();
        }

        private void SpawnTurretCards()
        {
            foreach (var turret in turretList.Turrets)
            {
                var spawnedTurretCard = Instantiate(turretCardPrefab, turretCardsParent, false);
                var turretCardModel = new TurretCardModel(turret.Key, turret.Value.Price, turret.Value.CardColor);
                spawnedTurretCard.Initialize(turretCardModel, this);
                spawnedTurretCard.RefreshCardIsAvailable(playerWallet.Coins);
                playerWallet.OnWalletChange += spawnedTurretCard.RefreshCardIsAvailable;
            }
        }

        public void OnTurretCardDropped(TurretCardModel model, Vector2 position)
        {
            var ray = mainCamera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            {
                var turret = turretList.GetTurretById(model.Id);
                turretSpawner.Spawn(turret, hit.point);
                playerWallet.RemoveCoins(model.Price);
            }
            else
            {
                Debug.LogWarning("Invalid turret placement");
            }
        }
    }
}
