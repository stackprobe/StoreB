using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Utilities
{
	public abstract class DBColumn
	{
		public string Name;

		public abstract string ToDBValueString(string value);
		public abstract string FromDBValueString(string value);
	}
}
