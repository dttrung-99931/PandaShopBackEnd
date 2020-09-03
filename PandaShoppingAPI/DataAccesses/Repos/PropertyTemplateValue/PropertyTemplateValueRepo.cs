using PandaShoppingAPI.DataAccesses.EF;
using System.Collections.Generic;
using System.Linq;

namespace PandaShoppingAPI.DataAccesses.Repos
{
    public class PropertyTemplateValueRepo : BaseRepo<PropertyTemplateValue>, IPropertyTemplateValueRepo
    {
        public void InsertRange(int propertyTemplateId, List<string> values)
        {
            InsertRange(CreatePropertyTemplateValues(propertyTemplateId, values));
        }

        public void UpdateOrInsertValues(
            int templatePropertyId, 
            List<string> values)
        {
            //List<bool> exists = new List<int>();
            var originValues = Where(
                proTempValue => proTempValue.propertyTemplateId == templatePropertyId)
                .Select(proTempValue => proTempValue.value)
                .ToList();

            values.ForEach(
                v =>
                {
                    if (!originValues.Contains(v))
                    {
                        Insert(new PropertyTemplateValue()
                        {
                            propertyTemplateId = templatePropertyId,
                            value = v
                        });
                    }
                });

            DeleteIf(proTempValue => !values.Contains(proTempValue.value));
        }

        private List<PropertyTemplateValue> CreatePropertyTemplateValues(
            int propertyTemplateId,
            List<string> values)
        {
            var propertyTemplateValues = new List<PropertyTemplateValue>();

            values.ForEach(
                value => propertyTemplateValues.Add(
                    new PropertyTemplateValue()
                    {
                        propertyTemplateId = propertyTemplateId,
                        value = value
                    }));

            return propertyTemplateValues;
        }
    }
}
