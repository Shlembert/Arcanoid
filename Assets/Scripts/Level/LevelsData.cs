using UnityEngine;

namespace Game
{
    public class LevelsData
    {
        private const string KeyNane = "Save";
        private LevelProgress _levelProgress = new LevelProgress();

        private void SaveData()
        {
            string saveJson = JsonUtility.ToJson(_levelProgress);
            PlayerPrefs.SetString(KeyNane, saveJson);
            PlayerPrefs.Save();
        }

        public void NewData()
        {
            var levelsCount = Resources.LoadAll<GameLevel>("Levels").Length;

            for (int i = 0; i < levelsCount; i++)
            {
                _levelProgress.Levels.Add(new Progress());
            }

            _levelProgress.Levels[0].IsOpened = true;
            SaveData();
            Resources.UnloadUnusedAssets();
        }

        public LevelProgress GetLevelProgress()
        {
            if (PlayerPrefs.HasKey(KeyNane))
            {
                string saveJson = PlayerPrefs.GetString(KeyNane);
                _levelProgress = JsonUtility.FromJson<LevelProgress>(saveJson);
            }
            else
            {
                NewData();
            }

            return _levelProgress;
        }

        public void SaveLevelData(int index, Progress progress)
        {
            _levelProgress = GetLevelProgress();
            _levelProgress.Levels[index] = progress;

            if(index < _levelProgress.Levels.Count - 1)
            {
                _levelProgress.Levels[index + 1].IsOpened = true;
            }

            SaveData();
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(KeyNane);
        }
    }
}

