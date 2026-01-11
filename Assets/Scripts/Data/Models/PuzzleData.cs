using System;
using UnityEngine;

namespace Data.Models
{

    [Serializable]
    public class PuzzleData
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _previewSprite;
        [SerializeField] private Sprite _fullSprite;
        [SerializeField] private StartType _startType;
        
        public string Id => _id;
        public string Name => _name;
        public Sprite PreviewSprite => _previewSprite;
        public Sprite FullSprite => _fullSprite;
        public StartType StartType => _startType;
        
        public PuzzleData() { }
        
        public PuzzleData(string id, string name, Sprite previewSprite, Sprite fullSprite)
        {
            _id = id;
            _name = name;
            _previewSprite = previewSprite;
            _fullSprite = fullSprite;
        }
    }
}
