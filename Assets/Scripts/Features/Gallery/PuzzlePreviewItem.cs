using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Gallery
{
    public class PuzzlePreviewItem : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Image _previewImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Button _button;

        private string _puzzleId;
        public event Action<string> OnClicked;
        public void Initialize(string puzzleId, string puzzleName, Sprite previewSprite)
        {
            _puzzleId = puzzleId;
            
            if (_nameText != null)
            {
                _nameText.text = puzzleName;
            }
            
            SetPreview(previewSprite);
        }
        
        public void SetPreview(Sprite sprite)
        {
            if (_previewImage != null && sprite != null)
            {
                _previewImage.sprite = sprite;
            }
        }

        private void Awake()
        {
            if (_button != null)
            {
                _button.onClick.AddListener(HandleButtonClick);
            }
        }
        
        private void OnDestroy()
        {
            if (_button != null)
            {
                _button.onClick.RemoveListener(HandleButtonClick);
            }
        }

        private void HandleButtonClick()
        {
            OnClicked?.Invoke(_puzzleId);
        }
    }
}
