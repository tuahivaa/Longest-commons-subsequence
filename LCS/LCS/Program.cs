using System;
using System.IO;

namespace LCS
{
    class MainClass
    {



        public static void Main(string[] args)
        {

            try
            {
                //keep repeating to enter only one paramter
                if (args.Length == 1)
                {
                    StreamReader file = new StreamReader(args[0]);
                    string first = file.ReadLine();
                    string second = file.ReadLine();
                    Console.WriteLine("String X: "+ first );
                    Console.WriteLine("String Y: " + second );
                    //lcsLenght(first, second);

                    //declare as var just in case you don't know what type it is.
                    var c = LCS(first ,second);

                    Console.WriteLine("LCS: " + printLCS(c, first, second, first.Length, second.Length) );

                    for (int i=0; i< first.Length; i++)
                    {
                        for ( int j=0; j< second.Length; j++)
                        {
                            Console.Write(c[i,j]);
                        }
                        Console.WriteLine();
                    }
                    //printLCS(first, first.Length, second.Length);

                }
                else
                {
                    Console.WriteLine("please enter only one parameter.");
                }


            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found.");



            }

        }




        //public static void lcsLenght(string x, string y)
        //{

        //int m = x.Length;
        //int n = y.Length;

        //b = new string[m+1, n+1];
        //c = new int[m+1,n+1];

        //for (int i = 1; i <= m; i++)
        //{
        //    c[i, 0] = 0;
        //}

        //for (int j = 1; j <= n; j++ )
        //{
        //    c[0, j] = 0;
        //}

        //for ( int i = 1; i <= m; i++ )
        //{
        //    for ( int j = 1; j<= n; j++ )
        //    {
        //        if (x[i-1] == y[j-1])
        //        {

        //            c[i, j] = c[i-1,j-1] + 1;
        //            Console.Write(c[i,j]);
        //            //D for Diagonal!
        //            b[i, j] = "D";

        //        }else if ( c[i-1,j] >= c[i,j-1] )
        //        {

        //            c[i,j]= c[i-1,j];
        //            Console.Write(c[i, j]);
        //            //U for Up!
        //            b[i, j] = "U";


        //        }
        //        else
        //        {

        //            c[i, j] = c[i, j - 1];
        //            Console.Write(c[i, j]);
        //            //L for Left!
        //            b[i, j] = "L";



        //        }
        //        //Console.WriteLine();
        //    }
        //    Console.WriteLine();

        //    //}



        //}
        static int[,] LCS(string s1, string s2)
        {
            int[,] c = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++)

                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                    }
                    else
                    {

                        //if (c[i - 1, j] > c[i, j - 1])
                        //{
                        //    c[i, j] = c[i - 1, j];
                        //}
                        //else
                        //{
                        //    c[i, j] = c[i, j - 1];
                        //}
                        //?: if statement practice
                        c[i, j] = c[i - 1, j] > c[i, j - 1] ? c[i - 1, j] : c[i, j - 1];
                    }
                }
            return c;
        }

        //public static void printLCS( string X, int i, int j )
        //{

        //    if ( i == 0 || j == 0  )
        //    {

        //    }
        //    if ( b[i,j] == "D" )
        //    {
        //        printLCS( X, i-1, j-1);
        //        Console.Write( X[i-1] );
        //    }else if ( b[i,j] == "U" )
        //    {
        //        printLCS(X, i-1, j);
        //    }
        //    else
        //    {
        //        printLCS( X, i, j-1 );
        //    }


        //}


        //static string printLCS(int[,] c, string s1, string s2, int i, int j)
        //{
        //    var a = "";

        //    if (i > 0 && j > 0 && s1[i - 1] == s2[j - 1])
        //    {
        //        a = printLCS(c, s1, s2, i - 1, j - 1);
        //        return a + "" + s1[i - 1];
        //    }
        //    else if (j > 0 && (i == 0 || (c[i, j - 1] > c[i - 1, j])))
        //    {
        //        a = printLCS(c, s1, s2, i, j - 1);
        //        return a + "+" + s2[j - 1];
        //    }
        //    else if (i > 0 && (j == 0 || (c[i, j - 1] <= c[i - 1, j])))
        //    {
        //        a = printLCS(c, s1, s2, i - 1, j);
        //        return a + "-" + s1[i - 1];
        //    }
        //    return a;
        //}

        static string printLCS(int[,] c, string s1, string s2, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return "";
            }

            else if (s1[i - 1] == s2[j - 1])
            {
                return printLCS(c, s1, s2, i - 1, j - 1) + s1[i - 1];
            }
            else if (c[i, j - 1] > c[i - 1, j])
            {
                return printLCS(c, s1, s2, i, j - 1);
            }
            else
            {
                return printLCS(c, s1, s2, i - 1, j);
            }
        }







    }
}
