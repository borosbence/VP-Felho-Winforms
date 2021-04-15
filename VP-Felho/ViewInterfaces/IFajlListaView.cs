using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_Felho.Models;

namespace VP_Felho.ViewInterfaces
{
    public interface IFajlListaView
    {
        List<fajl> fajlLista { get; set; }
        fajl fajl { get; set; }
    }
}
