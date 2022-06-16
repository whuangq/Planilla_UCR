using System;

namespace Application.ContextMenu.Implementations
{
    public class ContextMenuService : IContextMenuService
    {
        public event Action? OnChange;

        public bool _showProjectsMenu { get; set; } = false;
        public string projectContext { get; set; }
        public bool _showProjectsSubMenu { get; set; } = false;

        public string GetProjectsContext()
        {
            return projectContext;
        }

        public void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }  

        public void SetProjectsContext(bool showProjectsMenu, bool showProjectsSubMenu, string projectName)
        {
            _showProjectsMenu = showProjectsMenu;
            _showProjectsSubMenu = showProjectsSubMenu;
            projectContext = projectName;
            NotifyStateChanged();
        }

        public bool GetShowProjectsMenu()
        {
            return _showProjectsMenu;
        }

        public void SetOnChange(Action action)
        {
            OnChange += action;
        }

        public bool GetShowProjectsSubMenu()
        {
            return _showProjectsSubMenu;
        }
    }
}
