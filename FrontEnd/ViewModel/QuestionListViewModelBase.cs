using System.Collections.ObjectModel;

namespace ShiYing.MathQuestions.FrontEnd
{
    using ShiYing.Utility;
    using ObservableQuestionList = ObservableCollection<QuestionItemViewModel>;

    public class QuestionListViewModelBase : PropertyChangeNotifier
    {
        protected QuestionListViewModelBase(QuestionEnumType t)
        {
            QuestionType = t;
            _generator.QuestionsGenerated += Generator_QuestionsGenerated;
        }

        public QuestionEnumType QuestionType { get; }

        public ObservableQuestionList QuestionList { get; } = new ObservableQuestionList();

        #region Notifiable property

        private bool _isCorrectAnswerVisible = false;

        public bool IsCorrectAnswerVisible
        {
            get => _isCorrectAnswerVisible;
            set => SetPropertyValue(ref _isCorrectAnswerVisible, value, nameof(IsCorrectAnswerVisible));
        }

        internal void ShowAnswer()
        {
            IsCorrectAnswerVisible = true;
        }

        #endregion

        public void GenerateQuestions() => _generator.GenerateQuestions((ArithmeticType)QuestionType);

        #region Private field

        private Generator _generator = Generator.Instance;

        #endregion

        #region Private method

        private void Generator_QuestionsGenerated(object sender, QuestionsGeneratedEventArgs e)
        {
            if (e.Type == (ArithmeticType)QuestionType) // only process own type
            {
                QuestionList.Clear();
                foreach (var item in e.QuestionList)
                {
                    QuestionList.Add(new QuestionItemViewModel(item));
                }
            }
        }

        #endregion
    }
}
