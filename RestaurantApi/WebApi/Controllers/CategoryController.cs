using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using Application.Services.CategoryServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly GetAllCategoriesService _getAll;
        public CategoryController(GetAllCategoriesService getAll)
        {
            _getAll = getAll;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            return Ok(await _getAll.GetAllAsync());
        }
    }
}