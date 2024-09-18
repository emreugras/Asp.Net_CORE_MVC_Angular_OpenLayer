using AngularProject.Application.Abstraction;
using AngularProject.Application.RepositoriesGeometry;
using AngularProject.Application.RepositoriesLogger;
using AngularProject.Application.ViewModels.Geometries;
using AngularProject.Application.ViewModels.Users;
using AngularProject.Domain.Entities;
using AngularProject.Persistence;
using AngularProject.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularProject.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize(AuthenticationSchemes = "Admin")]
	public class GeometryController : ControllerBase
	{

		readonly private IGeomReadRepository _geometryReadRepository;
		readonly private IGeomWriteRepository _geometryWriteRepository;
		


		public GeometryController(IGeomReadRepository geometryReadRepository, IGeomWriteRepository geometryWriteRepository)
		{
			_geometryReadRepository = geometryReadRepository;
			_geometryWriteRepository = geometryWriteRepository;

		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			
			return Ok(_geometryReadRepository.GetAll());

		}
		[HttpPost]
		public async Task<IActionResult> Post(VM_Create model)
		{

			var Date = DateTime.Now.ToString();
			int dats = _geometryReadRepository.GetAll().OrderBy(x => x.id).Count();


			await _geometryWriteRepository.AddAsync(new()
			{

				Namew = model.Namew,
				Surnamew = model.Surnamew,
				Commentw = model.Commentw,
				id = Guid.NewGuid().ToString(),
				Geom = model.Geom,
				Datew = Date,
			});
			await _geometryWriteRepository.SaveAsync();

			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Put(VM_Update model)
		{
			Geometry geometry = await _geometryReadRepository.GetByIdAsync(model.id);
			geometry.Surnamew = model.Surnamew;
			geometry.Namew = model.Namew;
			geometry.Commentw = model.Commentw;
			geometry.Datew = DateTime.Now.ToString();
			await _geometryWriteRepository.SaveAsync();
			return Ok(); //bir belirli id deki dataları güncelleme yapar burda
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			await _geometryWriteRepository.RemoveAsync(id);
			await _geometryWriteRepository.SaveAsync();
			return Ok();
		}

		//[HttpPost]
		//[HttpPost("{action}")]
		//public async Task<IActionResult> login(VM_logger vM_Logger)
		//{
		//	return Ok();
		//}
	}
}
