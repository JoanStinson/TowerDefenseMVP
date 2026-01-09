using JGM.Gameplay.Creeps;
using System;
using UnityEngine;

namespace JGM.Gameplay.Waves
{
    [CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
    public class Wave : ScriptableObject
    {
        public WaveEnemy[] Creeps;

        [Serializable]
        public class WaveEnemy
        {
            public Creep CreepPrefab;

            [Range(1, 100)]
            public int CreepsCount;
        }
    }
}
