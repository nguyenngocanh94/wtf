using Caliburn.Micro;
using ControlzEx.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpfclient.Common;

namespace wpfclient
{
    class Bootstrapper : BootstrapperBase
    {
        private CompositionContainer compositionContainer;

        public Bootstrapper()
        {
            Initialize();
        }

        static Bootstrapper()
        {
            Logger.GetLog = () => log4net.LogManager.GetLogger("Application");
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = compositionContainer.GetExportedValue<ViewModels.SplashScreenViewModel>();
            var windowManager = IoC.Get<IWindowManager>();

        }
    }
}
