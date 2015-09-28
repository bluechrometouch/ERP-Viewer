using ERP_Viewer.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ERP_Viewer.Web.Models
{
    public class WorkOrderViewModel
    {
        [Display(Name = "Work Order ID")]
        public int WorkOrderID { get; set; }

        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Order Quantity")]
        public int OrderQty { get; set; }

        [Display(Name = "Stocked Quantity")]
        public int StockedQty { get; set; }

        [Display(Name = "Scrapped Quantity")]
        public short ScrappedQty { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [DisplayFormat(NullDisplayText = "None")]
        [Display(Name = "Scrapped Reason ID")]
        public short? ScrapReasonID { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public static Expression<Func<WorkOrder, WorkOrderViewModel>> ViewModel
        {
            get
            {
                return w => new WorkOrderViewModel()
                {
                    WorkOrderID = w.WorkOrderID,
                    ProductID = w.ProductID,
                    OrderQty = w.OrderQty,
                    StockedQty = w.StockedQty,
                    ScrappedQty = w.ScrappedQty,
                    StartDate = w.StartDate,
                    EndDate = w.EndDate,
                    DueDate = w.DueDate,
                    ScrapReasonID = w.ScrapReasonID,
                    ModifiedDate = w.ModifiedDate
                };
            }
        }
    }
}