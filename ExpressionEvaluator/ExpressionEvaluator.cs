using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace ExpressionEvaluator {
    class Class1 {
        static void Main(string[] args) {
           Stack nums = new Stack();
           Stack ops = new Stack();
           string expression = "5 + 10 + 15 + 20";
           Calculate(nums, ops, expression);
           Console.WriteLine(nums.Pop());
           Console.Read();
        }
        // IsNumeric isn't built into C# so we must define it
        static bool IsNumeric(string input) {
            bool flag = true;

            string pattern = (@"^\d+$");
            Regex validate = new Regex(pattern);
            if (!validate.IsMatch(input)) {
                flag = false;
            }
            return flag;
        }
        static void Calculate(Stack N, Stack O, string exp) {
            string ch, token = "";
            for (int p = 0; p < exp.Length; p++) {
                ch = exp.Substring(p, 1);
                if (IsNumeric(ch))
                    token += ch;
                if (ch == " " || p == (exp.Length - 1)) {
                    if (IsNumeric(token)) {
                        N.Push(token);
                        token = "";
                    }
                } else if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
                    O.Push(ch);
                if (N.Count == 2)
                    Compute(N, O);
            }
        }
        static void Compute(Stack N, Stack O) {
            int oper1, oper2;
            string oper;
            oper1 = Convert.ToInt32(N.Pop());
            oper2 = Convert.ToInt32(N.Pop());
            oper = Convert.ToString(O.Pop());

            switch (oper) {
                case "+":
                    N.Push(oper1 + oper2);
                    break;
                case "-":
                    N.Push(oper1 - oper2);
                    break;
                case "*":
                    N.Push(oper1 * oper2);
                    break;
                case "/":
                    N.Push(oper1 / oper2);
                    break;
            }
        }
    }
}

