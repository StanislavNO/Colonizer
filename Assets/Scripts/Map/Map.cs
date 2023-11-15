using UnityEngine;

namespace Assets.Scripts
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Terrain _terrain;

        public Vector3 Size => _terrain.terrainData.size;

        private void Awake() =>
            transform.position = Vector3.zero;
    }
}