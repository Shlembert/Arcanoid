using UnityEngine;

namespace Game
{
    public class SettingWindow : MonoBehaviour
    {
        [SerializeField] private AudioButton _sound;
        [SerializeField] private AudioButton _music;

        private void OnEnable()
        {
            _music.SetState(AudioController.Audio.GetMusicValue());
            _sound.SetState(AudioController.Audio.GetSuondValue());
        }

        public void ChangeSound()
        {
            AudioController.Audio.ChangeSound();

        }

        public void ChangeMusic()
        {
            AudioController.Audio.ChangeMusic();
        }

        public void ClearProgress()
        {
            LevelIndex levelIndex = new LevelIndex();
            levelIndex.Clear();
            LevelsData levelsData = new LevelsData();
            levelsData.Clear();
            Loader loader = new Loader();
            loader.LoadingMyScene(true);
        }
    }
}

