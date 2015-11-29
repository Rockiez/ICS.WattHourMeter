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
using ICS.Common;
using ICS.Models;
using ICS.Acquisition;

namespace ICS.WattHourMeter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool no1state;
        bool no2state;

        private void No1_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var state = Global.ADAM4150Provider.CheckSerialPort(Global.ADAM4150Provider.ADAM4017Provider);
            if (state.Status == RunStatus.Success)
            {
                if (Global.ADAM4150Provider.OnOff( no1state ? ADAM4150FuncID.OffSocket1 : ADAM4150FuncID.OnSocket1 ))
                {
                    no1.Text = no1state ? "OFF" : "ON";
                    no1.Background = no1state ? Brushes.LightCoral : Brushes.CornflowerBlue;
                    no1state = !no1state;
                }
                else
                {
                    MessageBox.Show("The Operation is erron");
                }

            }
            else
            {
                MessageBox.Show(state.ResultMessage);
            }

        }

        private void No2_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var state = Global.ADAM4150Provider.CheckSerialPort(Global.ADAM4150Provider.ADAM4017Provider);
            if (state.Status == RunStatus.Success)
            {
      
                 if (Global.ADAM4150Provider.OnOff( no2state ? ADAM4150FuncID.OffSocket2 : ADAM4150FuncID.OnSocket2 ))
                {
                    no2.Text = no2state ? "OFF" : "ON";
                    no2.Background = no2state ? Brushes.LightCoral : Brushes.CornflowerBlue;
                    no2state = !no2state;
                }
                else
                {
                    MessageBox.Show("The Operation is erron");
                }

            }
            else
            {
                MessageBox.Show(state.ResultMessage);
            }

        }

        private void close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void min_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
