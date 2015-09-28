using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP_Viewer.Web.Models
{
    public class WorkOrderListViewModel
    {
        public IEnumerable<WorkOrderViewModel> WorkOrderList { get; set; }
    }
}