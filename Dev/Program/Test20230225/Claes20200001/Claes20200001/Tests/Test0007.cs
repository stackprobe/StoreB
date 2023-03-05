using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Charlotte.Tests
{
	public class Test0007
	{
		public void Test01()
		{
			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)); // @"C:\Users\Public\Documents"
			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)); // @"C:\Users\<UserName>\Documents"

			// ----

			foreach (string dir in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
				Console.WriteLine(dir);

			foreach (string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
				Console.WriteLine(file);
		}

		public void Test02()
		{
			//
			//
			//
		}
	}
}
