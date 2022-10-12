using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookList_v2._0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        public CompanyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var companies = unitOfWork.CompanyRepository.GetAll();
            return View(companies);
        }

        public IActionResult Upsert(Guid? id)
        {
            var company = new Company();
            if (id == null)
                return View(company);

            var guid = id.GetValueOrDefault();
            company = unitOfWork.CompanyRepository.Get(guid);

            if (company == null)
                return NotFound();

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (!ModelState.IsValid)
                return View(company);

            if (company.Id == Guid.Empty)
                unitOfWork.CompanyRepository.Add(company);
            else
                unitOfWork.CompanyRepository.Update(company);

            unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var companyToDelete = unitOfWork.CompanyRepository.Get(id);
            if (companyToDelete == null)
                return RedirectToAction(nameof(Upsert));

            unitOfWork.CompanyRepository.Remove(companyToDelete);
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //

        private readonly IUnitOfWork unitOfWork;
    }
}
