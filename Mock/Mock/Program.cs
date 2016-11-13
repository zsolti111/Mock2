using DAL;
using System;
using System.IO;

namespace Mock
{
    public class Program 
    {


       
   
        static void Main(string[] args) 
        {
            string path = Directory.GetCurrentDirectory();
            Repository p = new Repository(path);
            p.Logger();
            var res = p.Load(Directory.GetCurrentDirectory()+"MyFile" + ".csv");
            Console.WriteLine(res);
            Console.ReadLine();

        }

      

                   



    }
}