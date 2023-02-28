using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Utilities
{
	public interface DBColumn
	{
		string ToDBValueString(long value);
		string ToDBValueString(string value);

		long ToLongFromDBValueString(string value);
		string ToStringFromDBValueString(string value);
	}
}
