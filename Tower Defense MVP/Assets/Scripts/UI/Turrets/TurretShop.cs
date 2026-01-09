using UnityEngine;

namespace JGM.UI.Turrets
{
    public class TurretShop : MonoBehaviour
    {
        [SerializeField] 
        private TurretCard turretButton;

        private void Awake()
        {
            turretButton.Initialize(this);
        }

        public void OnTurretDragEnd()
        {
            //TODO spawn turret
            Debug.LogError("WOW");
        }
    }
}
