using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiYing.MathQuestions
{
    public class GeneratorConfig
    {
        public bool Add_WithinTen = false;
    }

    public class Generator
    {
        private Random _rand = new Random();

        public GeneratorConfig Config { get; set; }

        public IEnumerable<string> GetAdditionQuestions()
        {
            int maxInt = 100;
            const int count = 50;

            var list = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var a = _rand.Next(maxInt);
                var b = _rand.Next(maxInt);

                list.Add(string.Format("{0} + {1} = ", a, b));
            }

            return list.Distinct();
        }

        public IEnumerable<string> GetSubtractionQuestions()
        {
            int maxInt = 100;
            const int count = 50;

            var list = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var a = _rand.Next(maxInt);
                var b = _rand.Next(maxInt);

                if (a > b)
                    list.Add(string.Format("{0} - {1} = ", a, b));
                else
                    list.Add(string.Format("{0} - {1} = ", b, a));
            }

            return list.Distinct();
        }
    }
}
