using System;
using System.IO;
using System.Xml.Serialization;

namespace GroupExpensesManager
{
    internal static class XmlSerializationUtils
    {
        public static string SerializeObject<T>(T toSerialise) where T : class
        {
            return SerializeObject(toSerialise, toSerialise.GetType());
        }

        public static string SerializeObject<T>(T toSerialise, Type type) where T : class
        {
            if (toSerialise == null)
                return string.Empty;

            StringWriter textWriter = new StringWriter();

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                xmlSerializer.Serialize(textWriter, toSerialise);
            }
            catch (Exception e)
            {
                throw new Exception("Serialisation failed:\n\t" + e.Message);
            }

            return textWriter.ToString();
        }

        public static T DeserialiseObject<T>(string toDeserialise) where T : class
        {
            // TODO investigate why this breaks deserialisation: http://www.cl.cam.ac.uk/~mgk25/ucs/examples/UTF-8-test.txt

            if (string.IsNullOrEmpty(toDeserialise))
                return null;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader textReader = new StringReader(toDeserialise);

            return (T)xmlSerializer.Deserialize(textReader);
        }
    }
}
