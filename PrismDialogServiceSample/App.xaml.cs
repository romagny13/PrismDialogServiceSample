using Prism.Ioc;
using PrismDialogServiceSample.ViewModels;
using PrismDialogServiceSample.Views;
using System.Windows;

namespace PrismDialogServiceSample
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DialogA>();
            // or
            // containerRegistry.RegisterDialog<DialogA, DialogAViewModel>();
        }
    }
}
