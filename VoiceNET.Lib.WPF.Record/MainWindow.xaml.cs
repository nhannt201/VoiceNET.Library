using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VoiceNET.Lib.WPF.Record
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml - Support WPF VoiceNET Library
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            VBuilder.ModelPath(AppDomain.CurrentDomain.BaseDirectory + @"\MLModel.zip");

            if (VBuilder.loadModel())

            {

                lbResult.Content = "Loaded!";

                btnStart.IsEnabled = true;

            }

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

            VBuilder.Record();

            btnStop.IsEnabled = true;

            btnStart.IsEnabled = false;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            VBuilder.Stop();

            lbResult.Content = VBuilder.Result(true);

            btnStart.IsEnabled = true;

            btnStop.IsEnabled = false;

        }
    }
}
