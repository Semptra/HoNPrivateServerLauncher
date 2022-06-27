using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HoNPrivateServerLauncher.UI.Views
{
    public partial class ModalDialog : Window
    {
        public ModalDialog()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
