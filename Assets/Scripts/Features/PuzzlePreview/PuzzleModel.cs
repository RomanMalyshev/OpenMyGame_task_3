using System.Collections.Generic;
using Data.Config;
using Data.Models;
namespace Features.PuzzlePreview
{
    public class PuzzleModel : IPuzzleModel
    {
        private readonly GameConfig _gameConfig;
        private PuzzleData _puzzleData;
        private int _selectedCutIndex;
        private string _puzzleId;

        public string PuzzleId => _puzzleId;
        public CutOption SelectedCutOption => _gameConfig.CutOptions != null && _selectedCutIndex < _gameConfig.CutOptions.Count 
            ? _gameConfig.CutOptions[_selectedCutIndex] 
            : null;

        public int SelectedCutIndex => _selectedCutIndex;
        public IReadOnlyList<CutOption> CutOptions => _gameConfig.CutOptions;

        public StartType StartType => _puzzleData?.StartType ?? StartType.Free;
        
        public PuzzleModel(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            _selectedCutIndex = 0;
        }
        
        public void Initialize(PuzzleData puzzleData)
        {
            _puzzleData = puzzleData;
            _selectedCutIndex = 0;
        }
        
        public void SetPuzzleId(string puzzleId)
        {
            _puzzleId = puzzleId;
        }

        public void SelectCutOption(int index)
        {
            if (_gameConfig.CutOptions != null && index >= 0 && index < _gameConfig.CutOptions.Count)
            {
                _selectedCutIndex = index;
            }
        }
        
        // Placeholder for win condition logic
        public bool CheckWinCondition()
        {
            return false;
        }
    }
}
