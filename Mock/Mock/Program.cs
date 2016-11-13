using DAL;
using System;
using System.IO;

namespace Mock
{
    public class Program 
    {


       
   
        static void Main(string[] args) 
        {
            Repository p = new Repository();
            p.Logger();
            var res = p.Load(Directory.GetCurrentDirectory()+"MyFile" + ".csv");
            Console.WriteLine(res);
            Console.ReadLine();

        }

      

                   



    }
}