﻿using UnityEngine;

namespace Assets.Scripts
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] TargetMover _mover;
        [SerializeField] ResourceBag _inventory;

        public bool IsWorking => _mover.IsWorking;

        public void SetTarget(Resource resource)
        {
            resource.ActivateResource();

            _mover.SetTarget(resource.transform);
            _inventory.SetTarget(resource);
        }
    }
}