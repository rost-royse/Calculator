using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CalculatorASP.Controllers
{
    public class CalcController : ApiController
    {
        public double Post([FromBody] Expression exp)
        {
            var output = GetExpression(exp.Input);     
            var result = Counting(output);   
            return result;  
        }

        private bool IsDelimeter(char c)
        {
            if (" =".IndexOf(c) != -1)
                return true;
            return false;
        }

        private static bool IsOperator(char с)
        {
            if ("+-/*^()".IndexOf(с) != -1)
                return true;
            return false;
        }

        private static byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

        private double Counting(string input)
        {
            double result = 0; 
            var temp = new Stack<double>();    

            for (var i = 0; i < input.Length; i++)     
                if (char.IsDigit(input[i]))
                {
                    var a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))   
                    {
                        a += input[i]; 
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));   
                    i--;
                }
                else if (IsOperator(input[i]))    
                {
                    var a = temp.Pop();
                    var b = temp.Pop();

                    switch (input[i])       
                    {
                        case '+':
                            result = b + a;
                            break;
                        case '-':
                            result = b - a;
                            break;
                        case '*':
                            result = b * a;
                            break;
                        case '/':
                            result = b / a;
                            break;
                        case '^':
                            result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString()))
                                .ToString());
                            break;
                    }
                    temp.Push(result);      
                }
            return temp.Peek();         
        }

        private string GetExpression(string input)
        {
            var output = string.Empty;    
            var operStack = new Stack<char>();    

            for (var i = 0; i < input.Length; i++)      
            {
                if (IsDelimeter(input[i]))
                    continue;    

                if (char.IsDigit(input[i]))  
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];       
                        i++;    

                        if (i == input.Length) break;        
                    }

                    output += " ";        
                    i--;         
                }

                if (IsOperator(input[i]))  
                    if (input[i] == '(')     
                    {
                        operStack.Push(input[i]);    
                    }
                    else if (input[i] == ')')     
                    {
                        var s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else    
                    {
                        if (operStack.Count > 0)     
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())
                            )             
                                output += operStack.Pop() +
                                          " ";          

                        operStack.Push(char.Parse(input[i]
                            .ToString()));              
                    }
            }

            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;     
        }
    }

    public class Expression
    {
        public string Input { get; set; }
    }
}