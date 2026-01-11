using Data.Config;
using Data.Models;
using UnityEngine;

namespace Features.PuzzlePreview.StartStrategies
{
    public class StartStrategyFactory
    {
        private readonly GameConfig _gameConfig;
        
        public StartStrategyFactory(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }
        
        public IStartStrategy SetStrategy(StartType startType)
        {
            return CreateStrategy(startType);
        }

        private IStartStrategy CreateStrategy(StartType startType)
        {
            switch (startType)
            {
                case StartType.Free:
                    return new FreeStartStrategy();
                    
                case StartType.Coins:
                    return new CoinsStartStrategy(_gameConfig.CoinsCost);
                    
                case StartType.Ads:
                    return new AdsStartStrategy();
                    
                default:
                    Debug.LogWarning($"[StartStrategyFactory] Unknown start type: {startType}, using Free");
                    return new FreeStartStrategy();
            }
        }
        
    }
}
