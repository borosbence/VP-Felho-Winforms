using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Felho.Models;
using VP_Felho.Services;

namespace VP_Felho.Repositories
{
    public class FajlRepository
    {
        private FelhoContext db = new FelhoContext();

        public List<fajl> GetAll()
        {
            return db.fajl.Where(x => x.felhasznalo_id == CurrentUser.Id).ToList();
        }
    }
}
