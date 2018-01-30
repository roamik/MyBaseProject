using Test.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.DAL.Abstract;
using System.Linq;
using Test.MODELS.Entities;

namespace Test.API.Helpers
{
    public class DataBaseInitializer : IDataBaseInitializer
    {
        private readonly IUnitOfWork _unitOfWork;
        public DataBaseInitializer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        //In this function you can add some testing records into your database 
        //Warning!!! to avoid duplicates - check if data already exists
        public async Task Initialize()
        {
            var productsCount = await _unitOfWork.ProductsRepository.CountAsync(filters: null);
            
            if (productsCount == 0)
            {
                var products = new List<Product>
                {
                    new Product {Name = "Test", Type = "TestType"}      
                };

                //foreach (var product in products)
                //{
                //    //await _unitOfWork.ProductsRepository.AddAsync(product);
                //}

                await _unitOfWork.ProductsRepository.AddRangeAsync(products);

                await _unitOfWork.Save();
            }
        }
    }
}
