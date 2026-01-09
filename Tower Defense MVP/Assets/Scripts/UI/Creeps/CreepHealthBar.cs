using JGM.Gameplay.Creeps;
using JGM.UI.HealthBar;
using UnityEngine;

namespace JGM.UI.Creeps
{
    public class CreepHealthBar : HealthBarBase
    {
        [SerializeField]
        private Creep creep;

        private void Start()
        {
            slider.maxValue = creep.MaxHealth;
            slider.value = creep.MaxHealth;
        }

        private void OnEnable()
        {
            creep.OnTakeDamage += OnHealthChange;
        }

        private void OnDisable()
        {
            creep.OnTakeDamage -= OnHealthChange;
        }
    }
}
