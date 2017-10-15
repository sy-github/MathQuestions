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

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _app.Generator.GenerateAdditionQuestions();
        }

        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            _app.Generator.GenerateSubtractionQuestions();
        }

        private void ButtonMul_Click(object sender, RoutedEventArgs e)
        {
            _app.Generator.GenerateMultiplicationQuestions();
        }

        private void ButtonDiv_Click(object sender, RoutedEventArgs e)
        {
            _app.Generator.GenerateDivisionQuestions();
        }

        #endregion
    }
}
