using JGM.Gameplay.Turrets;
using UnityEngine;

namespace JGM.UI.Turrets
{
    public class TurretShop : MonoBehaviour
    {
        [SerializeField] private TurretCard turretButton;
        [SerializeField] private TurretSpawner turretSpawner;
        [SerializeField] private Camera mainCamera;

        private void Awake()
        {
            turretButton.Initialize(this);
        }

        public void OnTurretCardDropped(Vector2 position)
        {
            var ray = mainCamera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            {
                turretSpawner.Spawn(hit.point);
            }
            else
            {
                Debug.LogWarning("Invalid turret placement");
            }
        }
    }
}
