using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        private const float Speed = 10f;

        private void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamage damage))
            {
                damage.ApplyDamage();
            }

            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            if (AudioController.Audio.GetSuondValue())
            {
                _audioSource.Play();
            }
        }
    }
}

