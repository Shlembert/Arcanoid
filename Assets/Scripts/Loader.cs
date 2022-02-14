using UnityEngine.SceneManagement;

namespace Game
{
    public class Loader
    {
        private const string Main = "Main";
        private const string Game = "Game";

        public void LoadingMyScene(bool value)
        {
            SceneManager.LoadSceneAsync(value ? Main : Game);
        }
    }
}

