using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private UnitParking _unitParking;

        [SerializeField] private Collector _prefab;
        [SerializeField] private int _startUnits;

        private int _countUnitsInStartBase = 0;

        private void Start()
        {
            if (_unitParking.NumberUnits == _countUnitsInStartBase)
            {
                for (int i = 0; i < _startUnits; i++)
                {
                    CreateUnit();
                }
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