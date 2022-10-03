using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheCollectionBE.Models;
using SheCollectionBE.Request_Models;
using SheCollectionBE.Services.ServiceCategoryService;
using SheCollectionBE.Services.ServicesService;
using SheCollectionBE.Services.ServiceTypeService;
using SheCollectionBE.Services.TimeSlotService;

namespace SheCollectionBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceCategoryService serviceCategoryService;
        private readonly IServiceTypeService serviceTypeService;
        private readonly IServicesService servicesService;

        public ServicesController(IServiceCategoryService serviceCategoryService, IServiceTypeService serviceTypeService, IServicesService servicesService)
        {
            this.serviceCategoryService = serviceCategoryService;
            this.serviceTypeService = serviceTypeService;
            this.servicesService = servicesService;
        }

        [HttpGet("GetServiceCategories")]
        public async Task<IActionResult> GetServiceCategories()
        {
            return Ok(serviceCategoryService.GetAll());
        }

        [HttpGet("GetServiceCategory")]
        public async Task<IActionResult> GetServiceCategory([FromQuery] int id)
        {
            return Ok(serviceCategoryService.GetById(id));
        }
        [HttpGet("GetServiceType")]
        public async Task<IActionResult> GetServiceType([FromQuery] int id)
        {
            return Ok(serviceTypeService.GetById(id));
        }
        [HttpGet("GetService")]
        public async Task<IActionResult> GetService([FromQuery] int id)
        {
            return Ok(servicesService.GetById(id));
        }

        [HttpGet("DeleteServiceCategory")]
        public async Task<IActionResult> DeleteServiceCategory([FromQuery] int id)
        {
            return Ok(serviceCategoryService.Delete(id));
        }
        [HttpGet("DeleteServiceType")]
        public async Task<IActionResult> DeleteServiceType([FromQuery] int id)
        {
            return Ok(serviceTypeService.Delete(id));
        }


        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService([FromBody] ServiceRequest ser)
        {
            ServiceTable model = new ServiceTable()
            {
                ServiceName = ser.serviceName,
                ServiceDescription = ser.serviceDescription,
                ServicePicture = ser.servicePicture,
                ServicePrice = ser.servicePrice,
                DurationMin = ser.durationMin,
                DurationMax = ser.durationMax,
                ServiceType = serviceTypeService.GetById(ser.serviceTypeId),
            };

            return Ok(servicesService.Create(model));
        }

        [HttpGet("DeleteService")]
        public async Task<IActionResult> DeleteService([FromQuery] int id)
        {
            return Ok(servicesService.Delete(id));
        }

        [HttpGet("GetServiceTypes")]
        public async Task<IActionResult> GetServiceTypes([FromQuery] int categoryId)
        {
            return Ok(serviceTypeService.GetBy(st => st.ServiceCategory.ServiceCategoryId == categoryId));
        }

        [HttpGet("GetServiceAllTypes")]
        public async Task<IActionResult> GetServiceAllTypes()
        {
            return Ok(serviceTypeService.GetAll());
        }

        [HttpGet("GetServices")]
        public async Task<IActionResult> GetServices([FromQuery] int typeId)
        {
            return Ok(servicesService.GetBy(s => s.ServiceType.ServiceTypeId == typeId));
        }

        [HttpGet("GetAllService")]
        public async Task<IActionResult> GetAllService()
        {
            return Ok(servicesService.GetAll());
        }

        [HttpGet("GetServiceById")]
        public async Task<IActionResult> GetServiceById([FromQuery] int id)
        {
            return Ok(servicesService.GetById(id));
        }


    }
}
