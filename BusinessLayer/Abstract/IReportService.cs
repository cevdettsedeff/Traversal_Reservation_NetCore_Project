using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReportService
    {
        byte[] ExcelList<T>(List<T> list) where T : class;
    }
}
