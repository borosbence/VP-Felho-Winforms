using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Felho.Models;
using VP_Felho.Repositories;
using VP_Felho.Services;
using VP_Felho.ViewInterfaces;

namespace VP_Felho.Presenters
{
    class FajlListaPresenter
    {
        private IFajlListaView view;
        private FajlRepository repo;
        public FajlListaPresenter(IFajlListaView param)
        {
            view = param;
            repo = new FajlRepository();
        }

        public void LoadData()
        {
            view.fajlLista = repo.GetAll();
        }

        public void SelectFile(int id)
        {
            view.fajl = repo.GetFile(id);
        }

        public void CreateFile()
        {
            view.fajl = new fajl();
        }

        public void SaveFile()
        {
            var fajl = view.fajl;
            if (repo.Exists(fajl.id)
            {
                repo.Update(fajl);
            }
            else
            {
                fajl.felhasznalo_id = CurrentUser.Id;
                repo.Insert(fajl);
            }
            LoadData();
        }

        public void RemoveFile()
        {
            repo.Delete(view.fajl.id);
            LoadData();
        }
    }
}
