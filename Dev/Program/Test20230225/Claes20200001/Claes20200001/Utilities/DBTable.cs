using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Charlotte.Utilities
{
	public class DBTable
	{
		private Database DB;
		private string TableName;

		public DBTable(Database db, string name)
		{
			this.DB = db;
			this.TableName = name;
		}

		private List<DBColumn> Columns = new List<DBColumn>();

		public void AddColumn(DBColumn column, string name)
		{
			this.Columns.Add(column);
			column.Name = name;
		}

		public void Create()
		{
			StringBuilder buff = new StringBuilder();

			buff.Append("CREATE TABLE ");
			buff.Append(this.TableName);
			buff.Append(" ( ");
			buff.Append(string.Join(" , ", this.Columns.Select(v => v.Name)));
			buff.Append(" );");

			this.DB.Execute(buff.ToString(), resultFile => { });
		}

		public void Drop()
		{
			StringBuilder buff = new StringBuilder();

			buff.Append("DROP TABLE ");
			buff.Append(this.TableName);
			buff.Append(" ;");

			this.DB.Execute(buff.ToString(), resultFile => { });
		}

		public void Select(Action<string[]> values, string condition = "1 = 1", Action<string[]> reaction)
		{
			StringBuilder buff = new StringBuilder();

			buff.Append("SELECT ");
			buff.Append(string.Join(" , ", this.Columns.Select(v => v.Name)));
			buff.Append(" FROM ");
			buff.Append(this.TableName);
			buff.Append(" WHERE ");
			buff.Append(condition);

			this.DB.Execute(buff.ToString(), resultFile =>
			{
				using (StreamReader reader = new StreamReader(resultFile, Encoding.UTF8))
				{
					for (; ; )
					{
						string line = reader.ReadLine();

						if (line == null)
							break;

						string[] row = line.Split('|');

						row = Enumerable.Range(0, row.Length)
							.Select(index => this.Columns[index].ToDBValueString(row[index]))
							.ToArray();

						reaction(row);
					}
				}
			});
		}

		public void Insert(IEnumerable<string[]> rows)
		{
			using (IEnumerator<string[]> reader = rows.GetEnumerator())
			{
				//
				//
				//
			}
		}
	}
}
