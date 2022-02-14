using UnityEngine;

namespace Game
{
    public class WindowController : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private GameObject _endGameWindow;
        [SerializeField] private GameObject _pauseWindow;

        public void Play()
        {
            _gameState.SetState(State.Gameplay);
            _pauseWindow.SetActive(false);
        }

        public void Replay()
        {
            DisableTwoWindow();
        }

        public void NextLevel()
        {
            _endGameWindow.SetActive(false);
        }

        public void ToHome()
        {
            DisableTwoWindow();
            LoadingScreen.Screen.Enable(true);
            Loader loader = new Loader();
            _gameState.SetState(State.Other);
            loader.LoadingMyScene(true);
        }

        private void DisableTwoWindow()
        {
            _endGameWindow.SetActive(false);
            _pauseWindow.SetActive(false);
        }

        private void OnEnable()
        {
            Block.OnEnded += EndGame;
        }

        private void OnDisable()
        {
            Block.OnEnded -= EndGame;
        }

        private void EndGame()
        {
            if(_gameState.State == State.Gameplay)
            {
                _endGameWindow.SetActive(true);
            }
        }
    }

}


