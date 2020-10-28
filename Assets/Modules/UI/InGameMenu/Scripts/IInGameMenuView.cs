using System;

namespace Game.UI
{
    public interface IInGameMenuView
    {
        event Action OnBackToMenuRequested;
    }
}