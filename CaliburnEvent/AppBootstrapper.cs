using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using CaliburnEvent.ViewModels;

namespace CaliburnEvent
{
    public class AppBootstrapper : BootstrapperBase
    {
        private CompositionContainer container;
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<AppViewModel>();
        }
        protected override void Configure()
        {
            container = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x=>new AssemblyCatalog(x)).OfType<ComposablePartCatalog>() ));
            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(container);
            container.Compose(batch);
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = container.GetExportedValues<object>(contract);

            var exportList = exports as IList<object> ?? exports.ToList();
            if (exportList.Any())
            {
                return exportList.First();
            }

            throw new Exception($"Could not locate any instances of contract {contract}.");
        }
    }
}
