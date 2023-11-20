using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Pattern))]
    public class Builder : MonoBehaviour
    {
        [SerializeField] private UnitParking _unitParking;
        [SerializeField] private Warehouse _warehouse;

        private Pattern _pattern;
        private Vector3 _startPosition;

        private bool _isActivated;

        private void Awake()
        {
            _pattern = GetComponentInParent<Pattern>();
            _startPosition = transform.position;
            _isActivated = false;
        }

        private void LateUpdate()
        {
            if (transform.position != _startPosition)
            {
                _isActivated = true;
            }

            if (_isActivated)
            {

            }

            //if (TryFindActiveFlag(out Flag flag))
            //{
            //    _pattern.transform.position = _cameraRay.Point;

            //    if (Input.GetKeyDown(KeyCode.Mouse0))
            //    {
            //        ChangeTargetBase(flag, false);

            //        _pattern.Activate();

            //        //!!!
            //        flag.GetComponent<Warehouse>().SaveUpForBase();

            //        //StartCoroutine(CreateBase1());
            //        //CreateBase(new Vector3(_pattern.transform.position.x, _startFlag.transform.position.y, _pattern.transform.position.z));
            //    }
            //}
        }

        private void Deactivate()
        {
            transform.position = _startPosition;
            _isActivated = false;
        }

        //public void AddFlag(Flag flag) =>
        //    _flags.Add(flag); 

        //public void CreateBase(Vector3 position)
        //{
        //    Flag newFlag = Instantiate(_startFlag, position, Quaternion.identity);
        //    _flags.Add(newFlag);
        //    //_isActivated = false;
        //}

        //public void ChangeTargetBase(Flag newFlag, bool isActivated = true)
        //{
        //    _currentFlag?.Deactivate();

        //    if (isActivated)
        //        newFlag.Activate();
        //    else
        //        newFlag.Deactivate();

        //    _pattern = newFlag.GetPattern();
        //    _currentFlag = newFlag;
        //}

        //private bool TryFindActiveFlag(out Flag activeFlag)
        //{
        //    foreach (Flag flag in _flags)
        //    {
        //        if (flag.IsActivated)
        //        {
        //            activeFlag = flag;
        //            return true;
        //        }
        //    }

        //    activeFlag = null;
        //    return false;
        //}

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