

using FastCreditCodingChallange.Utility.Constants;

namespace FastCreditCodingChallange.Utility
{
    public class PaginationMetaData
    {
        public PaginationMetaData(int pageNumber, int pageSize, int totalPages, int totalRecords)
        {
            PageIndex = pageNumber == 0 ? PaginationConstants.DEFAULT_PAGE_NUMBER : pageNumber;
            PageSize = pageSize == 0 ? PaginationConstants.DEFAULT_PAGE_SIZE : pageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
