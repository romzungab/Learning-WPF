using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace CaliburnWinManager.ViewModels
{
    [Export(typeof(AppViewModel))]
    public class AppViewModel: PropertyChangedBase, IHaveDisplayName
    {
        private readonly IWindowManager _window;
        [ImportingConstructor]
        public AppViewModel(IWindowManager window)
        {
            _window = window;
        }
        public string DisplayName { get; set; } = "Caliburn Micro Part 5: The Window Manager";

        public void OpenWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.Manual;

            _window.ShowWindow(new AppViewModel(_window), null, settings);
        }
    }

    public class MyWindow : WindowManager
    {
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            Window window = base.EnsureWindow(model, view, isDialog);
            window.SizeToContent = SizeToContent.Manual;
            window.Width = 300;
            window.Height = 400;
            return window;
        }
    }
}
