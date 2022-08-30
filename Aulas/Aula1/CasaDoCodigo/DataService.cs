﻿using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;

        public DataService(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public void InicializaBD()
        {
            contexto.Database.Migrate();
        }
    }
}
