using System;
using System.Collections.Generic;
using Core.Interfaces;
using Data.Models;
using UnityEngine;

namespace Features.Gallery
{
    public interface IGalleryView : IView
    {
        event Action<string> OnPuzzleClicked;
        void SetPuzzlePreview(string puzzleId, Sprite sprite);
        void InitializePuzzles(IReadOnlyList<PuzzleData> puzzles);
    }
}
