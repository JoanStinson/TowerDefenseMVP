using JGM.Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.UI.Base
{
    public class PlayerBaseHealthBar : MonoBehaviour
    {
        [SerializeField] private PlayerBase playerBase;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            slider.maxValue = playerBase.MaxHealth;
            slider.value = playerBase.MaxHealth;
        }

        private void OnEnable()
        {
            playerBase.OnTakeDamage += OnHealthChange;
        }
        
        private void OnDisable()
        {
            playerBase.OnTakeDamage -= OnHealthChange;
        }

        private void OnHealthChange(int health)
        {
            slider.value = health;
        }
    }
}
