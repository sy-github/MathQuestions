using System;
using System.Collections.Generic;
using System.Text;

namespace ShiYing.MathQuestions
{
    public class QuestionsGeneratedEventArgs : EventArgs
    {
        public ArithmeticType Type { get; set; }
        public List<Question> QuestionList { get; set; }
    }

    public partial class Generator
    {
        public event EventHandler<QuestionsGeneratedEventArgs> QuestionsGenerated;

        private void OnQuestionsGenerated(QuestionsGeneratedEventArgs e) => QuestionsGenerated?.Invoke(this, e);
    }
}
