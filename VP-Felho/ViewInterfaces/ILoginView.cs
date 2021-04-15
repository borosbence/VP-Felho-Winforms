using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Felho.ViewInterfaces
{
    public interface ILoginView
    {
        string felhNev { get; }
        string jelszo { get; }
        string errorFelhNev { set; }
        string errorJelszo { set; }
    }
}
