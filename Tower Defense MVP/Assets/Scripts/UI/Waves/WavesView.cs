using JGM.Gameplay.Waves;
using TMPro;
using UnityEngine;

namespace JGM.UI.Waves
{
    public class WavesView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI wavesNumberText;
        [SerializeField] private WavesController wavesController;

        private void OnEnable()
        {
            wavesController.OnWaveStart += OnWaveStart;
        }

        private void OnDisable()
        {
            wavesController.OnWaveStart -= OnWaveStart;
        }

        private void OnWaveStart(int wave)
        {
            wavesNumberText.text = $"{wave + 1}/{wavesController.WavesCount}";
        }
    }
}
