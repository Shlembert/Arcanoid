using UnityEngine;

namespace Game
{
    public class BallMove : MonoBehaviour
    {
        private const float Force = 300f;
        [SerializeField] private BallSound _ballSound;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private bool _isActive;


        private void OnEnable()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            PlayerInput.OnClicked += BallActive;
        }

        private void OnDisable()
        {
            PlayerInput.OnClicked -= BallActive;
        }

        private void BallActive()
        {
            if (!_isActive)
            {
                _ballSound.PlaySoundAwake();
                _isActive = true;
                transform.SetParent(null);
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

                AddForce();
            }
        }

        public void AddForce(float direction = 0.3f)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(direction * (Force /2), Force));
        }

        public void StartClone(float direction)
        {
            _ballSound.PlaySoundAwake();
            _isActive = true;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

            AddForce(direction);
        }
    }
}

