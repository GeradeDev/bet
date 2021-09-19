using BestShop.Api.DAL;
using BestShop.Api.DTO;
using BestShop.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork { get; set; }
        GenericRepository<Product> _prodsRepo { get; set; }

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _prodsRepo = _unitOfWork.GetRepository<GenericRepository<Product>>();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> TestController()
        {
            try
            {
                var prods = (from products in _prodsRepo.Get()
                             select new ProductDTO
                             {
                                 Id = products.Id,
                                 Code = products.Code,
                                 Name = products.Name,
                                 Description = products.Description,
                                 AvailableQuantity = products.AvailableQuantity,
                                 Price = products.Price.ToString("N2"),
                             }).ToList();

                return Ok(prods);
            }
            catch(Exception ex)
            {
                return BadRequest($"An error occured trying to load all products. {ex.Message}");
            }
        }
    }
}
