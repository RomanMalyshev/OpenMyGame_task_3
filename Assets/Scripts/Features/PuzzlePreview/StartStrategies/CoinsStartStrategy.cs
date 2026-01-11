using System.Threading.Tasks;
using Data.Models;
using UnityEngine;

namespace Features.PuzzlePreview.StartStrategies
{
    public class CoinsStartStrategy : IStartStrategy
    {
        private readonly int _cost;
        
        public StartType Type => StartType.Coins;
        public string ButtonText => $"Начать за {_cost} монет";
        
        public CoinsStartStrategy(int cost)
        {
            _cost = cost;
        }

        public bool CanStart()
        {
            // For demo, always return true
            Debug.Log($"[CoinsStartStrategy] Checking if player has {_cost} coins");
            return true;
        }
        
        public Task<bool> ExecuteAsync()
        {
            Debug.Log($"[CoinsStartStrategy] Spending {_cost} coins to start puzzle");
            // For demo, just log and return success
            return Task.FromResult(true);
        }
        
    }
}
