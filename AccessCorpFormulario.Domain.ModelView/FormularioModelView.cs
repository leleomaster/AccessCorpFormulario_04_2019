using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Domain.ModelView
{
    public class FormularioModelView
    {
        public int IdFormulario { get; set; }
       
        [Display(Name = "Nome")]
        public string NomeFormulario { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data vencimento início")]
        public string DataVencimentoInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data vencimento fim")]
        public string DataVencimentoFim { get; set; }

        [Display(Name = "Descrição Formulário")]
        public string DescricaoFormulario { get; set; }

        [Display(Name = "Está ativo?")]
        public bool Ativo { get; set; }

        [Display(Name = "Situação")]
        public string Situacao
        {
            get
            {
                if(!string.IsNullOrEmpty(DataVencimentoInicio))
                {
                    var todayNow = DateTime.Now.ToLocalTime();
                    var dateFim = DateTime.Parse(DataVencimentoFim, System.Globalization.CultureInfo.CreateSpecificCulture("pt-br"));
                    
                    var ehAtivo = dateFim > todayNow;
                    Ativo = ehAtivo;
                    return ehAtivo ? "Ativo" : "Inativo";
                }
                else
                {
                    return "";
                }
            }
        }

        public List<FormularioCampoModelView> FormularioCampos { get; set; }
    }
}
