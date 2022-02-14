using UnityEngine;

namespace Game
{
    public class OtherBlock : BaseBlocks
    {
        [SerializeField] private ParticleSystem _particle = null;

        private void Start()
        {
            _particle = Instantiate(_particle, gameObject.transform.position, Quaternion.identity);
            _particle.transform.SetParent(gameObject.transform);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _particle.Simulate(0, true, true);
            _particle.transform.position = collision.contacts[0].point;
            _particle.Play();
        }
    }
}

