using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class UnitParking : MonoBehaviour
    {
        private List<Collector> _collectors = new();

        public int NumberUnits => _collectors.Count();
        public int ParkedUnits => GetParkedUnits();

        public void AddUnit(Collector unit)
        {
            _collectors.Add(unit);
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