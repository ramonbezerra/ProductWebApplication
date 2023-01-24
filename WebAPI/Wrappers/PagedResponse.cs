namespace WebAPI.Wrappers
{
    public class PagedResponse<TEntity> : Response<TEntity>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PagedResponse(TEntity entity, int pageNumber, int pageSize, int totalRecords) : base(entity)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            var totalPages = (double) TotalRecords / PageSize;
            if (totalPages > 0 && totalPages != double.NaN && totalPages != double.PositiveInfinity && totalPages != double.NegativeInfinity)   
                TotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        }
    }
}
