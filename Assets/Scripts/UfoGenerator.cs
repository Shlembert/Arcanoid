using UnityEngine;

namespace Game
{
    public class UfoGenerator : MonoBehaviour
    {
        private const float MinPositionY = -3.75f;
        private const float MaxPositionY = 6.75f;
        private ObjectsPool _ufosPool;

        private void OnEnable()
        {
            if (_ufosPool == null)
            {
                ObjectsPool[] objectsPools = FindObjectsOfType<ObjectsPool>();

                for (int i = 0; i < objectsPools.Length; i++)
                {
                    if (objectsPools[i].gameObject.CompareTag("UfosPool"))
                    {
                        _ufosPool = objectsPools[i];

                        break;
                    }
                }
            }
        }

        public void Generate()
        {
            GameObject ufo = _ufosPool.GetObject();

            if (ufo != null)
            {
                float tempY = Random.Range(MinPositionY, MaxPositionY);
                ufo.transform.position = new Vector2(transform.position.x, tempY);
                ufo.SetActive(true);
            }
        }

    }
}

