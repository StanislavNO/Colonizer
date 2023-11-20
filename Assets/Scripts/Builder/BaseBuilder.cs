using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Assets.Scripts
{
    public class BaseBuilder : MonoBehaviour
    {
        Base _base;
        Flag _flag;
        Warehouse _warehouse;
        UnitParking _unitParking;
        Pattern _pattern;
        Builder _builder;

        Collector _unit;

        bool nakoplen;

        public void Init(Base myBase, Warehouse warehouse, UnitParking unitParking)
        {
            _base = myBase;
            _warehouse = warehouse;
            _unitParking = unitParking;
            _pattern = GetComponent<Pattern>();
        }

        private void Update()
        {
            //if ( _pattern.IsActivated )
            //{
            //    _warehouse.SaveUpForBase();

                

            //    if (_warehouse.IsAccumulateBase == false )
            //    {
            //        if (_unit == null)
            //            _unit = _unitParking.GetUnit();
            //        Debug.Log(_unit == null);
            //        Debug.Log(1);

            //        _unit.ChangeHomePosition(transform.position);

            //        if(_unit.transform.position == transform.position)
            //        {
            //            CreateBase(transform.position);
            //        }
            //    }
            //}
        }

        //public void ChangeCurrentFlag(Flag flag)
        //{
        //    _flag = flag;
        //}

        //public void CreateBase(Vector3 position)
        //{
        //    Flag newFlag = Instantiate(_flag, position, Quaternion.identity);
        //    _builder.AddFlag(newFlag);
        //}
    }
}