using AutoMapper;
using Business.Models;
using DataAccess.Repository;
using Entities.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class CategoryBusiness
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger _logger;
        private readonly IMapper mapper = AutoMapperConfiguration.GetMapperProperty();

        public CategoryBusiness(ICategoryRepository categoryRepository, ILogger<CategoryBusiness> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task<CategoryAddDto> GetCategoryById(int categoryId)
        {
            try
            {
                Category category = await _categoryRepository.GetCategoryById(categoryId);
                CategoryAddDto categoryDto = mapper.Map<CategoryAddDto>(category);
                return categoryDto;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                return null;
            }
        }

        public async Task<Category> AddCategory(CategoryAddDto categoryAdd)
        {
            Category newCategory = mapper.Map<Category>(categoryAdd);

            return await _categoryRepository.AddCategory(newCategory);
        }
    }
}
