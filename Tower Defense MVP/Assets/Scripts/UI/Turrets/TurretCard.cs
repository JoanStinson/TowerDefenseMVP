using UnityEngine;
using UnityEngine.EventSystems;

namespace JGM.UI.Turrets
{
    public class TurretCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private TurretShop turretShop;

        public void Initialize(TurretShop turretShop)
        {
            this.turretShop = turretShop;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Debug.Log("Dragging...");
            // Move the object to the pointer's position
            //transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            turretShop.OnTurretCardDropped(eventData.position);
        }
    }
}
