using System;
using UnityEngine;

namespace JGM.Gameplay.Waves
{
    [CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
    public class Wave : ScriptableObject
    {
        [Range(0, 100)]
        public int CreepsCount;
    }
}
