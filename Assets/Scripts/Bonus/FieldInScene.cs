using UnityEngine;

namespace Game
{
    public class FieldInScene : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private BoxCollider2D _boxCollider2;

        public void SetActive(bool value)
        {
            _boxCollider2.enabled = value;
            _sprite.enabled = value;
        }
    }
}

