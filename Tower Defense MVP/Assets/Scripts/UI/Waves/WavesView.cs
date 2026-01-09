using JGM.Gameplay.Waves;
using TMPro;
using UnityEngine;

namespace JGM.UI.Waves
{
    public class WavesView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI wavesNumberText;
        [SerializeField] private WavesController wavesController;

        private int maxWave;

        private void Start()
        {
            maxWave = wavesController.WavesCount;
            wavesNumberText.text = $"1/{maxWave}";
        }

        private void OnEnable()
        {
            wavesController.OnWaveComplete += OnWaveComplete;
        }

        private void OnDisable()
        {
            wavesController.OnWaveComplete -= OnWaveComplete;
        }

        private void OnWaveComplete(int wave)
        {
            wavesNumberText.text = $"{wave + 1}/{maxWave}";
        }
    }
}
