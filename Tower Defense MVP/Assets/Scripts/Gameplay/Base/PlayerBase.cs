using JGM.Gameplay.Combat;
using System;
using UnityEngine;

namespace JGM.Gameplay.Base
{
    public class PlayerBase : MonoBehaviour, IDamageable
    {
        public event Action<int> OnTakeDamage;
        public event Action OnHealthDepleted;
        
        public int MaxHealth => maxHealth;
        public int CurrentHealth => health;

        [SerializeField]
        private int maxHealth = 30;
        private int health;

        private void Awake()
        {
            health = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            OnTakeDamage?.Invoke(health);

            if (health <= 0)
            {
                health = 0;
                OnHealthDepleted?.Invoke();
            }
        }
    }
}
