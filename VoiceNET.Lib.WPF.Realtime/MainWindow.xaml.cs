using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace VoiceNET.Lib.WPF.Realtime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml - VoiceNET Library support WPF
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public DispatcherTimer tmGetResult = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            //VoiceNET Library support WPF from v1.0.5 - Auto choose microphone default - can't custom - use .setVolume to set volume

            tmGetResult.Interval = TimeSpan.FromSeconds(1);

            tmGetResult.Tick += tmGetResult_Tick;

            VBuilder.ModelPath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\SampleModel\MLModel.zip");

            if (VBuilder.loadModel())
            {

                tmGetResult.Start();

                VSpeech.WPFListener();

            }

        }

        void tmGetResult_Tick(object sender, EventArgs e)
        {
            lbResult.Content = VSpeech.WPFGetResult;
        }

    }
}
