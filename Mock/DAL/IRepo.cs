using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepo
    {
        void Logger();
        void Load(string path);
    }
}
