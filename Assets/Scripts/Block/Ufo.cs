using System;
using UnityEngine;

namespace Game
{
    public class Ufo : MonoBehaviour, IDamage
    {
        private const int Score = 1000;
        private const float Speed = 3;
        private float _maxDistance;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _boxCollider2;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private AudioSource _audioSource;

        public static event Action<int> OnDestroyed;

        private void Update()
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);

            if (transform.position.x > _maxDistance)
            {
                gameObject.SetActive(false);
            }
        }

        private void ShowObject(bool value)
        {
            _spriteRenderer.enabled = value;
            _boxCollider2.enabled = value;
        }

        private void OnEnable()
        {
            ShowObject(true);

            _maxDistance = Math.Abs(transform.position.x);

            if (AudioController.Audio.GetSuondValue())
            {
                _audioSource.Play();
            }
        }

        public void ApplyDamage()
        {
            OnDestroyed?.Invoke(Score);
            ShowObject(false);
            _particleSystem.Play();
        }
    }
}

