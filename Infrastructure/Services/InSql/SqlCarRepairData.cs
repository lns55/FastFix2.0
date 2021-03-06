﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using FastFix2._0.Infrastructure.Interfaces;
using System;

namespace FastFix2._0.Infrastructure.Services.InSql
{   
    /// <summary>
    /// Inherits and implements methods for working with CarRepair company data.
    /// </summary>
    public class SqlCarRepairData : ICarRepairData
    {
        private readonly FastFixDbContext _db;

        public SqlCarRepairData(FastFixDbContext db) => _db = db;

        public IEnumerable<CarRepairUser> GetCarRepairUsers() => _db.CarRepairUsers;

        public CarRepairUser GetById(int Id) => _db.CarRepairUsers.Find(Id);

        public int Add(CarRepairUser carRepairUser)
        {
            if (carRepairUser is null)
                throw new ArgumentNullException(nameof(carRepairUser));

            _db.Add(carRepairUser);

            return carRepairUser.Id;
        }

        public bool Delete(int Id)
        {
            var carRepair = GetById(Id);

            if (carRepair is null)
            {
                return false;
            }

            _db.Remove(carRepair);
            return true;
        }

        public void Edit(CarRepairUser carRepairUser)
        {
            if (carRepairUser is null)
                throw new ArgumentNullException(nameof(carRepairUser));

            _db.Update(carRepairUser);
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
