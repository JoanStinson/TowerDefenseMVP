using JGM.Gameplay.Turrets;
using JGM.Gameplay.Wallet;
using UnityEngine;

namespace JGM.UI.Turrets
{
    public class TurretShop : MonoBehaviour
    {
        [SerializeField] private TurretCard[] turretButtons;
        [SerializeField] private TurretSpawner turretSpawner;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PlayerWallet playerWallet;

        private void Start()
        {
            foreach (var button in turretButtons)
            {
                button.Initialize(this, playerWallet);
            }
        }

        public bool OnTurretCardDropped(Vector2 position)
        {
            var ray = mainCamera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            {
                turretSpawner.Spawn(hit.point);
                return true;
            }
            
            Debug.LogWarning("Invalid turret placement");
            return false;
        }
    }
}
