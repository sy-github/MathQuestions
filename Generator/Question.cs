using System;
using System.Collections.Generic;
using System.Text;

namespace ShiYing.MathQuestions
{
    public enum ArithmeticType { Add, Subtract, Multiply, Divide }

    public class Question
    {
        private ArithmeticType _type;
        private int _a;
        private int _b;

        public int Answer { get; set; }

        public Question(int a, int b, ArithmeticType type)
        {
            _type = type; _a = a; _b = b;
            switch (type)
            {
                case ArithmeticType.Add:
                    Answer = _a + _b;
                    break;
                case ArithmeticType.Subtract:
                    Answer = _a - _b;
                    break;
                case ArithmeticType.Multiply:
                    Answer = _a * _b;
                    break;
                case ArithmeticType.Divide:
                    Answer = _a / _b;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            var sign = _type == ArithmeticType.Add ? '+' : _type == ArithmeticType.Subtract ? '-' : _type == ArithmeticType.Multiply ? '×' : '÷';
            return $"{_a} {sign} {_b} = ";
        }
    }
}
