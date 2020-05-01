using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace PrismDialogServiceSample.ViewModels
{
    public class MessageDialogViewModel : BindableBase, IDialogAware
    {
        private string title;
        private string message;
        private DelegateCommand closeDialogCommand;

        public MessageDialogViewModel()
        {
            this.title = "Default title";
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public DelegateCommand CloseDialogCommand
        {
            get
            {
                if (closeDialogCommand == null)
                    closeDialogCommand = new DelegateCommand(ExecuteCloseCommand);
                return closeDialogCommand;
            }
        }

        private void ExecuteCloseCommand()
        {
            var parameters = new DialogParameters
            {
                {"resultMessage", "Closed with CloseDialogCommand" }
            };

            RequestClose(new DialogResult(ButtonResult.OK, parameters));
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            Console.WriteLine("The Demo Dialog has been closed...");
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            this.Title = parameters.GetValue<string>("title");
            this.Message = parameters.GetValue<string>("message");
        }
    }
}
