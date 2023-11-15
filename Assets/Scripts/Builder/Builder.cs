using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private Flag _startFlag;
        [SerializeField] private Base _base;
        [SerializeField] private CameraRayPointer _cameraRay;
        [SerializeField] private Pattern _prefab;

        private List<Flag> _flags = new();

        private Flag _currentFlag;
        private Pattern _pattern;

        private void Awake()
        {
            _flags.Add(_startFlag);
        }

        private void LateUpdate()
        {
            if(TryFindActiveFlag(out Flag flag))
            {
                _pattern.transform.position = _cameraRay.point;

                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ChangeTargetBase(flag, false);
                }
            }
        }

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
                if (flag.IsActive)
                {
                    activeFlag = flag;
                    return true;
                }
            }

            activeFlag = null;
            return false;
        }
    }
}