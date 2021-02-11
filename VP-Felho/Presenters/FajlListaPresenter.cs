using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Felho.Repositories;
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
    }
}
