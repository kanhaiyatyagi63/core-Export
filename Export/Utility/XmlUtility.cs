using Export.Extensions;
using Export.Model;
using System.Text;
using System.Xml;

namespace Export.Utility
{
    public static class XmlUtility
    {
        /// <summary>
        /// This method is used to generate the xml file of one level
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filename"></param>
        /// <param name="rootElementName"></param>
        /// <param name="childElementName"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static FileInfoModel GetFileContent<T>(List<T> list, string filename, string rootElementName, string childElementName, string contentType = "application/xml")
        {
            if (list == null)
                list = new List<T>();
            var properties = ObjectExtension.GetPropertyAndDataType<T>();
            var propertiesWithIndex = properties.Select((Entry, Index) => new { Entry, Index = Index + 1 });
            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement(rootElementName);
            xml.AppendChild(root);

            foreach (var item in list)
            {
                if (item != null)
                {
                    XmlElement child = xml.CreateElement(childElementName);

                    foreach (var prop in propertiesWithIndex)
                    {
                        child.SetAttribute(prop.Entry.Key, item.GetValueFromPropertyName(prop.Entry.Key).ToString());
                    }
                    root.AppendChild(child);
                }
            }
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(xml.OuterXml.ToString());

            return new FileInfoModel()
            {
                FileName = filename,
                Stream = byteArray,
                ContentType = contentType
            };
        }
    }
}
