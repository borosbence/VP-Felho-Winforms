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

        public fajl GetFile(int id)
        {
            return db.fajl.Find(id);
        }

        public bool Exists(int id)
        {
            return db.fajl.Any(x => x.id == id);
        }

        public void Insert(fajl fajl)
        {
            db.fajl.Add(fajl);
            // XAMPP MySQL Config --> max_allowed_packet=100M
            db.SaveChanges();
        }

        public void Update(fajl ujFajl)
        {
            var regiFajl = db.fajl.Find(ujFajl.id);
            if (regiFajl != null)
            {
                db.Entry(regiFajl).CurrentValues.SetValues(ujFajl);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var file = db.fajl.Find(id);
            if (file != null)
            {
                db.fajl.Remove(file);
                db.SaveChanges();
            }
        }
    }
}
