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

    public class Generator
    {
        private Random _rand = new Random();

        public GeneratorConfig Config { get; set; } = new GeneratorConfig();

        public int AdditionMax { get; set; } = 100;

        public ObservableCollection<Question> AdditionQuestions { get; set; } = new ObservableCollection<Question>();

        public void GenerateAdditionQuestions()
        {
            AdditionQuestions.Clear();

            for (int i = 0; i < Config.QuestionCount; i++)
            {
                var a = _rand.Next(AdditionMax);
                var b = _rand.Next(a);
                AdditionQuestions.Add(new Question(a, b, ArithmeticType.Add));
            }
        }

        public int SubtractionMax { get; set; } = 100;

        public ObservableCollection<Question> SubtractQuestions { get; set; } = new ObservableCollection<Question>();

        public void GenerateSubtractionQuestions()
        {
            SubtractQuestions.Clear();

            for (int i = 0; i < Config.QuestionCount; i++)
            {
                var a = _rand.Next(SubtractionMax);
                var b = _rand.Next(a);
                SubtractQuestions.Add(new Question(a, b, ArithmeticType.Subtract));
            }
        }

        public int MultiplicationMaxA { get; set; } = 20;

        public ObservableCollection<Question> MultiplicationQuestions { get; set; } = new ObservableCollection<Question>();

        public void GenerateMultiplicationQuestions()
        {
            MultiplicationQuestions.Clear();

            for (int i = 0; i < Config.QuestionCount; i++)
            {
                var a = _rand.Next(MultiplicationMaxA);
                var b = _rand.Next(Math.Min(10, a));
                MultiplicationQuestions.Add(new Question(a, b, ArithmeticType.Multiply));
            }
        }

        public int DivisionMaxA { get; set; } = 100;

        public ObservableCollection<Question> DivisionQuestions { get; set; } = new ObservableCollection<Question>();

        public void GenerateDivisionQuestions()
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
        }
    }
}
