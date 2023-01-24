using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : BaseService<Product>
    {
        private readonly IBaseRepository<Product> _baseRepository;

        public ProductService(IBaseRepository<Product> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;   
        }

        public void DeleteLogic(int id)
        {
            var entity = _baseRepository.GetById(id);
            if (entity != null)
            {
                entity.Status = ProductStatus.Inactive;
                Update<ProductValidator>(entity);
            }

            throw new Exception("Esse produto não existe no banco de dados!");
        }
    }
}
