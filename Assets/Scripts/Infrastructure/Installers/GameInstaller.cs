using Data.Config;
using Features.Gallery;
using Features.PuzzlePreview;
using Features.PuzzlePreview.StartStrategies;
using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Configuration")]
        [SerializeField] private GameConfig _gameConfig;
        
        [Header("Views")]
        [SerializeField] private GalleryView _galleryView;
        [SerializeField] private PuzzleView _puzzleView;
        
        public override void InstallBindings()
        {
            InstallConfiguration();
            InstallServices();
            InstallGalleryModule();
            InstallPuzzleModule();
        }
        
        private void InstallConfiguration()
        {
            Container.Bind<GameConfig>()
                .FromInstance(_gameConfig)
                .AsSingle();
        }
        
        private void InstallServices()
        {
            Container.Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
            
            Container.Bind<INavigationService>()
                .To<NavigationService>()
                .AsSingle();
            
            Container.Bind<StartStrategyFactory>()
                .AsSingle();
        }
        
        private void InstallGalleryModule()
        {
            Container.Bind<IGalleryView>()
                .FromInstance(_galleryView)
                .AsSingle();
            
            Container.Bind<IGalleryModel>()
                .To<GalleryModel>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<GalleryPresenter>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InstallPuzzleModule()
        {
            Container.Bind<IPuzzleView>()
                .FromInstance(_puzzleView)
                .AsSingle();
            
            Container.Bind<IPuzzleModel>()
                .To<PuzzleModel>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<PuzzlePresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}
