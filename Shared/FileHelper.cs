namespace Shared {
	public class FileHelper {

		public static List<string> ReadFileToStringList(string path) {
			using StreamReader sr = new StreamReader(path);
			List<string> list = new List<string>();
			while (!sr.EndOfStream) {
				list.Add(sr.ReadLine() ?? "");
			}
			return list;
		}
	}
}
