using BusinessLayer.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReportManager : IReportService
    {
        public byte[] ExcelList<T>(List<T> list) where T : class
        {
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Dosya-1");
            worksheet.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light10);

            return excel.GetAsByteArray();
        }
    }
}
