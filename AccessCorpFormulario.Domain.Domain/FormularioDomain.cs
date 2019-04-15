using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Domain.Domain
{
    public class FormularioDomain
    {
        public int IdFormulario { get; set; }
        public string NomeFormulario { get; set; }
        public string DataVencimentoInicio { get; set; }
        public string DataVencimentoFim { get; set; }
        public string DescricaoFormulario { get; set; }

        public List<FormularioCampoDomain> FormularioCampos{ get; set; }
    }
}
