using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Utilities;

namespace Charlotte.Tests
{
	public class Test0002
	{
		public void Test01()
		{
			Database db = new Database(@"C:\temp\DB");

			db.Execute(@"
CREATE TABLE KeyValues (
	ID,
	Name,
	Value
	)
				", null);

			// TODO
			// TODO
			// TODO
		}
	}
}
