using FastFix2._0.Data;
using FastFix2._0.Infrastructure.Interfaces;
using FastFix2._0.ViewModels.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Infrastructure.Services.InSql
{
    public class SqlApp : IApp
    {
        private readonly FastFixDbContext _db;

        public SqlApp(FastFixDbContext db) => _db = db;

        public IEnumerable<NewApplications> Get() => _db.NewApplications;

        public NewApplications GetById(int Id) => _db.NewApplications.Find(Id);

        public int Add(NewApplications app)
        {
            if (app is null)
                throw new ArgumentNullException(nameof(app));

            _db.Add(app);

            return app.Id;
        }

        public bool Delete(int Id)
        {
            var app = GetById(Id);

            if (app is null)
                return false;

            _db.Remove(app);
                return true;
        }

        public void SaveChanges() => _db.SaveChanges();

    }
}
