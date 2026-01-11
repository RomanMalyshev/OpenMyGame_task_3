using System.Threading.Tasks;
using Data.Models;

namespace Features.PuzzlePreview.StartStrategies
{
    public interface IStartStrategy
    {
        StartType Type { get; }
        string ButtonText { get; }
        bool CanStart();
        Task<bool> ExecuteAsync();
    }
}
