using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mock
{
    public class Program : IDisposable
    {

        /// <summary>
        /// Path to the .csv file's directory
        /// </summary>
        string path = Directory.GetCurrentDirectory() ;

        StreamWriter streamCSV = null;

        

        // CONSTRUCTORS
        public Program()
        {

        }

        static void Main(string[] args) 
        {
            Program p = new Program();
            p.Logger();
            var res = p.Load(Directory.GetCurrentDirectory()+"MyFile" + ".csv");
            Console.WriteLine(res);
            Console.ReadLine();

        }

        public void Logger()
        {
            /* Create the directory if it not exist */
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            //-------------------------------------
            //---------- CSV logging---------------
            //-------------------------------------

            try
            {
                // If it's the first time we want to write
                if (streamCSV == null)
                {

                    streamCSV = new StreamWriter(new FileStream(path + "MyFile"  + ".csv", FileMode.Append, FileAccess.Write, FileShare.ReadWrite));

                    /* If the file is empty we make the header */
                    var csvFileLenth = new System.IO.FileInfo(path + "MyFile" + ".csv").Length;

                    if (csvFileLenth == 0)
                    {
                        streamCSV.AutoFlush = true;
                        streamCSV.Write("AAA" + Environment.NewLine +
                                        "BBB" + Environment.NewLine);

                    }

                    streamCSV.Dispose();


                }



            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {

            }


        }

        /// <summary>
        /// Stop the Logging, close the Stream
        /// </summary>
        public void StopLogTradeHistory()
        {
            if (streamCSV != null)
            {
                streamCSV.Dispose();
            }
        }


        /// <summary>
        /// Load the existing Trade History
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>    
        public string Load(string path)
        {

            /* Ha nincs file, ne szálljon el Load-nál */
            if (File.Exists(path) == false)
            {
                string ret = "nincs file";
                return ret;
            }

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(File.OpenRead(path));
                string line = "";
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
        
                }

                /* Free the reader */
                reader.Dispose();
                return line;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                string exc = "exception";
                return exc;
            }

            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }

            }

        }


        // DISPOSE //
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (streamCSV != null)
                        streamCSV.Dispose();
                }
                // Release unmanaged resources.
                disposed = true;
            }
        }

        ~Program() { Dispose(false); }





    }
}