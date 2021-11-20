using Lab05.View;
using System.Windows;

namespace Lab05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dialog_Click(object sender, RoutedEventArgs args)
        {
            Window w = new PlumbingDialog();
            w.Show();
        }
    }
}
