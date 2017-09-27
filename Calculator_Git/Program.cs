using System;

namespace Calculator_Equals
{
    class Program
    {
        static void Main(string[] args)
        {
            string flag = "y";
            while (flag.Equals("y") || flag.Equals("Y"))
            {
                Calculator calculator = new Calculator();
                Console.WriteLine("第一行输入第一操作数，第二行输入第二操作数，第三行输入要执行的操作(+，-，*，/)：");
                string a = Console.ReadLine();
                calculator.A = a;
                string b = Console.ReadLine();
                calculator.B = b;
                string op = Console.ReadLine();
                Console.WriteLine("运算结果为：" + calculator.Calculate(op));
                Console.WriteLine("是否继续？（y或Y继续，其他键退出）");
                flag = Console.ReadLine();
            }
        }
    }
    class Calculator
    {
        int _a, _b;
        bool _statusA = true, _statusB = true;
        string _c, _d;
        public string A
        {
            set
            {
                try
                {
                    _a = int.Parse(value);
                }
                catch (FormatException e)
                {
                    _statusA = false;
                    _c = value;
                }
            }
        }
        public string B
        {
            set
            {
                try
                {
                    _b = int.Parse(value);
                }
                catch (FormatException e)
                {
                    _statusB = false;
                    _d = value;
                }
            }
        }

        public string Calculate(string op)
        {
            switch (op)
            {
                case "+":
                    if (_statusA && _statusB)
                    {
                        return (_a + _b) + "";
                    }
                    else if (_statusA && !_statusB)
                    {
                        _c = _a.ToString();
                        return (_c + _d).Replace("\"", "");
                    }
                    else if (!_statusA && _statusB)
                    {
                        _d = _b.ToString();
                        return (_c + _d).Replace("\"", "");
                    }
                    else
                    {
                        return (_c + _d).Replace("\"", "");
                    }
                case "-":
                    if (_statusA && _statusB)
                    {
                        return (_a - _b) + "";
                    }
                    else if (_statusA && !_statusB)
                    {
                        _c = _a.ToString();
                        return (_c.Replace(_d, "")).Replace("\"", "");
                    }
                    else if (!_statusA && _statusB)
                    {
                        _d = _b.ToString();
                        return (_c.Replace(_d, "")).Replace("\"", "");
                    }
                    else
                    {
                        return (_c.Replace(_d, "")).Replace("\"", "");
                    }
                case "*":
                    return (_a * _b) + "";
                case "/":
                    if (_b == 0)
                    {
                        return "运算出错：除数不能为0！";
                    }
                    else
                    {
                        return ((float)_a / (float)_b) + "";
                    }
                default:
                    return "运算出错：您输入了一个未知的运算符！";
            }
        }
    }
}
