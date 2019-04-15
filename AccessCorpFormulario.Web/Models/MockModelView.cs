using AccessCorpFormulario.Domain.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AccessCorpFormulario.Web.Models
{
    public static class MockModelView
    {

        public static List<FormularioModelView> MockListaFormularioModelView()
        {
            return new List<FormularioModelView>
            {
                new FormularioModelView
                {
                    IdFormulario = 1,
                    DataVencimentoFim = "01/05/2020",
                    DataVencimentoInicio = "01/01/2018",
                    NomeFormulario = "Cadastro de Usuário"
                },
                new FormularioModelView
                {
                    IdFormulario = 2,
                    DataVencimentoFim = "18/08/2022",
                    DataVencimentoInicio = "20/10/2020",
                    NomeFormulario = "Cadastro de Roupas"
                }
            };
        }

        public static List<ListItem> ListaTipoCampo()
        {
            return
                new List<ListItem>{
                new ListItem { Text = "-- Selecionar --", Value = "" },
                 new ListItem { Text = "Textbox", Value = "1" },
                new ListItem { Text = "Dropbox", Value = "2" },
                new ListItem { Text = "Radio Button", Value = "3" }
        };
        }

        public static List<ListItem> ListaTipoValorCampo()
        {
            return
                new List<ListItem>{
                new ListItem { Text = "-- Selecionar --", Value = "" },
                new ListItem { Text = "Texto", Value = "1" },
                new ListItem { Text = "Numérico", Value = "2" },
                new ListItem { Text = "Moeda", Value = "3" }
        };
        }
    }
}