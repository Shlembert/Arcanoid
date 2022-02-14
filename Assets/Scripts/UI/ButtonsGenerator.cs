using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ButtonsGenerator : MonoBehaviour
    {
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private GameObject _content;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            LevelsData levelsData = new LevelsData();
            LevelProgress levelProgress = levelsData.GetLevelProgress();

            for (int i = 0; i < levelProgress.Levels.Count; i++)
            {
                Button button = Instantiate(_buttonPrefab, _content.transform);

                if(button.gameObject.TryGetComponent(out LevelButton levelButton))
                {
                    levelButton.SetData(levelProgress.Levels[i], i);
                }
            }

            LoadingScreen.Screen.Enable(false);
        }
    }
}

