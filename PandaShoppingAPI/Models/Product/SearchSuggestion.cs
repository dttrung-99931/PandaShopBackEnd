using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PandaShoppingAPI.Models
{
    public class SearchSuggestion
    {
        public List<CategoryModel> categories { get; set; }
        public List<ThumbProductResponse> products { get; set; }

        public SearchSuggestion()
        {
            this.categories = new List<CategoryModel>();
            this.products = new List<ThumbProductResponse>();
        }
    }
}
