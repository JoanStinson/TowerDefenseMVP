using System;
using UnityEngine;

namespace JGM.Gameplay.Base
{
    public class PlayerBase : MonoBehaviour
    {
        public event Action<int> OnHealthDecreased;

        public int MaxHealth { get; } = 30;

        public int CurrentHealth => health;

        private int health = 30;

        public void DecreaseHealth()
        {
            health--;
            OnHealthDecreased?.Invoke(health);
        }
    }
}
