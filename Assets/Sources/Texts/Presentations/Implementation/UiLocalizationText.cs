using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sources.Core.Domain.Constants;
using Sources.Core.Presentation.CommonTypes;
using Sources.MVPPassiveView.Presentations.Implementation.Views;
using Sources.Texts.Domain;
using Sources.Texts.Presentations.Interfaces;
using TMPro;
using UnityEngine;

namespace Sources.Texts.Presentations.Implementation
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UiLocalizationText : View, IUiLocalizationText, ISelfValidator
    {
        [DisplayAsString(false)] [HideLabel] 
        [SerializeField] private string _label = UiConstant.UiLocalizationTextLabel;

        [TabGroup("GetId", "Translations")] [Space(10)]
        [ValueDropdown("GetDropdownValues")] [OnValueChanged("GetPhrase")]
        [SerializeField] private string _localizationId;
        [TabGroup("GetId", "Translations")] [EnumToggleButtons] [Space(10)]
        [SerializeField] private Enable _disableTexts = Core.Presentation.CommonTypes.Enable.Disable;
        [TabGroup("GetId", "Translations")] 
        [TextArea(1, 20)] [Space(10)] 
        [DisableIf("_disableTexts", Core.Presentation.CommonTypes.Enable.Disable)]
        [SerializeField] private string _russianText;
        [TabGroup("GetId", "Translations")] 
        [TextArea(1, 20)] [Space(10)]        
        [DisableIf("_disableTexts", Core.Presentation.CommonTypes.Enable.Disable)]
        [SerializeField] private string _englishText;
        [TabGroup("GetId", "Translations")] 
        [TextArea(1, 20)] [Space(10)]         
        [DisableIf("_disableTexts", Core.Presentation.CommonTypes.Enable.Disable)]
        [SerializeField] private string _turkishText;
        [Space(10)]
        [SerializeField] private TextMeshProUGUI _tmpText;

        public bool IsHide { get; private set; }
        public string Id => _localizationId;

        public void Validate(SelfValidationResult result)
        {
            if (string.IsNullOrWhiteSpace(_localizationId))
            {
                result.AddError($"Localization Id is empty {gameObject.name}");
            }
        }

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

        [UsedImplicitly]
        private List<string> GetDropdownValues() =>
            LocalizationDataBase.Instance.Phrases.Select(phrase => phrase.LocalizationId).ToList();

        [UsedImplicitly]
        private void GetPhrase()
        {
            var phrase = LocalizationDataBase.Instance.Phrases
                .FirstOrDefault(phrase => phrase.LocalizationId == _localizationId);

            if (phrase == null)
                return;
            
            _russianText = phrase.Russian;
            _englishText = phrase.English;
            _turkishText = phrase.Turkish;
        }

        [TabGroup("GetId", "Translations")]
        [ResponsiveButtonGroup("GetId/Translations/Get")] [UsedImplicitly]
        private void GetRussian() =>
            _tmpText.text = _russianText;

        [TabGroup("GetId", "Translations")]
        [ResponsiveButtonGroup("GetId/Translations/Get")] [UsedImplicitly]
        private void GetEnglish() =>
            _tmpText.text = _englishText;

        [TabGroup("GetId", "Translations")]
        [ResponsiveButtonGroup("GetId/Translations/Get")] [UsedImplicitly]
        private void GetTurkish() =>
            _tmpText.text = _turkishText;
    }
}