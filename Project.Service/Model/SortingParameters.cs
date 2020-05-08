using Project.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Service.DataContext;

namespace Project.Service.Model
{
    public class SortingParameters : ISortingParameters
    {
        public string sortOrder { get; set; }

    }
}
