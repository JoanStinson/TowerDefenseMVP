using JGM.Gameplay.Base;
using JGM.UI.HealthBar;
using UnityEngine;

namespace JGM.UI.Base
{
    public class PlayerBaseHealthBar : HealthBarBase
    {
        [SerializeField]
        private PlayerBase playerBase;

        private void Start()
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
    }
}
