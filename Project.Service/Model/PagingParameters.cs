using Project.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Service.DataContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections;

namespace Project.Service.Model
{
    public class PagingParameters<T>: List<T>,IPagingParameters
    {
        public string sortOrder { get; set; }
        public string currentFilter { get; set; }
        public string searchString { get; set; }
        public int pageIndex { get; set; }

        public static Task<IList<VehicleMake>> CreateAsync(IQueryable<VehicleMake> queryable, int v, int pageSize)
        {
            throw new NotImplementedException();
        }


        public static Task<IList<VehicleModel>> CreateAsync(IQueryable<VehicleModel> queryable, int v, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
