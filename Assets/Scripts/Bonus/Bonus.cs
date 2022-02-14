using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public abstract class Bonus : MonoBehaviour
    {
        [SerializeField] protected int _score;
        [SerializeField] protected float _time = 4f;
        private float _curentTime;
        private const float TimeStep = 0.5f;
        public static event Action<int> OnAdded;

        public abstract void Apply();

        public void StopAndRemove()
        {
            if(TryGetComponent(out IRemivable remivable))
            {
                remivable.Remove();
            }
            Destroy(gameObject);
        }
        protected void StartTimer()
        {
            OnAdded?.Invoke(_score);
            _curentTime = _time;
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            while (_curentTime > 0)
            {
                _curentTime -= TimeStep;
                yield return new WaitForSeconds(TimeStep);
            }

            StopAndRemove();
        }
    }
}

