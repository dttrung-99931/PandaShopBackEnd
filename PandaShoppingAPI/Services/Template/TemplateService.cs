using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.DataAccesses.Repos;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Services
{
    public class TemplateService : BaseService<ITemplateRepo, Template, TemplateModel, TemplateFilter>, 
        ITemplateService
    {
        private readonly IPropertyTemplateRepo _propertyTemplateRepo;
        private readonly IPropertyTemplateValueRepo _propertyTemplateValueRepo;

        public TemplateService(ITemplateRepo repo,
            IPropertyTemplateRepo propertyTemplateRepo,
            IPropertyTemplateValueRepo propertyTemplateValueRepo
            ) : base(repo)
        {
            _propertyTemplateRepo = propertyTemplateRepo;
            _propertyTemplateValueRepo = propertyTemplateValueRepo;
        }

        public void AddPropertyValues(int templateId, PropertyValuesModel model)
        {
            var templatePropertyId = _propertyTemplateRepo.Get(templateId, model.propertyId)?.id;

            if (templatePropertyId != null)
            {
                throw new ConflictException();
            }

            var propertyTemplateId = _propertyTemplateRepo.Insert(
                    new PropertyTemplate()
                    {
                        templateId = templateId,
                        propertyId = model.propertyId
                    }
                ).id;
            
            _propertyTemplateValueRepo.InsertRange(
                propertyTemplateId, model.values
            );
        }

        /***
         * Delete property value entity by templateId and propertyId
         * 
         * @Throw KeyNotFoundException
         */
        public void DeletePropertyValues(int templateId, int propertyId)
        {
            var templatePropertyId = _propertyTemplateRepo.Get(templateId, propertyId)?.id;
            if (templatePropertyId != null)
            {
                _propertyTemplateRepo.Delete(templatePropertyId);
            }
            else throw new KeyNotFoundException(
                string.Format("Not found property id {0} of template {1}", propertyId, templateId)
            );
        }

        public void UpdatePropertyValues(int id, PropertyValuesModel model)
        {
            var templatePropertyId = _propertyTemplateRepo.Get(id, model.propertyId)?.id;

            if (templatePropertyId != null)
            {
                _propertyTemplateValueRepo.UpdateOrInsertValues(
                    (int)templatePropertyId, model.values);
            }
        }
    }
}
