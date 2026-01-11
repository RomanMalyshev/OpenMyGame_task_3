using System;
using System.Collections.Generic;
using Core.Interfaces;
using Data.Models;
using UnityEngine;

namespace Features.PuzzlePreview
{
    public interface IPuzzleView : IView
    {
        event Action OnBackClicked;
        event Action OnStartClicked;
        event Action<int> OnCutOptionSelected;

        void SetPuzzlePreview(Sprite sprite, string puzzleName);
        
        void SetCutOptions(IReadOnlyList<CutOption> cutOptions, int defaultIndex = 0);
        
        void SetStartButton(string buttonText);
        
        void SetSelectedCutOption(int index);
    }
}
