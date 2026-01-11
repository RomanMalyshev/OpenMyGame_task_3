using System;
using System.Collections.Generic;
using Core.Base;
using Data.Models;
using UnityEngine;

namespace Features.Gallery
{
    public class GalleryView : BaseView, IGalleryView
    {
        [Header("References")]
        [SerializeField] private Transform _contentContainer;
        [SerializeField] private PuzzlePreviewItem _puzzlePreviewPrefab;

        private readonly Dictionary<string, PuzzlePreviewItem> _previewItems = new Dictionary<string, PuzzlePreviewItem>();

        public event Action<string> OnPuzzleClicked;

        public void SetPuzzlePreview(string puzzleId, Sprite sprite)
        {
            if (_previewItems.TryGetValue(puzzleId, out var item))
            {
                item.SetPreview(sprite);
            }
        }
        
        public void InitializePuzzles(IReadOnlyList<PuzzleData> puzzles)
        {
            ClearPreviews();
            
            foreach (var puzzle in puzzles)
            {
                CreatePreviewItem(puzzle);
            }
        }

        private void CreatePreviewItem(PuzzleData puzzleData)
        {
            if (_puzzlePreviewPrefab == null || _contentContainer == null)
            {
                Debug.LogError("[GalleryView] Prefab or content container is not assigned!");
                return;
            }
            
            var item = Instantiate(_puzzlePreviewPrefab, _contentContainer);
            item.Initialize(puzzleData.Id, puzzleData.Name, puzzleData.PreviewSprite);
            item.OnClicked += HandleItemClicked;
            
            _previewItems[puzzleData.Id] = item;
        }
        
        private void ClearPreviews()
        {
            foreach (var item in _previewItems.Values)
            {
                if (item != null)
                {
                    item.OnClicked -= HandleItemClicked;
                    Destroy(item.gameObject);
                }
            }
            _previewItems.Clear();
        }
        
        private void HandleItemClicked(string puzzleId)
        {
            OnPuzzleClicked?.Invoke(puzzleId);
        }

        private void OnDestroy()
        {
            ClearPreviews();
        }
    }
}
