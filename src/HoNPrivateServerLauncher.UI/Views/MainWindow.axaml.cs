using Avalonia.Controls;
using Avalonia.ReactiveUI;
using HoNPrivateServerLauncher.UI.ViewModels;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace HoNPrivateServerLauncher.UI.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(ShowDialog)));
        }

        private async Task ShowDialog(InteractionContext<ModalDialogViewModel, Unit> interaction)
        {
            var dialog = new ModalDialog();
            dialog.DataContext = interaction.Input;

            var _ = await dialog.ShowDialog<ModalDialogViewModel>(this);
            interaction.SetOutput(Unit.Default);
        }
    }
}
