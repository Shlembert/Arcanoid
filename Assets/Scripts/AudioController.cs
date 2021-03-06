using UnityEngine;

namespace Game
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Audio = null;
        [SerializeField] private AudioSource _backgroundSource;

        private AudioState _audioState;

        private void Awake()
        {
            if(Audio == null)
            {
                Audio = this;
                DontDestroyOnLoad(gameObject);
                _audioState = new AudioState();

                if (_audioState.GetAudioValues().Music) _backgroundSource.Play();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ChangeMusic()
        {
            _audioState.EnableMusic(!_audioState.GetAudioValues().Music);

            if (_audioState.GetAudioValues().Music)
            {
                _backgroundSource.Play();
            }
            else
            {
                _backgroundSource.Stop();
            }
        }

        public void ChangeSound()
        {
            _audioState.EnableSound(!_audioState.GetAudioValues().Sound);
        }

        public bool GetSuondValue()
        {
            return _audioState.GetAudioValues().Sound;
        }

        public bool GetMusicValue()
        {
            return _audioState.GetAudioValues().Music;
        }
    }
}

