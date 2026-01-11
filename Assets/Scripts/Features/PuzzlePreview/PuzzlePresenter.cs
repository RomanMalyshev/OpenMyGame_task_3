using Core.Interfaces;
using Features.PuzzlePreview.StartStrategies;
using Infrastructure.Services;
using UnityEngine;

namespace Features.PuzzlePreview
{
    public class PuzzlePresenter : IPresenter
    {
        private readonly IPuzzleView _view;
        private readonly IPuzzleModel _model;
        private readonly INavigationService _navigationService;
        private readonly IAssetProvider _assetProvider;
        private readonly StartStrategyFactory _startStrategyFactory;
        
        private IStartStrategy _currentStartStrategy;
        private bool _isDisposed;
        
        public PuzzlePresenter(
            IPuzzleView view,
            IPuzzleModel model,
            INavigationService navigationService,
            IAssetProvider assetProvider,
            StartStrategyFactory startStrategyFactory)
        {
            _view = view;
            _model = model;
            _navigationService = navigationService;
            _assetProvider = assetProvider;
            _startStrategyFactory = startStrategyFactory;
        }
        
        public void Initialize()
        {
            SubscribeToEvents();
            InitializeStartStrategy();
        }
        
        public void Dispose()
        {
            if (_isDisposed) return;
            
            UnsubscribeFromEvents();
            _isDisposed = true;
        }

        private async void LoadPuzzle(string puzzleId)
        {
            var puzzleData = _assetProvider.GetPuzzleById(puzzleId);
            if (puzzleData == null)
            {
                Debug.LogError($"[PuzzlePresenter] Puzzle not found: {puzzleId}");
                return;
            }
            
            _model.Initialize(puzzleData);
            
            _currentStartStrategy = _startStrategyFactory.SetStrategy(_model.StartType);
            
            var sprite = await _assetProvider.GetImageAsync(puzzleId);
            _view.SetPuzzlePreview(sprite, puzzleData.Name);
            _view.SetCutOptions(_model.CutOptions, _model.SelectedCutIndex);
            _view.SetStartButton(_currentStartStrategy.ButtonText);
        }
        
        private void SubscribeToEvents()
        {
            _view.OnBackClicked += HandleBackClicked;
            _view.OnStartClicked += HandleStartClicked;
            _view.OnCutOptionSelected += HandleCutOptionSelected;
            _navigationService.OnNavigateToPuzzle += LoadPuzzle;
        }
        
        private void UnsubscribeFromEvents()
        {
            _view.OnBackClicked -= HandleBackClicked;
            _view.OnStartClicked -= HandleStartClicked;
            _view.OnCutOptionSelected -= HandleCutOptionSelected;
            _navigationService.OnNavigateToPuzzle -= LoadPuzzle;
        }
        
        private void InitializeStartStrategy()
        {
            _currentStartStrategy = _startStrategyFactory.SetStrategy(_model.StartType);
        }
        
        private void HandleBackClicked()
        {
            _navigationService.GoBack();
        }
        
        private async void HandleStartClicked()
        {
            if (!_currentStartStrategy.CanStart())
            {
                Debug.LogWarning("[PuzzlePresenter] Cannot start - strategy conditions not met");
                return;
            }
            
            var success = await _currentStartStrategy.ExecuteAsync();
            
            if (success)
            {
                StartPuzzle();
            }
            else
            {
                Debug.LogWarning("[PuzzlePresenter] Start strategy execution failed");
            }
        }
        
        private void HandleCutOptionSelected(int index)
        {
            _model.SelectCutOption(index);
            _view.SetSelectedCutOption(index);
        }
        
        private void StartPuzzle()
        {
            Debug.Log($"[PuzzlePresenter] Starting puzzle '{_model.PuzzleId}'");
        }
    }
}
