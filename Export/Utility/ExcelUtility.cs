using ClosedXML.Excel;
using Export.Extensions;
using Export.Model;

namespace Export.Utility
{
    public static class ExcelUtility
    {

        public static FileInfoModel GetFileContent<T>(List<T> list, string workSheetName, string filename,
                                                           string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            if (list == null)
                list = new List<T>();
            var properties = ObjectExtension.GetPropertyAndDataType<T>();
            var propertiesWithIndex = properties.Select((Entry, Index) => new { Entry, Index = Index + 1 });
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(workSheetName);
                var currentRow = 1;
                // add the header into the excel file
                foreach (var x in propertiesWithIndex)
                {
                    worksheet.Cell(currentRow, x.Index).Value = x.Entry.Key;
                }
                foreach (var item in list)
                {
                    if (item != null)
                    {
                        currentRow++;
                        // add the rows corresponding to the row and column of the excel file
                        foreach (var x in propertiesWithIndex)
                            worksheet.Cell(currentRow, x.Index).Value = item.GetValueFromPropertyName(x.Entry.Key);
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return new FileInfoModel()
                    {
                        Stream = content,
                        ContentType = contentType,
                        FileName = filename
                    };
                }
            }
        }

    }
}
