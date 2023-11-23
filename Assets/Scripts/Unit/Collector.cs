using UnityEngine;

namespace Assets.Scripts
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] TargetMover _mover;
        [SerializeField] ResourceBag _inventory;

        public bool IsWorking => _mover.IsWorking;
        public bool IsStray => _mover.IsStray;

        public void ChangeHomePosition(Vector3 newHome)
        {
            _mover.Init(newHome);
        }

        public void SetBase()
        {
            _mover.SetBase();
        }

        public void SetTarget(Resource resource)
        {
            //Debug.Log(0.2f);
            resource.ActivateResource();

            _mover.SetTarget(resource.transform);
            _inventory.SetTarget(resource);
        }
    }
}