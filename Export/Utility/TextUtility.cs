using Export.Extensions;
using Export.Model;
using System.Text;

namespace Export.Utility
{
    public static class TextUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filename"></param>
        /// <param name="contentType"></param>
        /// <param name="delimeter"></param>
        /// <param name="lineEndDelimeter"></param>
        /// <param name="isSortingForProperty"></param>
        /// <returns></returns>
        public static FileInfoModel GetFileContent<T>(List<T> list, string filename,
                                                          string contentType = "application/Text", string delimeter = ",",
                                                          string lineEndDelimeter = ";", bool isSortingForProperty = false)
        {
            if (list == null)
                list = new List<T>();

            var properties = ObjectExtension.GetPropertyAndDataType<T>();
            var propertiesWithIndex = properties.Select((Entry, Index) => new { Entry, Index = Index + 1 });
            if (isSortingForProperty)
            {
                propertiesWithIndex = propertiesWithIndex.OrderBy(x => x.Entry.Key).ToList();
            }
            StringBuilder sb = new StringBuilder();
            string Columns = string.Empty;

            foreach (var property in propertiesWithIndex)
            {
                Columns += $"{property.Entry.Key}{delimeter}";
            }

            sb.Append(Columns.Remove(Columns.Length - 1, 1) + lineEndDelimeter);
            foreach (var item in list)
            {
                if (item != null)
                {
                    string row = string.Empty;

                    foreach (var x in propertiesWithIndex)
                        row += $"{item.GetValueFromPropertyName(x.Entry.Key).ToString()}{delimeter}";

                    sb.Append(row.Remove(row.Length - 1, 1) + lineEndDelimeter);
                }
            }
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(sb.ToString());
            return new FileInfoModel()
            {
                FileName = filename,
                Stream = byteArray,
                ContentType = contentType
            };
        }
    }
}
