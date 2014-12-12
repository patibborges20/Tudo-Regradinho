using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tudo_Regradinho
{
    public  class DataBase : DataContext
    {
        public static string DBConnectionString = "Data Source='isistore:Regrinhas.sdf'";

        public DataBase()
            :base(DBConnectionString)
        { }

        public Table<clsRegras> Regrinhas
        {
            get
            {
                return this.GetTable<clsRegras>();
            }
        }
    }
}
