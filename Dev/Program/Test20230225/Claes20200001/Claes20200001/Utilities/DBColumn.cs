using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Utilities
{
	public interface DBColumn
	{
		string ToDBValueString(string value);
		string FromDBValueString(string value);
	}
}
