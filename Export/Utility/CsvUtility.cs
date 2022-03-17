using CsvHelper;
using Export.Model;

namespace Export.Utility
{
    public static class CsvUtility
    {
        public static FileInfoModel GetFileContent<T>(List<T> list, string filename, string contentType = "text/csv")
        {
            if (list == null)
                list = new List<T>();
            var stream = new MemoryStream();
            using (var writeFile = new StreamWriter(stream, leaveOpen: true))
            {
                var csv = new CsvWriter(writeFile, new System.Globalization.CultureInfo("en-US"), true);
                csv.WriteRecords(list);
            }
            stream.Position = 0; //reset stream

            return new FileInfoModel()
            {
                FileName = filename,
                Stream = stream.ToArray(),
                ContentType = contentType
            };
        }
    }
}
