using System;
using Sirenix.OdinInspector;
using Sources.Texts.Domain;
using Sources.Utils.Dictionaries;

namespace Sources.Core.Domain.Dictionaries
{
    [Serializable] [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine)]
    public class PhraseSerializedDictionary : SerializedDictionary<LocalizationId, LocalizationPhraseClass>
    {
    }
}