using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShiYing.MathQuestions.FrontEnd
{
    using QuestionType = QuestionListViewModel.QuestionType;

    public class ViewModelCommand : ICommand
    {
        private readonly Action<QuestionType> _action;
        public ViewModelCommand(Action<QuestionType> a) => _action = a;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _action((QuestionType)parameter);
    }

    public class ViewModelSimpleCommand : ICommand
    {
        private readonly Action _action;
        public ViewModelSimpleCommand(Action a) => _action = a;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _action();
    }

    public partial class QuestionListViewModel
    {
        private ViewModelCommand _generateQuestionsCommand;
        public ViewModelCommand GenerateQuestionsCommand
        {
            get { return _generateQuestionsCommand ?? new ViewModelCommand(GenerateQuestions); }
            private set { _generateQuestionsCommand = value; }
        }

        private ViewModelSimpleCommand _showCorrectAnswerCommand;
        public ViewModelSimpleCommand ShowCorrectAnswerCommand
        {
            get { return _showCorrectAnswerCommand ?? new ViewModelSimpleCommand(ShowCorrectAnswer); }
            private set { _showCorrectAnswerCommand = value; }
        }

        private void ShowCorrectAnswer()
        {
            IsCorrectAnswerVisible = true;
        }
    }
}
