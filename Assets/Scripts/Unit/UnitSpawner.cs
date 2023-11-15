using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private UnitParking _unitParking;

        [SerializeField] private Collector _prefab;
        [SerializeField] private int _startNumber;

        private void Start()
        {
            for (int i = 0; i < _startNumber; i++)
            {
                CreateUnit();
            }
        }

        public void CreateUnit()
        {
            var unit = Instantiate(
                _prefab,
                transform.position,
                Quaternion.identity);

            unit.GetComponent<TargetMover>()
                .Init(_unitParking.transform.position);

            _unitParking.AddUnit(unit);
        }
    }
}