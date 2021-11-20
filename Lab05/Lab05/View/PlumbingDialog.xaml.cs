using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab05.View
{
    /// <summary>
    /// Interaction logic for PlumbingDialog.xaml
    /// </summary>
    public partial class PlumbingDialog : Window
    {
        SoundPlayer player;
        public PlumbingDialog()
        {
            InitializeComponent();

            const string fileName = "music.wav";
            const string path = "Resources.Sounds";
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", assembly.GetName().Name, path, fileName));
            player = new SoundPlayer(stream);
            player.Play();
        }

        protected override void OnClosed(EventArgs e)
        {
            player.Stop();
            Close();
        }
    }
}
