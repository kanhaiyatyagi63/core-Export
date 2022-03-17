using Export.Model;
using Newtonsoft.Json;
using System.Text;

namespace Export.Utility
{
    public static class JsonUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filename"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static FileInfoModel GetFileContent<T>(List<T> list, string filename, string contentType = "application/json")
        {

            if (list == null)
                list = new List<T>();
            string jsonProductList = JsonConvert.SerializeObject(list);
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(jsonProductList);

            return new FileInfoModel()
            {
                FileName = filename,
                Stream = byteArray,
                ContentType = contentType
            };

        }
    }
}
