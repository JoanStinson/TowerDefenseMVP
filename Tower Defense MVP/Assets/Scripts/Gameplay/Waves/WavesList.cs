using UnityEngine;

namespace JGM.Gameplay.Waves
{
    [CreateAssetMenu(fileName = "New Waves List", menuName = "Waves List")]
    public class WavesList : ScriptableObject
    {
        public Wave[] Waves;
    }
}
