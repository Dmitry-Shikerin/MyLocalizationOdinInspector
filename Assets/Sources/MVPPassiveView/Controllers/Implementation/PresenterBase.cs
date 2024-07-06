﻿using Sources.MVPPassiveView.Controllers.Interfaces.Presenters;

namespace Sources.MVPPassiveView.Controllers.Implementation
{
    public abstract class PresenterBase : IPresenter
    {
        public virtual void Initialize()
        {
        }

        public virtual void Enable()
        {
        }

        public virtual void Disable()
        {
        }

        public virtual void Destroy()
        {
        }
    }
}