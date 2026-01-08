using System;
using UnityEngine;

namespace JGM.Gameplay.Base
{
    public class PlayerBase : MonoBehaviour
    {
        public event Action<int> OnHealthDecreased;

        public int MaxHealth = 3;
        public int CurrentHealth => health;

        [SerializeField]
        private int health = 3;

        public void DecreaseHealth()
        {
            health--;
            OnHealthDecreased?.Invoke(health);
        }
    }
}
