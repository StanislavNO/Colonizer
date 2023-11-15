using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class SpawnZone : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Vector3> _placeWasChosen;
        [SerializeField] private Map _map;

        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }

        public void FindPlace()
        {
            do
            {
                transform.position = CreateNewPosition();
            }
            while (CheckCollisions());

            _placeWasChosen.Invoke(transform.position);
        }

        private Vector3 CreateNewPosition()
        {
            Vector3 result;

            result = new Vector3(
                Random.Range(Vector3.zero.x, _map.Size.x),
                transform.position.y,
                Random.Range(Vector3.zero.z, _map.Size.z));

            return result;
        }

        private bool CheckCollisions()
        {
            int minColliders = 0;
            Vector3 scanArea = new(1, 0.5f, 1);

            Collider[] colliders = Physics.OverlapBox(
                    transform.position,
                    scanArea);

            return colliders.Length > minColliders;
        }
    }
}