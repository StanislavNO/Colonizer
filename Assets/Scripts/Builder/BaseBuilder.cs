using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class BaseBuilder : MonoBehaviour
    {
        Base _base;
        Flag _flag;
        Warehouse _warehouse;
        UnitParking _unitParking;

        public void Init()
        {
            
        }

        private void Update()
        {
            
        }

        public void ChangeCurrentFlag(Flag flag)
        {
            _flag = flag;
        }
    }
}