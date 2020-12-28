using System;
using FastFix2._0.Areas.Identity;
using System.Collections.Generic;
using FastFix2._0.ViewModels.Identity;

namespace FastFix2._0.Infrastructure.Interfaces
{
    /// <summary>
    /// Inherits CarRepair company data model and initializing methods to work with this data.
    /// </summary>
    public interface ICarRepairData
    {
        IEnumerable<CarRepairUser> GetCarRepairUsers();

        int Add(CarRepairUser carRepairUser);

        bool Delete(int id);

        void SaveChanges();
    }
}
