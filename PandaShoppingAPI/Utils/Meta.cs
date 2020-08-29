using PandaShoppingAPI.Services;
using System;

namespace PandaShoppingAPI.Utils
{
    public class Meta
    {
        public const int MAX_PAGE_SIZE = 500;

        public int total { get; set; }
        public int? page_size { get; set; }
        public int? page_number { get; set; }

        private Meta(int total, int? page_size, int? page_number)
        {
            this.total = total;
            this.page_size = page_size;
            this.page_number = page_number;
            if (page_size != null && page_number != null
                && page_size > 0 && page_number > 0 && page_size <= MAX_PAGE_SIZE)
            {
                this.page_size = (int)page_size;
                this.page_number = (int)page_number;
            }
            else
            {
                this.page_size = 50;
                this.page_number = 1;
            }
        }

        internal static Meta ProcessAndCreate<TFilter>(int total, TFilter filter) where TFilter : Filter
        {
            return ProcessAndCreate(total, filter.pageSize, filter.pageNum);
        }

        internal static Meta ProcessAndCreate(int total, int? page_size, int? page_number)
        {
            return new Meta(total, page_size, page_number);
        }
    }
}