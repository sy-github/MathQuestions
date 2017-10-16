using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiYing.MathQuestions.FrontEnd
{
    public class QuestionItemViewModel
    {
        public enum ItemStatus { Unanswered, Wrong, Right }

        public string Text { get; set; }
        public int CorrectAnswer { get; set; }
        public int? AttemptedAnswer { get; set; } = null;
        public ItemStatus Status { get; set; } = ItemStatus.Unanswered;

        public QuestionItemViewModel(Question q)
        {
            Text = q.ToString();
            CorrectAnswer = q.Answer;
        }

        public void CheckAnswer()
        {
            if (AttemptedAnswer != null)
                Status = AttemptedAnswer == CorrectAnswer ? ItemStatus.Right : ItemStatus.Wrong;
            else
                Status = ItemStatus.Unanswered;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
