using Gol.IO.Domain.Core.Commands;
using Gol.IO.Domain.Interfaces;
using Gol.IO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.IO.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AirplanesContext context;

        public UnitOfWork(AirplanesContext _context)
        {
            context = _context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
