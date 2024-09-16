using BackendDeveloperProject.Core.Dtos;
using BackendDeveloperProject.Core.Services;
using BackendDeveloperProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendDeveloperProject.Web.Controllers
{
    [Authorize]
    [Route("forms")]
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var forms = await _formService.GetFormsAsync();
            var response = forms.Select(x => new FormViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Fields = x.Fields.Select(y => new FieldViewModel()
                {
                    Name = y.Name,
                    DataType = y.DataType,
                    Required = y.Required
                }).ToList()
            }).ToList();
            return View(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string? prefix = null)
        {
            var forms = await _formService.GetFormsAsync(prefix);
            var response = forms.Select(x => new FormViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Fields = x.Fields.Select(y => new FieldViewModel()
                {
                    Name = y.Name,
                    DataType = y.DataType,
                    Required = y.Required
                }).ToList()
            }).ToList();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> FillForm(int id)
        {
            var form = await _formService.GetFormAsync(id);
            FormViewModel response = new()
            {
                Name = form.Name,
                Description = form.Description,
                Fields = form.Fields.Select(x => new FieldViewModel()
                {
                    Name = x.Name,
                    DataType = x.DataType,
                    Required = x.Required
                }).ToList()
            };
            return View(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(FormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _formService.AddFormAsync(new FormDto()
            {
                Name = model.Name,
                Description = model.Description,
                Fields = model.Fields.Select(x => new FieldDto()
                {
                    DataType = x.DataType,
                    Name = x.Name,
                    Required = x.Required
                }).ToList()
            });
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _formService.DeleteFormAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
