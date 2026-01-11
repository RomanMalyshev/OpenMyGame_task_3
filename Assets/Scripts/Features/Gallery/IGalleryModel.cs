using System.Collections.Generic;
using Core.Interfaces;

namespace Features.Gallery
{
    public interface IGalleryModel : IModel
    {
        IReadOnlyList<string> PuzzleIds { get; }
    }
}
