using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Domain.ModelView
{
    public class FormularioCampoModelView
    {
        public int IdTipoCampo { get; set; }
        public int IdTipoValorCampo { get; set; }
        public int IdFormulario { get; set; }
        public int IdFormularioCampo { get; set; }

        public string DescricaoCampo { get; set; }

        public List<ValorCampoModelView> ValorCampos { get; set; }
    }
}
