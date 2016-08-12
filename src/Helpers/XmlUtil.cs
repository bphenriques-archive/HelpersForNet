using System.IO;
using System.Xml.Serialization;

namespace HelpersForNet {
    /// <summary>
    /// Xml utilitary for save/load
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XmlUtil<T> {
        /// <summary>
        /// Loads file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T Load(string filePath) {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Couldn't find file at: " + filePath);            

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream file = new FileStream(filePath, FileMode.Open)) {
                var obj = serializer.Deserialize(file);

                if(obj == null)
                    throw new FileLoadException("Error reading file (incorrect format?) at " + filePath);                

                return (T)obj;
            }
        }

        /// <summary>
        /// Save file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public static void Save(string filePath, T obj) {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream file = new FileStream(filePath, FileMode.Create)) {
                serializer.Serialize(file, obj);
            }
        }
    }
}
