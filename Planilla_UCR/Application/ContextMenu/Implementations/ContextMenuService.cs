using System;

namespace Application.ContextMenu.Implementations
{
    public class ContextMenuService : IContextMenuService
    {
        public event Action? OnChange;
        public bool _showProjectsMenu { get; set; } = false;
        public string projectContext { get; set; }
        public string employerEmailContext { get; set; }
        public bool _showProjectsSubMenu { get; set; } = false;
        public bool _hoursEmployee { get; set; } = false;
        public string GetProjectsContext()
        {
            return projectContext;
        }

        public void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }  

        public void SetProjectsContext(bool showProjectsMenu, bool showProjectsSubMenu, string projectName, string employerEmail, bool hoursEmployee)
        {
            _showProjectsMenu = showProjectsMenu;
            _showProjectsSubMenu = showProjectsSubMenu;
            projectContext = projectName;
            employerEmailContext = employerEmail;
            _hoursEmployee = hoursEmployee;
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

        public string GetEmployerEmailContext()
        {
            return employerEmailContext;
        }

        public bool GetHoursEmployeeContext()
        {
            return _hoursEmployee;
        }
    }
}
