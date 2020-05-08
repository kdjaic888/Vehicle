using System;
using System.Collections.Generic;
using System.Text;
using Project.Service.Model;

namespace Project.Service.Interface
{
    public interface IPagingParameters
    {
        string sortOrder { get; set; }
        string currentFilter { get; set; }
        string searchString { get; set; }
        int pageIndex { get; set; }
    }
}
