using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Utilities;
using Charlotte.Commons;
using System.IO;

namespace Charlotte.Tests
{
	public class Test0004
	{
		private const string SQLITE_PROGRAM = @"C:\Berry\app\sqlite-tools-win32-x86-3410000\sqlite3.exe";

		public void Test01()
		{
			string[][] rows1;
			string[][] rows2;

			using (CsvFileReader reader = new CsvFileReader(@"C:\temp\Customers.csv"))
			{
				rows1 = reader.ReadToEnd();
			}

			File.WriteAllText(@"C:\temp\1.txt", "SELECT * FROM Customer", Encoding.ASCII);

			SCommon.Batch(
				new string[]
				{
					@"C:\Berry\app\sqlite-tools-win32-x86-3410000\sqlite3.exe DB < 1.txt > 2.txt"
				},
				@"C:\temp",
				SCommon.StartProcessWindowStyle_e.MINIMIZED
				);

			rows2 = File.ReadAllLines(@"C:\temp\2.txt", Encoding.ASCII).Select(line =>
			{
				string[] row = line.Split('|');

				for (int colidx = 1; colidx <= 6; colidx++)
					row[colidx] = SCommon.ENCODING_SJIS.GetString(SCommon.Hex.ToBytes(row[colidx].Replace("-", "")));

				return row;
			})
			.ToArray();

			// ----

			Array.Sort(rows1, (a, b) => SCommon.Comp(a[0], b[0]));
			Array.Sort(rows2, (a, b) => SCommon.Comp(a[0], b[0]));

			if (SCommon.Comp(rows1, rows2, (a, b) => SCommon.Comp(a, b, SCommon.Comp)) != 0)
				throw null; // BUG !!!
		}
	}
}
