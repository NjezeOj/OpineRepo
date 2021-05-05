using System;
using System.Collections.Generic;
using System.Text;

namespace Opine.Shared.DTOS
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 5;
    }
}
