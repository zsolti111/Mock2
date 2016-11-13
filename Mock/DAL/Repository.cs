using System;
using System.IO;

namespace DAL
{
    public class Repository : IDisposable, IRepo
    {

        /// <summary>
        /// Path to the .csv file's directory
        /// </summary>

        string mypath;

        StreamWriter streamCSV = null;

        public Repository(string path)
        {
            mypath = path;
        }

        static void Main(string[] args)
         {

        }


        public void Logger()
        {
            /* Create the directory if it not exist */
            if (!Directory.Exists(mypath))
            {
                Directory.CreateDirectory(mypath);
            }


            //-------------------------------------
            //---------- CSV logging---------------
            //-------------------------------------

            try
            {
                // If it's the first time we want to write
                if (streamCSV == null)
                {

                    streamCSV = new StreamWriter(new FileStream(mypath + "MyFile" + ".csv", FileMode.Append, FileAccess.Write, FileShare.ReadWrite));

                    /* If the file is empty we make the header */
                    var csvFileLenth = new System.IO.FileInfo(mypath + "MyFile" + ".csv").Length;

                    if (csvFileLenth == 0)
                    {
                        streamCSV.AutoFlush = true;
                        streamCSV.Write("AAA" );

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

        ~Repository() { Dispose(false); }





    }
}

    

