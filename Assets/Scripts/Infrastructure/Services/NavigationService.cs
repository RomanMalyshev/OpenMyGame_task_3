using System;
using System.Collections.Generic;
using Features.Gallery;
using Features.PuzzlePreview;
using UnityEngine;

namespace Infrastructure.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IGalleryView _galleryView;
        private readonly IPuzzleView _puzzleView;
        private readonly Stack<Action> _navigationHistory;
        
        public event Action<string> OnNavigateToPuzzle;

        public NavigationService(IGalleryView galleryView, IPuzzleView puzzleView)
        {
            _galleryView = galleryView;
            _puzzleView = puzzleView;
            _navigationHistory = new Stack<Action>();
        }

        public void ShowGallery()
        {
            HideAllScreens();
            _galleryView.Show();
            _navigationHistory.Clear();
        }
        
        public void ShowPuzzle(string puzzleId)
        {
            _navigationHistory.Push(ShowGallery);
            
            HideAllScreens();
            _puzzleView.Show();
            
            OnNavigateToPuzzle?.Invoke(puzzleId);
        }
        
        public void GoBack()
        {
            if (_navigationHistory.Count > 0)
            {
                var previousScreen = _navigationHistory.Pop();
                previousScreen?.Invoke();
            }
            else
            {
                Debug.LogWarning("[NavigationService] No navigation history to go back");
            }
        }

        private void HideAllScreens()
        {
            _galleryView.Hide();
            _puzzleView.Hide();
        }
    }
}
