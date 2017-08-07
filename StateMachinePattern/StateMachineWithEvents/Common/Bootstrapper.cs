using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;
using Prism.Unity;

namespace StateMachineWithEvents.Common
{
    public class Bootstrapper : UnityBootstrapper
    {
        public Bootstrapper()
        {
            
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.TryResolve<MainWindow>();
        }

        protected override void InitializeShell()
        {

            base.InitializeShell();

            System.Windows.Application.Current.MainWindow = (Window)this.Shell;

            System.Windows.Application.Current.MainWindow.Show();

        }

        protected override void ConfigureModuleCatalog()

        {

            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;

            
            // moduleCatalog.AddModule(x);

            // moduleCatalog.AddModule(y);

            // moduleCatalog.AddModule(z);

        }

        protected override void ConfigureContainer()

        {

            // Container.RegisterInstance<>();

            base.ConfigureContainer();

        }
    }
}
