using System;
using UnityEngine;

namespace Data.Models
{
    [Serializable]
    public class CutOption
    {
        [SerializeField] private int _pieceCount;
        [SerializeField] private string _displayName;
        
        public int PieceCount => _pieceCount;
        public string DisplayName => string.IsNullOrEmpty(_displayName) 
            ? $"{_pieceCount} шт." 
            : _displayName;
        
        public CutOption(int pieceCount, string displayName = null)
        {
            _pieceCount = pieceCount;
            _displayName = displayName;
        }
        
    }
}
