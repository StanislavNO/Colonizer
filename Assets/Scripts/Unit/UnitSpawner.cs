using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private UnitParking _unitParking;

        [SerializeField] private Collector _prefab;

        public void CreateUnit()
        {
            var unit = Instantiate(
                _prefab,
                transform.position,
                Quaternion.identity);

            unit.GetComponent<TargetMover>()
                .Init(_unitParking.transform.position);

            _unitParking.SetUnit(unit);
        }
    }
}