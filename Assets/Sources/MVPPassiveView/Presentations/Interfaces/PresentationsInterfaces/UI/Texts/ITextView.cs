using Sources.MVPPassiveView.Controllers.Interfaces.ControllerLifetimes;
using UnityEngine;

namespace Sources.MVPPassiveView.Presentations.Interfaces.PresentationsInterfaces.UI.Texts
{
    public interface ITextView : IEnable, IDisable
    {
        bool IsHide { get; }
        
        void SetText(string text);
        void SetIsHide(bool isHide);
        void SetTextColor(Color color);
    }
}