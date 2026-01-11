using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services;

namespace Features.Gallery
{
    public class GalleryModel : IGalleryModel
    {
        private readonly List<string> _puzzleIds;

        public IReadOnlyList<string> PuzzleIds => _puzzleIds;

        public GalleryModel(IAssetProvider assetProvider)
        {
            var puzzles = assetProvider.GetAllPuzzles();
            _puzzleIds = puzzles.Select(p => p.Id).ToList();
        }
    }
}
