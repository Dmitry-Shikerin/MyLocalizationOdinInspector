using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Texts.Domain
{
    [Serializable]
    public class LocalizationId
    {
        [ValueDropdown("GetDropdownValues")] [HideLabel]
        [SerializeField] private string _localizationId;
        
        public string Id => _localizationId;
        
        // private IEnumerable<string> GetDropdownValues() =>
        //     LocalizationDataBase.Instance.LocalizationIds;
    }
}