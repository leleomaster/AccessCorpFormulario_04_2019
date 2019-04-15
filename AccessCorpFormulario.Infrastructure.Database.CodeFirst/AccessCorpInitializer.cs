using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst
{
    public class AccessCorpInitializer: CreateDatabaseIfNotExists<AccessCorpContext>
    {
        protected override void Seed(AccessCorpContext context)
        {
            var tipoCampos = new List<TipoCampoDomain>
            {
                new TipoCampoDomain
                {
                    IdTipoCampo = 1,
                    NomeTipoCampo = "Textbox"
                },
                new TipoCampoDomain
                {
                    IdTipoCampo = 2,
                    NomeTipoCampo = "Dropbox"
                },
                new TipoCampoDomain
                {
                    IdTipoCampo = 3,
                    NomeTipoCampo = "Radio Button"
                }
            };

            tipoCampos.ForEach(tc => context.TipoCampoDomain.Add(tc));
           // context.SaveChanges();

            var tipoValorCampos = new List<TipoValorCampoDomain>
            {
                new TipoValorCampoDomain
                {
                    IdTipoValorCampo = 1,
                    NomeTipoValorCampo = "Texto"
                },
                new TipoValorCampoDomain
                {
                    IdTipoValorCampo = 2,
                    NomeTipoValorCampo = "Numérico"
                },
                new TipoValorCampoDomain
                {
                    IdTipoValorCampo = 3,
                    NomeTipoValorCampo = "Moeda"
                }
            };

            tipoValorCampos.ForEach(tvc => context.TipoValorCampoDomain.Add(tvc));
            //context.SaveChanges();

            base.Seed(context);
        }
    }
}
