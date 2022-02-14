using UnityEngine;

namespace Game
{
    public class BallCollision : MonoBehaviour
    {
        [SerializeField] private BallMove _ball;
        [SerializeField] private BallSound _ballSound;
        private float _lastPositionX;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _ballSound.PlaySoundCollision();

            float ballPositionX = transform.position.x;

            if (collision.gameObject.TryGetComponent(out PlayerMove playerMove))
            {
                if (ballPositionX < _lastPositionX + .1f && ballPositionX > _lastPositionX - .1f)
                {
                    float collisionPointX = collision.contacts[0].point.x;
                    float playerCenterPosition = playerMove.gameObject.transform.position.x;
                    float difference = playerCenterPosition - collisionPointX;
                    float direction = collisionPointX < playerCenterPosition ? -1 : 1;
                    _ball.AddForce(direction * Mathf.Abs(difference));
                }
            }

            _lastPositionX = ballPositionX;

            if (collision.gameObject.TryGetComponent(out IDamage damage))
            {
                damage.ApplyDamage();
            }

            if (collision.gameObject.TryGetComponent(out BlockComposite blockComposite))
            {
                blockComposite.AppleDamage(collision.contacts[0].point);
            }
        }
    }
}
