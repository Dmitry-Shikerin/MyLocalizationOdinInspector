using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sources.Core.Domain.Constants;
using Sources.Core.Presentation.CommonTypes;
using Sources.MVPPassiveView.Presentations.Implementation.Views;
using Sources.Texts.Presentations.Implementation;
using Sources.Texts.Presentations.Interfaces;
using Sources.Texts.Presentations.Types;
using UnityEngine;

namespace Sources.Collectors
{
    public class UiCollector : View
    {
        [DisplayAsString(false)] [HideLabel] [Indent(8)]
        [SerializeField] private string _lebel = UiConstant.UiCollectorLabel;
        
        [TabGroup("Tab1", "Texts", true, 1)] 
        [SerializeField] private List<UiLocalizationText> _uiTexts;

        [TabGroup("Tab1", "Texts", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeTexts = Enable.Enable;
        
        [TabGroup("Tab1", "Texts", true, 1)] 
        [EnumToggleButtons] [UsedImplicitly]
        [SerializeField] private Enable _testLocalization = Enable.Enable; 
        
        [TabGroup("Tab1", "Texts", true, 1)] 
        [EnumToggleButtons] [EnableIf("_testLocalization", Enable.Enable)]
        [SerializeField] private Localization _localization;
        
        [TabGroup("Tab1", "AudioSources", true, 1)] 
        [EnumToggleButtons] [HideLabel] [LabelText("IncludeInactive", SdfIconType.Search)]
        [SerializeField] private Enable _includeAudioSources = Enable.Enable;
        
        private bool IncludeTexts => _includeTexts == Enable.Enable;
        private bool IncludeAudioSources => _includeAudioSources == Enable.Enable;

        public Localization Localization => _localization;
        public IReadOnlyList<IUiLocalizationText> UiTexts => _uiTexts;
        
        [TabGroup("Tab1","Texts", true, 1)] 
        [Button(ButtonSizes.Large)] 
        private void AddTexts() =>
            _uiTexts = GetComponentsInChildren<UiLocalizationText>(IncludeTexts).ToList();

        [TabGroup("Tab1","Texts", true, 1)] 
        [Button(ButtonSizes.Medium)] 
        private void ClearTexts() =>
            _uiTexts.Clear();
    }
}