using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

namespace Assets.Scripts
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private CameraRayPointer _cameraRay;
        [SerializeField] private Flag _startFlag;
        [SerializeField] private Pattern _prefab;

        //[SerializeField] private UnitParking _unitParking;
        //[SerializeField] private Warehouse _warehouse;

        private List<Flag> _flags = new();

        private Flag _currentFlag;
        private Pattern _pattern;

        //private bool _isActivated;

        private void Awake()
        {
            _flags.Add(_startFlag);
        }

        private void LateUpdate()
        {
            //if (_isActivated)
            //{

            //}

            if (TryFindActiveFlag(out Flag flag))
            {
                _pattern.transform.position = _cameraRay.Point;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ChangeTargetBase(flag, false);

                    _pattern.Activate();

                    //StartCoroutine(CreateBase1());
                    //CreateBase(new Vector3(_pattern.transform.position.x, _startFlag.transform.position.y, _pattern.transform.position.z));
                }
            }
        }

        //public void CreateBase(Vector3 position)
        //{
        //    Flag newFlag = Instantiate(_startFlag, position, Quaternion.identity);
        //    _flags.Add(newFlag);
        //    //_isActivated = false;
        //}

        public void ChangeTargetBase(Flag newFlag, bool isActivated = true)
        {
            _currentFlag?.Deactivate();

            if (isActivated)
                newFlag.Activate();
            else
                newFlag.Deactivate();

            _pattern = newFlag.GetPattern();
            _currentFlag = newFlag;
        }

        private bool TryFindActiveFlag(out Flag activeFlag)
        {
            foreach (Flag flag in _flags)
            {
                if (flag.IsActivated)
                {
                    activeFlag = flag;
                    return true;
                }
            }

            activeFlag = null;
            return false;
        }

        //private void Activate(Flag flag)
        //{
        //    ChangeTargetBase(flag, false);

        //    _pattern.Activate();
        //    //_isActivated = true;
        //}

        //private IEnumerator CreateBase1()
        //{
        //    Debug.Log("cor");
        //    Collector unit;

        //    _warehouse.SaveUpForBase();

        //    while (_warehouse.IsAccumulateBase)
        //    {
        //        yield return new WaitForSeconds(0.5f);
        //    }

        //    unit = _unitParking.GetUnit();

        //    while (unit.IsWorking != false)
        //    {
        //        Debug.Log("cor iswork");
        //        yield return new WaitForSeconds(0.5f);
        //    }

        //    unit.ChangeHomePosition(_pattern.transform.position);

        //    while (unit.transform.position != _currentFlag.transform.position)
        //    {
        //        unit.GetComponent<TargetMover>().GoHome(_currentFlag.transform.position);
        //        yield return new WaitForSeconds(0.5f);
        //    }

        //    CreateBase(new Vector3(_pattern.transform.position.x, _startFlag.transform.position.y, _pattern.transform.position.z));

        //    yield break;
        //}
    }
}