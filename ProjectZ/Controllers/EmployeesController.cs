using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectZ.BLL.Interfaces;
using ProjectZ.BLL.Models;
using ProjectZ.Mapper;
using ProjectZ.Models;

namespace ProjectZ.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<Employee> _employeeService;
        private readonly IEntityService<Company> _companyService;
        private readonly CustomViewModelMapper _mapper;
        public EmployeesController(IEntityService<Employee> employeeService, IEntityService<Company> companyService,
            ILogger<HomeController> logger, CustomViewModelMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = logger;
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var employees =
                    _mapper.MapEmployeesToEmployeesViewModel(await _employeeService.GetAllAsync());
                return View(employees);
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                ViewBag.Companies = _mapper.MapCompaniesToCompaniesViewModel(await _companyService.GetAllAsync());
                return View(id.HasValue
                    ? _mapper.MapEmployeeToEmployeeViewModel(_employeeService.GetEntityById(id.Value))
                    : new EmployeeViewModel());
            }
            catch (Exception e)
            {
                _logger.LogError($"Method didn't work({e.Message}), {e.TargetSite}, {DateTime.Now}");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                ViewBag.Companies = _mapper.MapCompaniesToCompaniesViewModel(await _companyService.GetAllAsync());
                if (!ModelState.IsValid)
                    return View(employeeViewModel);

                if (employeeViewModel.Id != 0)
                    _employeeService.Update(_mapper.MapEmployeeSqlModelToEmployee(employeeViewModel));
                else
                    _employeeService.Create(_mapper.MapEmployeeSqlModelToEmployee(employeeViewModel));

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
                _employeeService.Delete(id);
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
