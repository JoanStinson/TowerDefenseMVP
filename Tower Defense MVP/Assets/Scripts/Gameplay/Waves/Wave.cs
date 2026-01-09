using AYellowpaper;
using JGM.Gameplay.Creeps;
using System;
using UnityEngine;

namespace JGM.Gameplay.Waves
{
    [CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
    public class Wave : ScriptableObject
    {
        public WaveEnemy[] Creeps;

        public float DelayBetweenCreeps = 2;

        [Serializable]
        public class WaveEnemy
        {
            public InterfaceReference<ICreep, MonoBehaviour> CreepPrefab;

            [Range(1, 100)]
            public int CreepsCount;
        }
    }
}
