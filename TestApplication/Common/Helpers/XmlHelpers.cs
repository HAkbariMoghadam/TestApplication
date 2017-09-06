using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Helpers
{
	public class XmlHelpers
	{
		public T ReadFile<T>(TextReader reader) where T : class
		{
			using (var xmlReader = XmlReader.Create(reader, new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document }))
			{
				return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
			}
		}
	}
}
