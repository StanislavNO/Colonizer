using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using System.Collections;
using System.Security.Cryptography;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider),typeof(Flag))]
    public class UnitParking : MonoBehaviour
    {
        private List<Collector> _collectors = new();

        public int NumberUnits => _collectors.Count();
        public int ParkedUnits => GetParkedUnits();

        public void SetUnit(Collector unit)
        {
            _collectors.Add(unit);
            unit.SetBase();
        }

        public Collector GetUnit()
        {
            int lastUnit = _collectors.Count - 1;
            Collector unit = _collectors[lastUnit];

            _collectors.RemoveAt(_collectors.Count - 1);

            return unit;
        }

        public void SendingUnit(Resource resource)
        {
            //Debug.Log("P1");
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
                    result++;
            }

            return result;
        }

        public void GoUnit()
        {
            //Debug.Log(1);
            int lastUnit = _collectors.Count - 1;
            Collector unit = _collectors[lastUnit];

            _collectors.RemoveAt(_collectors.Count - 1);

            StartCoroutine(UnitHom(unit));
            //unit.ChangeHomePosition(GetComponent<Flag>().GetPattern().transform.position);
        }

        private IEnumerator UnitHom (Collector unit)
        {
            WaitForSecondsRealtime delay = new(0.2f);

            do
            {
                yield return delay;
            }
            while (unit.IsWorking == true);
            //Debug.Log(1);
            unit.ChangeHomePosition(
                GetComponent<Flag>()
                .GetPattern()
                .transform.position);
        }
    }
}