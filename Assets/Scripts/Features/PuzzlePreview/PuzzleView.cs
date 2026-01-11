using System;
using System.Collections.Generic;
using Core.Base;
using Data.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.PuzzlePreview
{
    public class PuzzleView : BaseView, IPuzzleView
    {
        [Header("Preview")]
        [SerializeField] 
        private Image _previewImage;
        
        [SerializeField] 
        private TextMeshProUGUI _puzzleNameText;
        
        [Header("Cut Options")]
        [SerializeField] 
        private Transform _cutOptionsContainer;
        
        [SerializeField] 
        private CutOptionButton _cutOptionButtonPrefab;
        
        [Header("Buttons")]
        [SerializeField] 
        private Button _backButton;
        
        [SerializeField] 
        private Button _startButton;
        
        [SerializeField] 
        private TextMeshProUGUI _startButtonText;

        private readonly List<CutOptionButton> _cutOptionButtons = new List<CutOptionButton>();
        private int _selectedCutIndex;

        public event Action OnBackClicked;
        public event Action OnStartClicked;
        public event Action<int> OnCutOptionSelected;

        protected override void Awake()
        {
            base.Awake();
            
            if (_backButton != null)
            {
                _backButton.onClick.AddListener(HandleBackClick);
            }
            
            if (_startButton != null)
            {
                _startButton.onClick.AddListener(HandleStartClick);
            }
        }
        
        private void OnDestroy()
        {
            if (_backButton != null)
            {
                _backButton.onClick.RemoveListener(HandleBackClick);
            }
            
            if (_startButton != null)
            {
                _startButton.onClick.RemoveListener(HandleStartClick);
            }
            
            ClearCutOptions();
        }

        public void SetPuzzlePreview(Sprite sprite, string puzzleName)
        {
            if (_previewImage != null && sprite != null)
            {
                _previewImage.sprite = sprite;
            }
            
            if (_puzzleNameText != null)
            {
                _puzzleNameText.text = puzzleName;
            }
        }
        
        public void SetCutOptions(IReadOnlyList<CutOption> cutOptions, int defaultIndex = 0)
        {
            ClearCutOptions();
            
            if (_cutOptionButtonPrefab == null || _cutOptionsContainer == null)
            {
                Debug.LogError("PuzzleView: Cut option prefab or container not assigned!");
                return;
            }
            
            for (int i = 0; i < cutOptions.Count; i++)
            {
                var button = Instantiate(_cutOptionButtonPrefab, _cutOptionsContainer);
                var index = i; // Capture for closure
                button.Initialize(cutOptions[i], index, () => HandleCutOptionClick(index));
                _cutOptionButtons.Add(button);
            }
            
            SetSelectedCutOption(defaultIndex);
        }
        
        public void SetStartButton(string buttonText)
        {
            if (_startButtonText != null)
            {
                _startButtonText.text = buttonText;
            }
        }
        
        public void SetSelectedCutOption(int index)
        {
            _selectedCutIndex = index;
            
            for (int i = 0; i < _cutOptionButtons.Count; i++)
            {
                _cutOptionButtons[i].SetSelected(i == index);
            }
        }

        private void ClearCutOptions()
        {
            foreach (var button in _cutOptionButtons)
            {
                if (button != null)
                {
                    Destroy(button.gameObject);
                }
            }
            _cutOptionButtons.Clear();
        }
        
        private void HandleBackClick()
        {
            OnBackClicked?.Invoke();
        }
        
        private void HandleStartClick()
        {
            OnStartClicked?.Invoke();
        }
        
        private void HandleCutOptionClick(int index)
        {
            OnCutOptionSelected?.Invoke(index);
        }
    }
}
