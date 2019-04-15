using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Domain.ModelView
{
    public class ValorCampoModelView
    {
        public int IdValorCampo { get; set; }
        public string ValorCampo { get; set; }
        public int IdFormulario { get; set; }
        public int IdFormularioCampo { get; set; }
    }
}
