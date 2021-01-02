using FastFix2._0.ViewModels.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Infrastructure.Interfaces
{
    public interface IApp
    {
        IEnumerable<CreateApplicationViewModel> Get();

        CreateApplicationViewModel GetById(int Id);
        int Add(CreateApplicationViewModel app);
        bool Delete(int Id);
        void SaveChanges();
    }
}
