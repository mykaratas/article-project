using System;
using System.Collections.Generic;

namespace article.api.Response
{
    public class PagingInfo
    {
        public int PageNo { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public long TotalRecordCount { get; set; }
    }

    public class Response
    {
        public double StatusCode { get; set; }

        public string Message { get; set; }
    }


    public class PagedResult<T>
    {
        public object Data { get; private set; }

        public PagingInfo Paging { get; private set; }

        public Response response { get; private set; }

        public PagedResult(IEnumerable<T> items, int pageNo, int pageSize, long totalRecordCount,
            string message = "İşleminiz Başarıyla Gerçekleşmiştir." ,double statuscode = 200)
        {
            Data = new List<T>(items);
            Paging = new PagingInfo
            {
                PageNo = pageNo,
                PageSize = pageSize,
                TotalRecordCount = totalRecordCount,
                PageCount = totalRecordCount > 0
                    ? (int)Math.Ceiling(totalRecordCount / (double)pageSize)
                    : 0
            };

            response = new Response
            {
                StatusCode = statuscode,
                Message = message
            };
            
        }

        public PagedResult(object item , string message = "İşleminiz Başarıyla Gerçekleşmiştir.", double statuscode = 200)
        {
            Data = item;
            response = new Response
            {
                StatusCode = statuscode,
                Message = message
            };
        }

        public PagedResult(double statuscode = 200, string message = "İşleminiz Başarıyla Gerçekleşmiştir.")
        {
            response = new Response
            {
                StatusCode = statuscode,
                Message = message
            };

        }
    }


}
