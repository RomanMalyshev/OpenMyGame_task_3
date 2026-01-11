using System.Threading.Tasks;
using Data.Models;
using UnityEngine;

namespace Features.PuzzlePreview.StartStrategies
{
    public class FreeStartStrategy : IStartStrategy
    {
        public StartType Type => StartType.Free;
        public string ButtonText => "Начать";
        
        public bool CanStart()
        {
            // Free start is always available
            return true;
        }
        
        public Task<bool> ExecuteAsync()
        {
            Debug.Log("[FreeStartStrategy] Starting puzzle for free");
            return Task.FromResult(true);
        }
    }
}
