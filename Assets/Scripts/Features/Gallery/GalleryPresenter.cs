using Core.Interfaces;
using Infrastructure.Services;

namespace Features.Gallery
{
    public class GalleryPresenter : IPresenter
    {
        private readonly IGalleryView _view;
        private readonly IGalleryModel _model;
        private readonly INavigationService _navigationService;
        private readonly IAssetProvider _assetProvider;
        
        private bool _isDisposed;

        public GalleryPresenter(
            IGalleryView view,
            IGalleryModel model,
            INavigationService navigationService,
            IAssetProvider assetProvider)
        {
            _view = view;
            _model = model;
            _navigationService = navigationService;
            _assetProvider = assetProvider;
        }

        public void Initialize()
        {
            SubscribeToEvents();
            LoadPuzzlePreviews();
        }
        
        public void Dispose()
        {
            if (_isDisposed) return;
            
            UnsubscribeFromEvents();
            _isDisposed = true;
        }

        private void SubscribeToEvents()
        {
            _view.OnPuzzleClicked += HandlePuzzleClicked;
        }
        
        private void UnsubscribeFromEvents()
        {
            _view.OnPuzzleClicked -= HandlePuzzleClicked;
        }
        
        private void LoadPuzzlePreviews()
        {
            var puzzles = _assetProvider.GetAllPuzzles();
            _view.InitializePuzzles(puzzles);
        }
        
        private void HandlePuzzleClicked(string puzzleId)
        {
            _navigationService.ShowPuzzle(puzzleId);
        }
    }
}
