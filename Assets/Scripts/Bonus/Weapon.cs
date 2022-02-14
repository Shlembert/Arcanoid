using System.Collections;
using UnityEngine;

namespace Game
{
    public class Weapon : Bonus
    {
        private const float OffsetY = 0.5f;
        private const float OffsetX = 0.7f;
        private ObjectsPool _bulletPool;

        public override void Apply()
        {
            StartTimer();
            StartCoroutine(StartShoot());
        }

        private void OnEnable()
        {
            if(_bulletPool == null)
            {
                ObjectsPool[] objectsPools = FindObjectsOfType<ObjectsPool>();

                for (int i = 0; i < objectsPools.Length; i++)
                {
                    if (objectsPools[i].gameObject.CompareTag("BulletsPool"))
                    {
                        _bulletPool = objectsPools[i];

                        break;
                    }
                }
            }
        }

        private IEnumerator StartShoot()
        {
            while (true)
            {
                ActivateBullet(OffsetX);
                ActivateBullet(-OffsetX);
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void ActivateBullet(float offsetX)
        {
            GameObject bullet = _bulletPool.GetObject();

            if (bullet != null)
            {
                bullet.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + OffsetY);
                bullet.SetActive(true);
            }
        }
    }
}

