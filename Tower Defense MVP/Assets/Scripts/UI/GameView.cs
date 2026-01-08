using JGM.Gameplay;
using UnityEngine;

namespace JGM.UI
{
    public class GameView : MonoBehaviour
    {
        [SerializeField]
        private GameController gameController;

        private void Awake()
        {
            gameController.OnGameStarted += OnGameStart;
        }

        private void OnGameStart()
        {

        }
    }
}