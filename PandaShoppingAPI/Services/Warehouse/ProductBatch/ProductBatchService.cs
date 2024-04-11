using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.Services
{
    public class ProductBatchService: BaseService<IProductBatchRepo, ProductBatch, ProductBatchModel, Filter>, IProductBatchService
    {
        private readonly IProductBatchInventoryRepo _batchInventoryRepo;
        public ProductBatchService(IProductBatchRepo repo, IProductBatchInventoryRepo batchInventoryRepo) : base(repo)
        {
            _batchInventoryRepo = batchInventoryRepo;
        }

        public List<ProductBatch> CreateMany(List<ProductBatchModel> requestModel)
        {
            List<ProductBatch> batches = _repo.InsertRange(Mapper.Map<List<ProductBatch>>(requestModel));
            _batchInventoryRepo.InsertRange(batches.Select((batch) => new ProductBatchInventory()
            {
                productBatchId = batch.id,
                remainingNumber = batch.number
            }).ToList());
            return batches;
        }

        public override ProductBatch Insert(ProductBatchModel requestModel)
        {
            ProductBatch batch = base.Insert(requestModel);
            ProductBatchInventory bathInventory = new ProductBatchInventory()
            {
                productBatchId = batch.id,
                remainingNumber = batch.number,
            };
            _batchInventoryRepo.Insert(bathInventory);
            return batch;
        }

    }
}
