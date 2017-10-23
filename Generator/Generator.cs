using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShiYing.MathQuestions
{
    public class GeneratorConfig
    {
        public int QuestionCount { get; set; } = 20;
    }

    public partial class Generator
    {
        // Random generator shared in the entire Generator class
        private Random _rand = new Random();

        private Generator() { }

        private static Generator _generator;
        public static Generator Instance => _generator ?? (_generator = new Generator());

        public GeneratorConfig Config { get; set; } = new GeneratorConfig();

        public int AdditionMax { get; set; } = 100;

        private List<Question> AdditionQuestions { get; set; } = new List<Question>();

        public void GenerateQuestions(ArithmeticType t)
        {
            switch (t)
            {
                case ArithmeticType.Add:
                    GenerateAdditionQuestions();
                    break;
                case ArithmeticType.Subtract:
                    GenerateSubtractionQuestions();
                    break;
                case ArithmeticType.Multiply:
                    GenerateMultiplicationQuestions();
                    break;
                case ArithmeticType.Divide:
                    GenerateDivisionQuestions();
                    break;
                default:
                    break;
            }
        }

        private void GenerateAdditionQuestions()
        {
            AdditionQuestions.Clear();

            for (int i = 0; i < Config.QuestionCount; i++)
            {
                var a = _rand.Next(AdditionMax);
                var b = _rand.Next(a);
                AdditionQuestions.Add(new Question(a, b, ArithmeticType.Add));
            }

            OnQuestionsGenerated(new QuestionsGeneratedEventArgs { Type = ArithmeticType.Add, QuestionList = AdditionQuestions });
        }

        public int SubtractionMax { get; set; } = 100;

        public List<Question> SubtractQuestions { get; set; } = new List<Question>();

        private void GenerateSubtractionQuestions()
        {
            SubtractQuestions.Clear();

            for (int i = 0; i < Config.QuestionCount; i++)
            {
                var a = _rand.Next(SubtractionMax);
                var b = _rand.Next(a);
                SubtractQuestions.Add(new Question(a, b, ArithmeticType.Subtract));
            }

            OnQuestionsGenerated(new QuestionsGeneratedEventArgs { Type = ArithmeticType.Subtract, QuestionList = SubtractQuestions });
        }

        public int MultiplicationMaxA { get; set; } = 20;

        public List<Question> MultiplicationQuestions { get; set; } = new List<Question>();

        private void GenerateMultiplicationQuestions()
        {
            MultiplicationQuestions.Clear();

            for (int i = 0; i < Config.QuestionCount; i++)
            {
                var a = _rand.Next(MultiplicationMaxA);
                var b = _rand.Next(Math.Min(10, a));
                MultiplicationQuestions.Add(new Question(a, b, ArithmeticType.Multiply));
            }

            OnQuestionsGenerated(new QuestionsGeneratedEventArgs { Type = ArithmeticType.Multiply, QuestionList = MultiplicationQuestions });
        }

        public int DivisionMaxA { get; set; } = 100;

        public List<Question> DivisionQuestions { get; set; } = new List<Question>();

        private void GenerateDivisionQuestions()
        {
            DivisionQuestions.Clear();

            for (int i = 0; i < Config.QuestionCount; i++)
            {
                var a = _rand.Next(2, DivisionMaxA);
                var b = _rand.Next(2, Math.Min(10, a));

                if (a % b != 0)
                {
                    i--;
                    continue;
                }

                DivisionQuestions.Add(new Question(a, b, ArithmeticType.Divide));
            }

            OnQuestionsGenerated(new QuestionsGeneratedEventArgs { Type = ArithmeticType.Divide, QuestionList = DivisionQuestions });
        }
    }
}
