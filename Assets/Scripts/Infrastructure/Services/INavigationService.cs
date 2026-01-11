using System;

namespace Infrastructure.Services
{
    public interface INavigationService
    {
        event Action<string> OnNavigateToPuzzle;
        void ShowGallery();
        void ShowPuzzle(string puzzleId);
        void GoBack();
    }
}
