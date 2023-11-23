using UnityEngine;

namespace Assets.Scripts
{
    public class InitStartBase : MonoBehaviour
    {
        [SerializeField] private UnitSpawner _spawner;
        [SerializeField][Range(0, 10)] private int _startUnits;

        void Start()
        {
            for (int i = 0; i < _startUnits; i++)
                _spawner.CreateUnit();
        }
    }
}