using Features.Gallery;
using Features.PuzzlePreview;
using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameBootstrapper : MonoBehaviour
    {
        [Inject] private INavigationService _navigationService;
        [Inject] private GalleryPresenter _galleryPresenter;
        [Inject] private PuzzlePresenter _puzzlePresenter;

        private void Start()
        {
            InitializePresenters();
            ShowInitialScreen();
        }

        private void InitializePresenters()
        {
            _galleryPresenter.Initialize();
            _puzzlePresenter.Initialize();
        }
        
        private void ShowInitialScreen()
        {
            _navigationService.ShowGallery();
        }
    }
}
