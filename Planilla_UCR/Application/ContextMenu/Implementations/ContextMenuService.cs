using System;

namespace Application.ContextMenu.Implementations
{
    public class ContextMenuService : IContextMenuService
    {
        public event Action? OnChange;

        public bool showProjectsMenu { get; set; } = false;
        public string projectContext { get; set; }

        public string GetProjectsContext()
        {
            return projectContext;
        }

        public void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }  

        public void SetProjectsContext(bool show, string projectName)
        {
            showProjectsMenu = show;
            projectContext = projectName;
            NotifyStateChanged();
        }

        public bool GetShowProjectsMenu()
        {
            return showProjectsMenu;
        }

        public void SetOnChange(Action action)
        {
            OnChange += action;
        }
    }
}
