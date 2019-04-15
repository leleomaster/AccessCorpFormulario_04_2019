using AccessCorpFormulario.Infrastructure.Database.CodeFirst;
using AccessCorpFormulario.Infrastructure.Database.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Infrastructure.Database.Repository
{
    public class FormularioCampoRepository : BaseRepository, IFormularioCamposRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FormularioCampoDomain> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(FormularioCampoDomain t)
        {
            using (var db = GetConnection())
            {
                DynamicParameters p = new DynamicParameters();

                p.AddDynamicParams(
                    new
                    {
                        IdTipoCampo = t.TipoCampo.IdTipoCampo,
                        IdTipoValorCampo = t.TipoValorCampo.IdTipoValorCampo,
                        IdFormulario = t.FormularioDomain.IdFormulario,
                        DescricaoCampo = t.FormularioDomain.DescricaoFormulario
                    });

                int resultado = db.Execute("sp_formulario_campo_Inserir", p, commandType: CommandType.StoredProcedure);

                return 0;
            }
        }

        public async Task<IList<FormularioCampoDomain>> List()
        {
            List<FormularioCampoDomain> lista;
            using (var db = GetConnection())
            {
                const string sql = "sp_s_get_formulario_campos";

                lista = new List<FormularioCampoDomain>();

                Func<FormularioCampoDomain, FormularioDomain, TipoCampoDomain, TipoValorCampoDomain, FormularioCampoDomain> mapper = ((fc, f, tc, tvc) =>
                {
                    fc.TipoCampo = tc;
                    fc.TipoValorCampo = tvc;
                    //fc.Formulario = f;

                    lista.Add(fc);

                    return fc;
                });

                var query = await db.QueryAsync<FormularioCampoDomain, FormularioDomain, TipoCampoDomain, TipoValorCampoDomain, FormularioCampoDomain>
                    (sql, mapper, commandType: CommandType.StoredProcedure, splitOn: "splitFormulario;splitTipoCampo;splitTipoValorCampo");

                lista = query.ToList();
            }
            return lista;
        }

        public void Update(FormularioCampoDomain t)
        {
            throw new NotImplementedException();
        }

    }
}
