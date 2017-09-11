using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
	public static class DateTimeHelpers
	{
		public static double YearsDiffrent(this DateTime current,DateTime begin)
		{
			return (current - begin).TotalDays / 365.25;
		}
	}
}
