using System;
using Sirenix.OdinInspector;
using Sources.MVPPassiveView.Presentations.Implementation.Views;
using Sources.MVPPassiveView.Presentations.Interfaces.PresentationsInterfaces.UI.Texts;
using TMPro;
using UnityEngine;

namespace Sources.MVPPassiveView.Presentations.Implementation.UI.Texts
{
    public class TextView : View, ITextView
    {
        [SerializeField] private TextMeshProUGUI _tmpText;
        
        public bool IsHide { get; private set; }

        private void Awake()
        {
            if (_tmpText == null)
                throw new NullReferenceException(nameof(gameObject.name));
        }

        public void SetText(string text) =>
            _tmpText.text = text;

        public void SetTextColor(Color color) =>
            _tmpText.color = color;

        public void SetIsHide(bool isHide) =>
            IsHide = isHide;

        public void Enable() =>
            _tmpText.enabled = true;

        public void Disable() =>
            _tmpText.enabled = false;
        
        [OnInspectorGUI]
        public void SetTmpText() =>
            _tmpText = GetComponent<TextMeshProUGUI>();
    }
}