using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectZ.BLL.Interfaces;
using ProjectZ.BLL.Models;
using ProjectZ.Mapper;
using ProjectZ.Models;

namespace ProjectZ.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<Company> _companyService;
        private readonly CustomViewModelMapper _mapper;
        public CompaniesController(IEntityService<Company> companyService, 
            ILogger<HomeController> logger, CustomViewModelMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var companies =
                    _mapper.MapCompaniesToCompaniesViewModel(await _companyService.GetAllAsync());
                return View(companies);
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                return View(id.HasValue
                    ? _mapper.MapCompanyToCompanyViewModel(_companyService.GetEntityById(id.Value))
                    : new CompanyViewModel());
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public IActionResult Edit(CompanyViewModel companyViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(companyViewModel);

                if (companyViewModel.Id != 0)
                    _companyService.Update(_mapper.MapCompanySqlModelToCompany(companyViewModel));
                else
                    _companyService.Create(_mapper.MapCompanySqlModelToCompany(companyViewModel));

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _companyService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}