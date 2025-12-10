namespace OfficeLunch.Application.Common.Wrappers
{
    public class PagedResponse<T> : ApiResponse<List<T>>
    {
        // Current page number (starting from 1)
        public int PageNumber { get; set; }

        // Number of items per page
        public int PageSize { get; set; }

        // Total number of pages based on total records and page size
        public int TotalPages { get; set; }

        // Total number of records in the full dataset
        public int TotalRecords { get; set; }

        public PagedResponse(List<T> data, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;

            // Calculate the total number of pages
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            // Set base ApiResponse fields
            this.Data = data;
            this.Succeeded = true;
            this.Message = "Success";
        }
    }
}
