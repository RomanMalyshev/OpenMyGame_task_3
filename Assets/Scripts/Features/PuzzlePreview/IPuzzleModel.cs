using System.Collections.Generic;
using Core.Interfaces;
using Data.Models;

namespace Features.PuzzlePreview
{
    public interface IPuzzleModel : IModel
    {
        string PuzzleId { get; }
        CutOption SelectedCutOption { get; }
        int SelectedCutIndex { get; }
        IReadOnlyList<CutOption> CutOptions { get; }
        StartType StartType { get; }
        void Initialize(PuzzleData puzzleData);
        void SelectCutOption(int index);
        bool CheckWinCondition();
    }
}
