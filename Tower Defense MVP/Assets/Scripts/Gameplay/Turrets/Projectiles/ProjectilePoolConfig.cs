using System;
using UnityEngine;

namespace JGM.Gameplay.Turrets.Projectiles
{
    [CreateAssetMenu(fileName = "New Projectile Pool Config", menuName = "Turrets/Projectiles/Projectile Pool Config")]
    public class ProjectilePoolConfig : ScriptableObject
    {
        public BasicPoolConfig[] Configs;

        [Serializable]
        public class BasicPoolConfig 
        {
            public GameObject ProjectilePrefab;
            
            [Range(0, 100)]
            public int PoolCount;
        }
    }
}
