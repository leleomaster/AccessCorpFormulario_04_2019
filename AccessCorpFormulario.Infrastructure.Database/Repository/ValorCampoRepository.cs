using AccessCorpFormulario.Infrastructure.Database.CodeFirst;
using AccessCorpFormulario.Infrastructure.Database.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Infrastructure.Database.Repository
{
    public class ValorCampoRepository : BaseRepository, IValorCampoRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ValorCampoDomain> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ValorCampoDomain t)
        {
            using (var db = GetConnection())
            {
                DynamicParameters p = new DynamicParameters();

                p.AddDynamicParams(
                    new
                    {
                        IdTipoCampo = t.IdTipoCampo,
                        IdFormulario = t.IdFormulario,
                        ValorCampo = t.ValorCampo
                    });

                int resultado = db.Execute("sp_valor_campo_Inserir", p, commandType: CommandType.StoredProcedure);

                return 0;
            }
        }

        public Task<IList<ValorCampoDomain>> List()
        {
            throw new NotImplementedException();
        }

        public void Update(ValorCampoDomain t)
        {
            throw new NotImplementedException();
        }
    }
}
