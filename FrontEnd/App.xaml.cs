using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShiYing.MathQuestions.FrontEnd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    partial class App : Application
    {
        public Generator Generator { get; } = new Generator();

        public Dictionary<ArithmeticType, ObservableCollection<QuestionItemViewModel>> QuestionLists { get; set; } =
            new Dictionary<ArithmeticType, ObservableCollection<QuestionItemViewModel>>()
            {
                { ArithmeticType.Add, new ObservableCollection<QuestionItemViewModel>() },
                { ArithmeticType.Subtract, new ObservableCollection<QuestionItemViewModel>() },
                { ArithmeticType.Multiply, new ObservableCollection<QuestionItemViewModel>() },
                { ArithmeticType.Divide, new ObservableCollection<QuestionItemViewModel>() }
            };

        public App()
        {
            Generator.QuestionsGenerated += Generator_QuestionsGenerated;
        }

        private void Generator_QuestionsGenerated(object sender, QuestionsGeneratedEventArgs e)
        {
            var list = QuestionLists[e.Type];
            list.Clear();
            foreach (var item in e.QuestionList)
            {
                list.Add(new QuestionItemViewModel(item));
            }
        }
    }
}
