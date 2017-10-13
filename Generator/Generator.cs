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

        public ObservableCollection<Question> AddQuestions { get; set; } = new ObservableCollection<Question>();

        public void GenerateAdditionQuestions()
        {
            AddQuestions.Clear();

            for (int i = 0; i < Config.QuestionCount; i++)
            {
                var a = _rand.Next(AdditionMax);
                var b = _rand.Next(a);
                AddQuestions.Add(new Question(a, b, ArithmeticType.Add));
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
    }
}
