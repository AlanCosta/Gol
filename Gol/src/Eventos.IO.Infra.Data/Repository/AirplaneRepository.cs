using Dapper;
using Gol.IO.Domain.Airplane;
using Gol.IO.Domain.Airplane.Repository;
using Gol.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gol.IO.Infra.Data.Repository
{
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository(AirplanesContext context) :base(context)
        {

        }

        public override IEnumerable<Airplane> ObterTodos()
        {
            var sql = "SELECT * FROM tb_AirplaneGol";

            return Db.Database.GetDbConnection().Query<Airplane>(sql);
        }

        public override Airplane ObterPorId(int id)
        {
            var sql = @"SELECT * FROM tb_AirplaneGol " +
                "WHERE Id = @uid";

            var evento = Db.Database.GetDbConnection().Query<Airplane>(sql,new {uid = id}
                );

            return evento.FirstOrDefault();
        }
    }
}
