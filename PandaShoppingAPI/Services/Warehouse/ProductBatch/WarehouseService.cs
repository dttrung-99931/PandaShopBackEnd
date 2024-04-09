using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;

namespace PandaShoppingAPI.Services
{
    public class ProductBatchService: BaseService<IProductBatchRepo, ProductBatch, ProductBatchModel, Filter>, IProductBatchService
    {
        private readonly IProductBatchInventoryRepo _batchInventoryRepo;
        public ProductBatchService(IProductBatchRepo repo, IProductBatchInventoryRepo batchInventoryRepo) : base(repo)
        {
            _batchInventoryRepo = batchInventoryRepo;
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
