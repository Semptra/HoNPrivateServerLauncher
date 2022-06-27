using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using HoNPrivateServerLanucher.UI;

namespace HoNPrivateServerLauncher.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly HoNServerClient _honServerClient = new HoNServerClient();
        private readonly HoNClient _honClient = new HoNClient();

        public string Login { get; set; }

        public string Password { get; set; }

        public bool SaveSettings { get; set; }

        public Interaction<ModalDialogViewModel, Unit> ShowDialog { get; }

        public ReactiveCommand<Unit, Unit> RegisterAccountCommand { get; }

        public ReactiveCommand<Unit, Unit> StartHoNCommand { get; }

        public MainWindowViewModel()
        {
            Login = string.Empty;
            Password = string.Empty;

            ShowDialog = new Interaction<ModalDialogViewModel, Unit>();

            RegisterAccountCommand = ReactiveCommand.CreateFromTask(RegisterAccount);
            StartHoNCommand = ReactiveCommand.CreateFromTask(StartHoN);
        }

        private async Task RegisterAccount()
        {
            var registerResult = await _honServerClient.Register(Login, Password);

            await ShowDialogInternal(registerResult.Content);
        }

        private async Task StartHoN()
        {
            var loginResult = await _honServerClient.Login(Login, Password);

            await ShowDialogInternal(loginResult.Content);

            _honClient.OpenHoN();
        }

        private async Task ShowDialogInternal(string message)
        {
            var dialogViewModel = new ModalDialogViewModel { Message = message };
            await ShowDialog.Handle(dialogViewModel);
        }
    }
}
