using ERP_Viewer.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Viewer.Web.Models
{
    public class WorkOrderInputModel
    {
        [Required]
        [Display(Name = "Work Order ID")]
        public int WorkOrderID { get; set; }

        [Required]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Order Quantity")]
        public int OrderQty { get; set; }

        [Display(Name = "Stocked Quantity")]
        public int StockedQty { get; set; }

        [Display(Name = "Scrapped Quantity")]
        public short ScrappedQty { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Scrapped Reason ID")]
        public short? ScrapReasonID { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public SelectList ScrapReasons { get; set; }

        public static WorkOrderInputModel CreateFromWorkOrder(WorkOrder w)
        {
            return new WorkOrderInputModel
            {
                WorkOrderID = w.WorkOrderID,
                StockedQty = w.StockedQty,
                DueDate = w.DueDate,
                EndDate = w.EndDate,
                OrderQty = w.OrderQty,
                ScrappedQty = w.ScrappedQty,
                ModifiedDate = DateTime.Now,
                ScrapReasonID = w.ScrapReasonID,
                ProductID = w.ProductID,
                StartDate = w.StartDate
            };
        }
    }
}