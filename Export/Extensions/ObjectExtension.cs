using System.Reflection;

namespace Export.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// this method is used to get the property value from the property name of an object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns> The property value</returns>
        public static object GetValueFromPropertyName(this object obj, string propertyName)
        {
            if (obj == null)
                return string.Empty;
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }

        /// <summary>
        /// this method is used to get the property name with it type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The property name along with type</returns>
        public static Dictionary<string, Type> GetPropertyAndDataType<T>()
        {
            Type t = typeof(T);
            // Get the public and non public properties.
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            // Display the public properties.
            Dictionary<string, Type> properties = new Dictionary<string, Type>();
            // Display information for all properties.
            foreach (var propInfo in propInfos)
            {
                properties.Add(propInfo.Name, propInfo.PropertyType);
            }
            return properties;

        }
    }
}
