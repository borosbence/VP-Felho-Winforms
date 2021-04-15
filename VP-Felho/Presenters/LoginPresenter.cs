using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Felho.Repositories;
using VP_Felho.Services;
using VP_Felho.ViewInterfaces;

namespace VP_Felho.Presenters
{
    public class LoginPresenter
    {
        private ILoginView view;
        private FelhasznaloRepository repo;
        public LoginPresenter(ILoginView param)
        {
            view = param;
            repo = new FelhasznaloRepository();
        }

        public bool Belepes()
        {
            view.errorFelhNev = null;
            view.errorJelszo = null;

            if (string.IsNullOrWhiteSpace(view.felhNev))
            {
                view.errorFelhNev = "Kérem töltse ki ezt a mezőt.";
            }

            if (string.IsNullOrWhiteSpace(view.jelszo))
            {
                view.errorJelszo = "Kérem töltse ki ezt a mezőt.";
            }

            // Ha ki van töltve a felhasználónév és a jelszó
            if (!string.IsNullOrWhiteSpace(view.felhNev) && !string.IsNullOrWhiteSpace(view.jelszo))
            {
                // Létezik-e a felhasználó
                if (repo.FelhasznaloNevExist(view.felhNev))
                {
                    var felhId = repo.GetId(view.felhNev);
                    var jelszo = Hash.Encrypt(view.jelszo + felhId);
                    // Jó jelszó van a felhasználóhoz
                    if (repo.Authenticate(view.felhNev, jelszo))
                    {
                        CurrentUser.Id = felhId;
                        CurrentUser.UserName = view.felhNev;
                        return true;
                    }
                    else
                    {
                        view.errorJelszo = "Hibás felhasználónév vagy jelszó.";
                    }
                }
                else
                {
                    view.errorFelhNev = "Felhasználó nem létezik.";
                }
            }
            return false;
        }
    }
}
