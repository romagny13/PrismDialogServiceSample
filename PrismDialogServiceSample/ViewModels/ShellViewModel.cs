using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Prism.Unity.Ioc;
using PrismDialogServiceSample.Views;

namespace PrismDialogServiceSample.ViewModels
{

    public class ShellViewModel : BindableBase
    {
        private DelegateCommand showDialogCommand;
        private string resultMessage;
        private IDialogService dialogService;

        public ShellViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public string ResultMessage
        {
            get { return resultMessage; }
            set { SetProperty(ref resultMessage, value); }
        }

        public DelegateCommand ShowDialogCommand
        {
            get
            {
                if (showDialogCommand == null)
                    showDialogCommand = new DelegateCommand(ExecuteShowDialogCommand);
                return showDialogCommand;
            }
        }

        private void ExecuteShowDialogCommand()
        {
            var parameters = new DialogParameters
            {
                { "title", "My title" },
                { "message", "My message" }
            };

            dialogService.ShowDialog("MessageDialog", parameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    ResultMessage = r.Parameters.GetValue<string>("resultMessage");
                }
                else
                {
                    ResultMessage = "Not closed by user";
                }
            });
        }
    }

    // without boostrapper or prism application
    //public class ShellViewModel : BindableBase
    //{
    //    private DelegateCommand showDialogCommand;
    //    private UnityContainerExtension container;
    //    private string resultMessage;

    //    public ShellViewModel()
    //    {
    //        container = new UnityContainerExtension();

    //        // required
    //        container.RegisterInstance<IContainerExtension>(container);
    //        container.Register<IDialogWindow, DialogWindow>();
    //        container.Register<IDialogService, DialogService>();

    //        // dialog
    //        container.RegisterDialog<MessageDialog, MessageDialogViewModel>(); // for custom viewmodel or location
    //    }


    //    public string ResultMessage
    //    {
    //        get { return resultMessage; }
    //        set { SetProperty(ref resultMessage, value); }
    //    }

    //    public DelegateCommand ShowDialogCommand
    //    {
    //        get
    //        {
    //            if (showDialogCommand == null)
    //                showDialogCommand = new DelegateCommand(ExecuteShowDialogCommand);
    //            return showDialogCommand;
    //        }
    //    }

    //    private void ExecuteShowDialogCommand()
    //    {
    //        var parameters = new DialogParameters
    //        {
    //            { "title", "My title" },
    //            { "message", "My message" }
    //        };

    //        var dialogService = container.Resolve<IDialogService>();

    //        dialogService.ShowDialog("MessageDialog", parameters, r =>
    //        {
    //            if (r.Result == ButtonResult.OK)
    //            {
    //                ResultMessage = r.Parameters.GetValue<string>("resultMessage");
    //            }
    //            else
    //            {
    //                ResultMessage = "Not closed by user";
    //            }
    //        });
    //    }
    //}
}
