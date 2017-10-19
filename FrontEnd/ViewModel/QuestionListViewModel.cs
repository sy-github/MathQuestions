using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiYing.MathQuestions.FrontEnd
{
    public partial class QuestionListViewModel
    {
        Generator _generator = new Generator();

        public QuestionListViewModel()
        {
            _generator.QuestionsGenerated += Generator_QuestionsGenerated;
        }

        public bool IsCorrectAnswerVisible { get; set; } = false;

        public Dictionary<QuestionType, ObservableCollection<QuestionItemViewModel>> QuestionLists { get; set; } =
            new Dictionary<QuestionType, ObservableCollection<QuestionItemViewModel>>()
            {
                { QuestionType.Add, new ObservableCollection<QuestionItemViewModel>() },
                { QuestionType.Subtract, new ObservableCollection<QuestionItemViewModel>() },
                { QuestionType.Multiply, new ObservableCollection<QuestionItemViewModel>() },
                { QuestionType.Divide, new ObservableCollection<QuestionItemViewModel>() }
            };

        private void Generator_QuestionsGenerated(object sender, QuestionsGeneratedEventArgs e)
        {
            var list = QuestionLists[(QuestionType)e.Type];
            list.Clear();
            foreach (var item in e.QuestionList)
            {
                list.Add(new QuestionItemViewModel(item));
            }
        }

        public enum QuestionType { Add, Subtract, Multiply, Divide }
        public void GenerateQuestions(QuestionType t)
        {
            _generator.GenerateQuestions((ArithmeticType)t);
        }

        public void ToggleIsCorrectAnswerVisible() => IsCorrectAnswerVisible = !IsCorrectAnswerVisible;
    }
}
