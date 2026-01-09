using JGM.Gameplay.Combat;
using System;
using UnityEngine;

namespace JGM.Gameplay.Base
{
    public class PlayerBase : MonoBehaviour, IDamageable
    {
        public event Action<int> OnTakeDamage;
        public event Action OnHealthDepleted;

        public int MaxHealth { get; } = 30;
        public int CurrentHealth => health;

        private int health = 30;

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
