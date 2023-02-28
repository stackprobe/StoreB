using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		private List<string> ColumnNames = new List<string>();

		public void AddColumn(DBColumn column, string name)
		{
			this.Columns.Add(column);
			this.ColumnNames.Add(name);
		}

		public void Create()
		{
			StringBuilder buff = new StringBuilder();

			buff.Append("CREATE TABLE ");
			buff.Append(this.TableName);
			buff.Append(" ( ");
			buff.Append(string.Join(" , ", this.ColumnNames));
			buff.Append(" );");

			this.DB.Execute(buff.ToString(), resultFile => { });
		}

		public void Drop()
		{
			StringBuilder buff = new StringBuilder();

			buff.Append("DROP TABLE ");
			buff.Append(this.TableName);
			buff.Append(";");

			this.DB.Execute(buff.ToString(), resultFile => { });
		}

		//
		//
		//
	}
}
