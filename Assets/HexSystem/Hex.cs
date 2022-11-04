using System;
using UnityEngine;
using UnityEngine.UI;

namespace HexSystem
{
    [SelectionBase]
    public class Hex : MonoBehaviour
    {
        private Vector3Int _coordinate;

        public Text coordText;

        public Vector3Int Coordinate
        {
            set
            {
                _coordinate = value;
                coordText.text = $"{value.y} {value.x}";
            }
            get => _coordinate;
        }
        
        
    }
}
