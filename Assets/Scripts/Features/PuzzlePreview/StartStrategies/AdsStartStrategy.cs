using System.Threading.Tasks;
using Data.Models;

namespace Features.PuzzlePreview.StartStrategies
{
    public class AdsStartStrategy : IStartStrategy
    {
        public StartType Type => StartType.Ads;
        
        public string ButtonText => "Смотреть рекламу";

        public bool CanStart()
        {
            // For demo, always return true
            return true;
        }
        
        public async Task<bool> ExecuteAsync()
        {
            // For demo, simulate ad viewing with delay
            await Task.Delay(1000); // Simulate ad duration
            return true;
        }
    }
}
