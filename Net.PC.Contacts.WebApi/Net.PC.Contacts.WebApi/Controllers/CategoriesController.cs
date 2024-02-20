﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.PC.Contacts.Repository.Entities;
using Net.PC.Contacts.Repository.Repository;
using Net.PC.Contacts.WebApi.Models;

namespace Net.PC.Contacts.WebApi.Controllers
{
    [Route("api/categories")]
    [Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = _categoryRepository.GetAll();

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(SubCategoryRequest subCategoryRequest)
        {
            var subCategory = _mapper.Map<SubCategory>(subCategoryRequest);

            if (subCategory != null)
            {
                _categoryRepository.AddSubcategory(subCategory);
            }

            return Ok();
        }
    }
}
