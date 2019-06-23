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

        public static int FindDigit(string str)
        {
            string a=string.Empty;
		    string b=string.Empty;
		    string c=string.Empty;
		    int j=0,k=0,l=0,i,ai,bi,ci,z=0;
			int len=str.Length;
		    for(i=0;i<len;i++)
		    {
		        if(z==0)
		        {
					if(str[i]!='*')
		            a+=str[i];
		        }
		        else if(z==1)
		        {
					if(str[i]!='=')
		            b+=str[i];
		        }
		        else if(z==2)
		        {
		            c+=str[i];
		        }
		        if(str[i]=='*')
		        {
		           j=i;
		           z++;
		        }
		        else if(str[i]=='?')
		        {
		            l=i;
		        }
		        else if(str[i]=='=')
		        {
		            k=i;
		            z++;
		        }
		    }
		
		        if(l<j)
		    {
		        bi=Convert.ToInt32(b);
		        ci=Convert.ToInt32(c);
		        for(i=0;i<10;i++)
		        {
					string s=string.Empty;
		            if(a[0]=='?'&&i==0)
		              continue;
		            foreach(char x in a)
					{
						if(x!='?')
						s+=x;
						else
							s+=i;
					}
					ai=Convert.ToInt32(s);
					if(ai*bi==ci)
		             return i;
		        }
		        return -1;
		    }
		    else if(l>k)
		    {
		         bi=Convert.ToInt32(b);
		         ai=Convert.ToInt32(a);
		        for(i=0;i<10;i++)
		        {
					string s=string.Empty;
		            if(c[0]=='?'&&i==0)
		              continue;
		            foreach(char x in c)
					{
						if(x!='?')
						s+=x;
						else
							s+=i;
					}
					ci=Convert.ToInt32(s);
					if(ai*bi==ci)
		             return i;
		        }
		        return -1;
		    }
		    else
		    {
		         ci=Convert.ToInt32(c);
		         ai=Convert.ToInt32(a);
		        for(i=0;i<10;i++)
		        {
					string s=string.Empty;
		            if(b[0]=='?'&&i==0)
		              continue;
		            foreach(char x in b)
					{
						if(x!='?')
						s+=x;
						else
							s+=i;
					}
					bi=Convert.ToInt32(s);
		           	if(ai*bi==ci)
		             return i;
		        }
		        return -1;   
		    }            
            throw new NotImplementedException();
        }
    }
}
