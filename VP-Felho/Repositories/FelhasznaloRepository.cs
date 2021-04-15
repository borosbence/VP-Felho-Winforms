using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Felho.Models;

namespace VP_Felho.Repositories
{
    public class FelhasznaloRepository
    {
        private FelhoContext db = new FelhoContext();
        public bool FelhasznaloNevExist(string felhnev)
        {
            return db.felhasznalo.Any(x => x.felh_nev == felhnev);
        }
        public int GetId(string felhnev)
        {
            var felhasznalo = db.felhasznalo.SingleOrDefault(x => x.felh_nev == felhnev);
            if (felhasznalo != null)
            {
                return felhasznalo.id;
            }
            return 0;
        }
        public bool Authenticate(string felhnev, string jelszo)
        {
            return db.felhasznalo.Any(x => x.felh_nev == felhnev && x.jelszo == jelszo);
        }
    }
}
