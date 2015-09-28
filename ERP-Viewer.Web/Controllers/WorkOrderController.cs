using ERP_Viewer.Data.Models;
using ERP_Viewer.Web.Extensions;
using ERP_Viewer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Viewer.Web.Controllers
{
    public class WorkOrderController : BaseController
    {
        // GET: WorkOrder
        new public ActionResult View()
        {
            var workOrder = this.companyDb.WorkOrders
                .OrderByDescending(w => w.DueDate)
                .Take(50)
                .Select(WorkOrderViewModel.ViewModel);

            return View(new WorkOrderListViewModel()
            {
                WorkOrderList = workOrder
            });
        }

        public ActionResult Add()
        {
            var model = new WorkOrderInputModel()
            {
                ScrapReasons = LoadScrapReason(),
                DueDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(WorkOrderInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {

                if (model.ScrappedQty <= 0)
                {
                    model.ScrapReasonID = null;
                }

                var workOrderToAdd = new WorkOrder
                {

                    DueDate = model.DueDate,
                    EndDate = model.EndDate,
                    OrderQty = model.OrderQty,
                    StockedQty = model.StockedQty,
                    ScrappedQty = model.ScrappedQty,
                    ModifiedDate = DateTime.Now,
                    ScrapReasonID = model.ScrapReasonID,
                    ProductID = model.ProductID,
                    StartDate = model.StartDate
                };

                this.companyDb.WorkOrders.Add(workOrderToAdd);
                this.companyDb.SaveChanges();
                return this.RedirectToAction("");
            }

            return this.View(model);
        }

        public ActionResult Remove(int id)
        {
            var workOrderToRemove = this.LoadWorkOrder(id);
            if (workOrderToRemove == null)
            {
                return this.RedirectToAction("");
            }

            var model = WorkOrderInputModel.CreateFromWorkOrder(workOrderToRemove);
            model.ScrapReasons = LoadScrapReason();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Remove(int id, WorkOrderInputModel model)
        {
            var workOrderToRemove = this.LoadWorkOrder(id);
            if (workOrderToRemove == null)
            {
                return this.RedirectToAction("");
            }

            this.companyDb.WorkOrders.Remove(workOrderToRemove);
            this.companyDb.SaveChanges();
            return this.RedirectToAction("");
        }

        public ActionResult Edit(int id)
        {
            var workOrderToEdit = this.LoadWorkOrder(id);
            if (workOrderToEdit == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("");
            }

            var model = WorkOrderInputModel.CreateFromWorkOrder(workOrderToEdit);
            model.ScrapReasons = LoadScrapReason();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(int id, WorkOrderInputModel model)
        {
            var workOrderToEdit = this.LoadWorkOrder(id);
            if (workOrderToEdit == null)
            {
                return this.RedirectToAction("");
            }

            if (workOrderToEdit != null && this.ModelState.IsValid)
            {
                workOrderToEdit.DueDate = model.DueDate;
                workOrderToEdit.EndDate = model.EndDate;
                workOrderToEdit.OrderQty = model.OrderQty;
                workOrderToEdit.StockedQty = model.StockedQty;
                workOrderToEdit.ScrappedQty = model.ScrappedQty;
                workOrderToEdit.ModifiedDate = DateTime.Now;
                if (model.ScrappedQty > 0)
                {
                    workOrderToEdit.ScrapReasonID = model.ScrapReasonID;
                }
                else
                {
                    workOrderToEdit.ScrapReasonID = null;
                }
                workOrderToEdit.ProductID = model.ProductID;
                workOrderToEdit.StartDate = model.StartDate;

                this.companyDb.SaveChanges();
                return this.RedirectToAction("");
            }

            return this.View(model);
        }

        private WorkOrder LoadWorkOrder(int Id)
        {
            var workOrderToEdit = this.companyDb.WorkOrders
                .Where(w => w.WorkOrderID == Id)
                .FirstOrDefault();

            return workOrderToEdit;
        }

        private SelectList LoadScrapReason()
        {
            var scrapReasons = this.companyDb.ScrapReasons;
            var scrapReasonsList = new SelectList(scrapReasons, "ScrapReasonID", "Name");

            return scrapReasonsList;
        }
    }
}