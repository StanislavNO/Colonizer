using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class UnitParking : MonoBehaviour
    {
        private List<Collector> _collectors = new();

        public int NumberUnits => _collectors.Count();
        public int ParkedUnits => GetParkedUnits();

        public void SetUnit(Collector unit)
        {
            _collectors.Add(unit);
        }

        public Collector GetUnit()
        {
            Debug.Log(0);
            int lastUnit = _collectors.Count - 1;
            Collector unit = _collectors[lastUnit];

            _collectors.RemoveAt(_collectors.Count -1);
            if (unit == null)
            {
                Debug.Log("1");
            }
            else
                Debug.Log("2");

            return unit;
        }

        public void SendingUnit(Resource resource)
        {
            foreach (var collector in _collectors)
            {
                if (collector.IsWorking == false)
                {
                    collector.SetTarget(resource);
                    return;
                }
            }
        }

        private int GetParkedUnits()
        {
            int result = 0;

            foreach (Collector collector in _collectors)
            {
                if (collector.IsWorking == false)
                {
                    result++;
                }
            }

            return result;
        }
    }
}