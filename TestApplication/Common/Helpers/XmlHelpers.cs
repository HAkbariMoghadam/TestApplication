using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Helpers
{
	public class XmlHelpers
	{
		public static T ReadFile<T>(Stream reader) where T : class
		{
			reader.Position = 0;
			var XmlSerializer = new XmlSerializer(typeof(T));

			return XmlSerializer.Deserialize(reader) as T;

		}
	}
}
