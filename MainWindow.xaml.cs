using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
using Image = System.Drawing.Image;

namespace ImageShower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Downloader dl;
        private Listener li;
        private string _url;

        public MainWindow()
        {
            InitializeComponent();
            dl = new Downloader();
            li = new Listener();
            li.StartListening();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!inputBox.Text.StartsWith("http"))
                {
                    inputBox.Text = "http://" + inputBox.Text;
                }
                try
                {
                    imageBox.Source = dl.DownloadImage(inputBox.Text).Image;
                    textBox.Content = _url;
                    ResizeWindow();
                }
                catch (Exception ex)
                {
                    textBox.Content = ex.Message;
                }
            }
        }

        private void ResizeWindow()
        {
            double h = imageBox.Source.Height + 10;
            double w = imageBox.Source.Width + 10;
            Application.Current.MainWindow.Height = h;
            Application.Current.MainWindow.Width = w;
        }
    }
}
