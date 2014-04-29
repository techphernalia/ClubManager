using System;

namespace Core
{
	public static class Extension
	{
		public static Int32 ToInt32(this object obj)
		{
			return Convert.ToInt32(obj);
		}

		public static Boolean ToBoolean(this object obj)
		{
			return Convert.ToBoolean(obj);
		}

		public static Double ToDouble(this object obj)
		{
			return Convert.ToDouble(obj);
		}
	}
}