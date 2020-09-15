using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaShoppingAPI.Models
{
    public class SearchSuggestionRequest
    {
        public int? categoryId { get; set; }
        public int suggestionNum { get; set; } = 10;
        public string q { get; set; } = "";
    }
}