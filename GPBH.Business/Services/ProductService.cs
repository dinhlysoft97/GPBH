using GPBH.Business.DTO;
using GPBH.Data;
using GPBH.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GPBH.Business
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductDto> GetAll()
        {

            var products = _unitOfWork.Repository<Product>().GetAll();
            return products.Select(z => new ProductDto { Name = z.Name, ProductId = z.ProductId, Quantity = z.Quantity }).ToList();
        }
    }
}