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
using System.Windows.Threading;

namespace ShiYing.MathQuestions.FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App _app = (App)App.Current;

        private TimeSpan _countdownAdd;
        private DispatcherTimer _timerAdd = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object o, EventArgs e) =>
        {
        }, App.Current.Dispatcher);

        public MainWindow() => InitializeComponent();

        #region Event Handlers

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            SetTextBoxContent(AddTextBox, _app.Generator.GetAdditionQuestions());

            _timerAdd.Tag = TimeSpan.FromMinutes(2);
            CountdownText.Text = ((TimeSpan)_timerAdd.Tag).ToString(@"mm\:ss");
            _timerAdd.Start();
        }

        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            SetTextBoxContent(SubTextBox, _app.Generator.GetSubtractionQuestions());
        }

        #endregion

        private void SetTextBoxContent(TextBox t, IEnumerable<string> lines)
        {
            t.Text = string.Empty;
            foreach (var line in lines)
                t.Text += line + '\n';
            t.ScrollToHome();
        }
    }
}
