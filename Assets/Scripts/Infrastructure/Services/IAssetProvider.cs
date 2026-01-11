using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IAssetProvider
    {
        Task<Sprite> GetImageAsync(string puzzleId);
        IReadOnlyList<PuzzleData> GetAllPuzzles();
        PuzzleData GetPuzzleById(string puzzleId);
    }
}
