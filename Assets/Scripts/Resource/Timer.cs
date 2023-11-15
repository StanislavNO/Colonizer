using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private UnityEvent _timeHasCom;
        [SerializeField] private float _delay;
        [SerializeField] private int _maxResource;

        private void Start()
        {
            StartCoroutine(CreateResource());
        }

        private IEnumerator CreateResource()
        {
            WaitForSecondsRealtime delay = new WaitForSecondsRealtime(_delay);

            while (ResourceWorldCounter.Count < _maxResource)
            {
                yield return delay;
                _timeHasCom.Invoke();
            }
        }
    }
}