namespace API.Models
{
    public class SongModel
    {
        public class RequestParams
        {
            // max number of items per page
            const int maxPageSize = 10;
            // default number of items per page
            private int _pageSize = 5;

            // page to start at
            public int PageNumber { get; set; } = 1;

            // number of items per page
            public int PageSize
            {
                get { return _pageSize; }
                set { _pageSize = (value > maxPageSize ? _pageSize : value); }
            }
        }
    }
}
