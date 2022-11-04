using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexSystem
{
    public class GridSystem : MonoBehaviour
    {
        public Tilemap tilemap;

        public Vector2 cellSize = new Vector2(0.87f, 1.0f);

        private Vector3 _offset;

        private void Awake()
        {
            tilemap = GetComponent<Tilemap>();
        }

        private void Start()
        {
            _offset = new Vector3()
            {
                x = cellSize.x * 1.0f,
                y = cellSize.y * (3.0f / 4.0f),
                z = 1.0f
            };
            
            foreach (Hex hex in GetComponentsInChildren(typeof(Hex)))
            {
                hex.Coordinate = LocalPositionToCell(hex.transform.localPosition);
            }
        }

        private Vector3Int LocalPositionToCell(Vector3 position)
        {
            int y = Mathf.RoundToInt(position.y / _offset.y);
            int z = Mathf.RoundToInt(position.z / _offset.z);
            
            // y % 2
            int x = (y % 2) == 0 ? Mathf.RoundToInt(position.x / _offset.x) : Mathf.CeilToInt(position.x / _offset.x);

            return new Vector3Int(x, y, z);
        }
    }
}
