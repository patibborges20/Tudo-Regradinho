using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tudo_Regradinho
{
     public class RegrasDB
    {
        public static DataBase getDataBase()
        {
            DataBase db = new DataBase();
            if (db.DatabaseExists() == false)
            {
                db.CreateDatabase();
            }
            return db;
        }

        public static List<clsRegras> GetRegras(String a)
        {
            DataBase db = getDataBase();
            var query = from c in db.Regrinhas orderby c.Descricao select c;

            List<clsRegras> Regras = new List<clsRegras>(query.AsEnumerable());
            return Regras;
        }

        public static void Salvar(clsRegras Regras)
        {
            DataBase db = getDataBase();
            db.Regrinhas.InsertOnSubmit(Regras);
            db.SubmitChanges();

        }



        public static void Editar(clsRegras c)
        {
            DataBase db = getDataBase();

            clsRegras Regras = (from r in db.Regrinhas where r.Id == r.Id select r).First();

            Regras.Descricao = c.Descricao;
            db.SubmitChanges();
        }

        public static void Deletar(clsRegras c)
        {
            DataBase bd = getDataBase();

            clsRegras Regras = (from r in bd.Regrinhas where r.Id == c.Id select r).First();

            Regras.Descricao = c.Descricao;
            bd.SubmitChanges();


        }






    }
}
