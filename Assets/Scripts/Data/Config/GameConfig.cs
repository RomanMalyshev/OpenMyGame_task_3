using System.Collections.Generic;
using Data.Models;
using UnityEngine;

namespace Data.Config
{
    
    [CreateAssetMenu(fileName = "GameConfig", menuName = "PuzzleGame/Game Config")]
    public class GameConfig : ScriptableObject
    {
        
        [SerializeField, Tooltip("Cost in coins for Coins start type")]
        private int _coinsCost = 100;
        
        [Header("Cut Options")]
        [SerializeField, Tooltip("Available puzzle cut options")]
        private List<CutOption> _cutOptions = new List<CutOption>
        {
            new CutOption(50),
            new CutOption(200),
            new CutOption(400)
        };
        
        [Header("Puzzle Data")]
        [SerializeField, Tooltip("List of available puzzles")]
        private List<PuzzleData> _puzzles = new List<PuzzleData>();
        public int CoinsCost => _coinsCost;
        public IReadOnlyList<CutOption> CutOptions => _cutOptions;
        public IReadOnlyList<PuzzleData> Puzzles => _puzzles;
        
        public PuzzleData GetPuzzleById(string puzzleId)
        {
            return _puzzles.Find(p => p.Id == puzzleId);
        }
    }
}
