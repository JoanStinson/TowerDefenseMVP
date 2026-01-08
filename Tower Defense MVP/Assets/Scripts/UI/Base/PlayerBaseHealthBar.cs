using JGM.Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.UI.Base
{
    public class PlayerBaseHealthBar : MonoBehaviour
    {
        [SerializeField] private PlayerBase playerBase;
        [SerializeField] private Slider slider;

        private void OnEnable()
        {
            playerBase.OnHealthDecreased += OnHealthDecreased;
        }
        
        private void OnDisable()
        {
            playerBase.OnHealthDecreased -= OnHealthDecreased;
        }

        private void OnHealthDecreased(int health)
        {
            slider.value = health;
        }
    }
}
