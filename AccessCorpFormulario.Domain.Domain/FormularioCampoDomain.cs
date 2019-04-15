using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Domain.Domain
{
    public class FormularioCampoDomain
    {
        public FormularioDomain FormularioDomain { get; set; }
        public TipoCampoDomain TipoCampo { get; set; }
        public TipoValorCampoDomain TipoValorCampo { get; set; }
        public List<string> ValoresCombobox { get; set; }
        public string ValorCampo{ get; set; }
    }
}
