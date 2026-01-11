using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Config;
using Data.Models;
using UnityEngine;

namespace Infrastructure.Services
{
    public class AssetProvider : IAssetProvider
    {
        private readonly GameConfig _gameConfig;

        public AssetProvider(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        public Task<Sprite> GetImageAsync(string puzzleId)
        {
            var puzzleData = _gameConfig.GetPuzzleById(puzzleId);
            
            if (puzzleData == null)
            {
                Debug.LogWarning($"[AssetProvider] Puzzle not found: {puzzleId}");
                return Task.FromResult<Sprite>(null);
            }
            
            // In production, could load asynchronously from Addressables
            return Task.FromResult(puzzleData.FullSprite);
        }
        
        public IReadOnlyList<PuzzleData> GetAllPuzzles()
        {
            return _gameConfig.Puzzles;
        }
        
        public PuzzleData GetPuzzleById(string puzzleId)
        {
            return _gameConfig.GetPuzzleById(puzzleId);
        }
    }
}
