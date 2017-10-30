using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiYing.MathQuestions.FrontEnd
{
    using ShiYing.Utility;
    using ObservableQuestionList = ObservableCollection<QuestionItemViewModel>;

    public enum QuestionEnumType { Add, Subtract, Multiply, Divide }

    public class MainWindowViewModel
    {
        public CommandManager CommandManager { get; } = CommandManager.Instance;

        public MainWindowViewModel()
        {
            CommandManager.AddCommand("GenerateQuestions", new SimpleCommand<QuestionEnumType>()
            {
                ExecuteDelegate = GenerateQuestions
            });
            CommandManager.AddCommand("ShowAnswer", new SimpleCommand<QuestionEnumType>()
            {
                ExecuteDelegate = ShowAnswer
            });
        }

        private void ShowAnswer(QuestionEnumType t)
        {
            this[t].ShowAnswer();
        }

        private void GenerateQuestions(QuestionEnumType t)
        {
            this[t].GenerateQuestions();
            this[t].IsCorrectAnswerVisible = false;
        }

        public List<QuestionListViewModelBase> QuestionLists { get; } = new List<QuestionListViewModelBase>()
        {
            new QuestionListViewModel(QuestionEnumType.Add),
            new QuestionListViewModel(QuestionEnumType.Subtract),
            new QuestionListViewModel(QuestionEnumType.Multiply),
            new QuestionListViewModel(QuestionEnumType.Divide)
        };

        private QuestionListViewModelBase this[QuestionEnumType t] => QuestionLists.Find((q) => q.QuestionType == t);
    }
}
