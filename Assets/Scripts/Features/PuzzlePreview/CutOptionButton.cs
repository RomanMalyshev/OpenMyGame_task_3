using System;
using Data.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.PuzzlePreview
{
    public class CutOptionButton : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] 
        private Button _button;
        
        [SerializeField] 
        private TextMeshProUGUI _text;
        
        [SerializeField] 
        private Image _background;
        
        [Header("Colors")]
        [SerializeField] 
        private Color _normalColor = Color.white;
        
        [SerializeField] 
        private Color _selectedColor = new Color(0.3f, 0.7f, 1f);

        private int _index;
        private Action _onClickCallback;
        private bool _isSelected;

        public void Initialize(CutOption cutOption, int index, Action onClick)
        {
            _index = index;
            _onClickCallback = onClick;
            
            if (_text != null)
            {
                _text.text = cutOption.DisplayName;
            }
            
            if (_button != null)
            {
                _button.onClick.AddListener(HandleClick);
            }
            
            SetSelected(false);
        }
        
        public void SetSelected(bool isSelected)
        {
            _isSelected = isSelected;
            
            if (_background != null)
            {
                _background.color = isSelected ? _selectedColor : _normalColor;
            }
        }

        private void HandleClick()
        {
            _onClickCallback?.Invoke();
        }

        private void OnDestroy()
        {
            if (_button != null)
            {
                _button.onClick.RemoveListener(HandleClick);
            }
        }
    }
}
