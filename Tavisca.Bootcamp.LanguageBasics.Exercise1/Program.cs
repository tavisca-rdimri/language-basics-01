using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        
        public static int FindDigit(string expression)
        {
            string firstOperand=string.Empty;
		    string secondOperand = string.Empty;
		    string thirdOperand = string.Empty;
		    int multiplicationIndex=0, equalIndex = 0, questionIndex = 0,firstOperandInt,secondOperandInt,thirdOperandInt, operand=0;
		    for(int i=0;i< expression.Length; i++)
		    {
		        if(operand == 0)
		        {
					if(expression[i]!='*')
                        firstOperand += expression[i];
		        }
		        else if(operand == 1)
		        {
					if(expression[i]!='=')
                        secondOperand += expression[i];
		        }
		        else if(operand == 2)
		        {
                    thirdOperand += expression[i];
		        }
		        if(expression[i]=='*')
		        {
                    multiplicationIndex = i;
		            operand++;
		        }
		        else if(expression[i]=='?')
		        {
                    questionIndex = i;
		        }
		        else if(expression[i]=='=')
		        {
                    equalIndex = i;
		            operand++;
		        }
		    }

            if (questionIndex > equalIndex)
            {
                secondOperandInt = Convert.ToInt32(secondOperand);
                firstOperandInt = Convert.ToInt32(firstOperand);
                for (int i = 0; i < 10; i++)
                {
                    string thirdOperandTemporary = string.Empty;
                    if (thirdOperand[0] == '?' && i == 0)
                        continue;
                    foreach (char x in thirdOperand)
                    {
                        if (x != '?')
                            thirdOperandTemporary += x;
                        else
                            thirdOperandTemporary += i;
                    }
                    thirdOperandInt = Convert.ToInt32(thirdOperandTemporary);
                    if (firstOperandInt * secondOperandInt == thirdOperandInt)
                        return i;
                }
                return -1;
            }
            else
		    {
                if (questionIndex < multiplicationIndex)
                {
                    secondOperandInt = Convert.ToInt32(secondOperand);
                    thirdOperandInt = Convert.ToInt32(thirdOperand);
                }
                else
                {
                    secondOperandInt = Convert.ToInt32(firstOperand);
                    thirdOperandInt = Convert.ToInt32(thirdOperand);
                    firstOperand = secondOperand;
                }
		        for(int i=0;i<10;i++)
		        {
					string firstOperandTemporary = string.Empty;
		            if(firstOperand[0]=='?'&&i==0)
		              continue;
		            foreach(char x in firstOperand)
					{
						if(x!='?')
                            firstOperandTemporary += x;
						else
                            firstOperandTemporary += i;
					}
                    firstOperandInt= Convert.ToInt32(firstOperandTemporary);
					if(firstOperandInt * secondOperandInt == thirdOperand)
		             return i;
		        }
		        return -1;
		    }
            throw new NotImplementedException();
        }
    }
}
