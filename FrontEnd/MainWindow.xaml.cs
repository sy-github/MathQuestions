using System.Windows;

namespace ShiYing.MathQuestions.FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Event Handlers


        #endregion

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as QuestionListViewModel;
            vm.GenerateQuestions(QuestionListViewModel.QuestionType.Add);
        }
    }
}
