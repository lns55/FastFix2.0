using FastFix2._0.Areas.Applications;
using System.Collections.Generic;

namespace FastFix2._0.Infrastructure.Interfaces
{
    public interface IApp
    {
        IEnumerable<NewApplications> Get();
        NewApplications GetById(int Id);
        string Add(NewApplications app);
        bool Delete(int Id);
        void SaveChanges();
    }
}
