using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace PrismDialogServiceSample.ViewModels
{
    public class DialogAViewModel : BindableBase, IDialogAware
    {
        private string title;
        private string message;
        private DelegateCommand closeCommand;

        public DialogAViewModel()
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

        public DelegateCommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new DelegateCommand(ExecuteCloseCommand);
                return closeCommand;
            }
        }

        private void ExecuteCloseCommand()
        {
            var parameters = new DialogParameters
            {
                {"resultMessage", "Closed with close command"}
            };

            RequestClose(new DialogResult(ButtonResult.Cancel, parameters));
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
