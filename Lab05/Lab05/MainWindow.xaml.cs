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

            //const string fileName = "music.wav";
            //const string path = "Resources.Sounds";
            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //var stream = assembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", assembly.GetName().Name, path, fileName));
            //var player = new SoundPlayer(stream);
            //player.Play();
        }

        private void Dialog_Click(object sender, RoutedEventArgs args)
        {
            Window w = new PlumbingDialog();
            w.Show();
        }
    }
}
