using JGM.Gameplay.Creeps;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.UI.Creeps
{
    public class CreepHealthBar : MonoBehaviour
    {
        [SerializeField] private Creep creep;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            slider.maxValue = creep.MaxHealth;
            slider.value = creep.MaxHealth;
        }

        private void OnEnable()
        {
            creep.OnHealthDecreased += OnHealthDecreased;
        }

        private void OnDisable()
        {
            creep.OnHealthDecreased -= OnHealthDecreased;
        }

        private void OnHealthDecreased(int health)
        {
            slider.value = health;
        }
    }
}
