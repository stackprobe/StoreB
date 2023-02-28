using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using System.IO;

namespace Charlotte.Utilities
{
	public class Database
	{
		/// <summary>
		/// エスキューライトの実行ファイルのフルパス
		/// ★空白を含まないこと。
		/// </summary>
		private const string SqliteProgram = @"C:\Berry\app\sqlite-tools-win32-x86-3410000\sqlite3.exe";

		/// <summary>
		/// データベースのファイル名
		/// ★アスキー文字のみであること。
		/// ★空白を含まないこと。
		/// </summary>
		private const string DBFileName = "DB";

		// ----

		private string DBDir;

		public Database(string dbDir)
		{
			this.DBDir = SCommon.MakeFullPath(dbDir);

			SCommon.CreateDir(this.DBDir);
		}

		public void Execute(string query, Action<string[]> reaction)
		{
			using (WorkingDir wd = new WorkingDir())
			{
				string queryFile = wd.MakePath();
				string resultFile = wd.MakePath();

				File.WriteAllText(queryFile, query, Encoding.ASCII);

				SCommon.Batch(
					new string[]
					{
						SqliteProgram + " " + DBFileName + " < \"" + queryFile + "\" > \"" + resultFile + "\"",
					},
					this.DBDir
					);

				if (reaction != null)
				{
					using (StreamReader reader = new StreamReader(resultFile, Encoding.ASCII))
					{
						for (; ; )
						{
							string line = reader.ReadLine();

							if (line == null)
								break;

							reaction(line.Split('|'));
						}
					}
				}
			}
		}

		public string[][] GetResultSet(string query)
		{
			List<string[]> rows = new List<string[]>();

			this.Execute(query, row => rows.Add(row));

			return rows.ToArray();
		}

		public void InsertRows(string table, string[] columns, Func<string, string>[] valueConvs, IEnumerable<string[]> rows)
		{
			using (IEnumerator<string[]> reader = rows.GetEnumerator())
			{
				StringBuilder buff = new StringBuilder();

				while (reader.MoveNext())
				{
					if (buff == null)
					{
						buff = new StringBuilder();
						buff.Append("INSERT INTO ");
						buff.Append(table);
						buff.Append(" ( ");
						buff.Append(string.Join(", ", columns));
						buff.Append(" ) VALUES ");
					}
					else
					{
						buff.Append(", ");
					}
					string[] row = reader.Current;

					buff.Append("(");
					buff.Append(string.Join(", ", Enumerable.Range(0, row.Length).Select(colidx => valueConvs[colidx](row[colidx]))));
					buff.Append(")");

					if (30000000 < buff.Length)
					{
						this.Execute(buff.ToString(), null);
						buff = null;
					}
				}
				if (buff != null)
				{
					this.Execute(buff.ToString(), null);
					buff = null;
				}
			}
		}

		// ----

		/// <summary>
		/// バイト列 ⇒ Hex-文字列
		/// </summary>
		/// <param name="value">バイト列</param>
		/// <returns>Hex-文字列</returns>
		public static string ToHex(byte[] value)
		{
			return BitConverter.ToString(value);
		}

		/// <summary>
		/// 文字列 ⇒ Hex-文字列
		/// </summary>
		/// <param name="value">文字列</param>
		/// <returns>Hex-文字列</returns>
		public static string ToHex(string value)
		{
			return ToHex(Encoding.UTF8.GetBytes(value));
		}

		/// <summary>
		/// Hex-文字列 ⇒ バイト列
		/// </summary>
		/// <param name="value">Hex-文字列</param>
		/// <returns>バイト列</returns>
		public static byte[] ToBytes(string value)
		{
			return SCommon.Hex.ToBytes(value.Replace("-", ""));
		}

		/// <summary>
		/// Hex-文字列 ⇒ 文字列
		/// </summary>
		/// <param name="value">Hex-文字列</param>
		/// <returns>文字列</returns>
		public static string ToString(string value)
		{
			return Encoding.UTF8.GetString(ToBytes(value));
		}
	}
}
