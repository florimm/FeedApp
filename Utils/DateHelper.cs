using System;
using System.Globalization;

//Copied from StackOverflow
public class DateHelper
{

	private static string[] formats = new string[0];

	private const string format = "ddd, dd MMM yyyy HH:mm:ss K";

	public static string DateTimeFormat
	{
		get { return format; }
	}
	public static string[] DateTimePatterns
	{
		get
		{
			if (formats.Length > 0)
			{
				return formats;
			}
			else
			{
				formats = new string[35];

				// two-digit day, four-digit year patterns
				formats[0] = "ddd',' dd MMM yyyy HH':'mm':'ss'.'fffffff zzzz";
				formats[1] = "ddd',' dd MMM yyyy HH':'mm':'ss'.'ffffff zzzz";
				formats[2] = "ddd',' dd MMM yyyy HH':'mm':'ss'.'fffff zzzz";
				formats[3] = "ddd',' dd MMM yyyy HH':'mm':'ss'.'ffff zzzz";
				formats[4] = "ddd',' dd MMM yyyy HH':'mm':'ss'.'fff zzzz";
				formats[5] = "ddd',' dd MMM yyyy HH':'mm':'ss'.'ff zzzz";
				formats[6] = "ddd',' dd MMM yyyy HH':'mm':'ss'.'f zzzz";
				formats[7] = "ddd',' dd MMM yyyy HH':'mm':'ss zzzz";

				// two-digit day, two-digit year patterns
				formats[8] = "ddd',' dd MMM yy HH':'mm':'ss'.'fffffff zzzz";
				formats[9] = "ddd',' dd MMM yy HH':'mm':'ss'.'ffffff zzzz";
				formats[10] = "ddd',' dd MMM yy HH':'mm':'ss'.'fffff zzzz";
				formats[11] = "ddd',' dd MMM yy HH':'mm':'ss'.'ffff zzzz";
				formats[12] = "ddd',' dd MMM yy HH':'mm':'ss'.'fff zzzz";
				formats[13] = "ddd',' dd MMM yy HH':'mm':'ss'.'ff zzzz";
				formats[14] = "ddd',' dd MMM yy HH':'mm':'ss'.'f zzzz";
				formats[15] = "ddd',' dd MMM yy HH':'mm':'ss zzzz";

				// one-digit day, four-digit year patterns
				formats[16] = "ddd',' d MMM yyyy HH':'mm':'ss'.'fffffff zzzz";
				formats[17] = "ddd',' d MMM yyyy HH':'mm':'ss'.'ffffff zzzz";
				formats[18] = "ddd',' d MMM yyyy HH':'mm':'ss'.'fffff zzzz";
				formats[19] = "ddd',' d MMM yyyy HH':'mm':'ss'.'ffff zzzz";
				formats[20] = "ddd',' d MMM yyyy HH':'mm':'ss'.'fff zzzz";
				formats[21] = "ddd',' d MMM yyyy HH':'mm':'ss'.'ff zzzz";
				formats[22] = "ddd',' d MMM yyyy HH':'mm':'ss'.'f zzzz";
				formats[23] = "ddd',' d MMM yyyy HH':'mm':'ss zzzz";

				// two-digit day, two-digit year patterns
				formats[24] = "ddd',' d MMM yy HH':'mm':'ss'.'fffffff zzzz";
				formats[25] = "ddd',' d MMM yy HH':'mm':'ss'.'ffffff zzzz";
				formats[26] = "ddd',' d MMM yy HH':'mm':'ss'.'fffff zzzz";
				formats[27] = "ddd',' d MMM yy HH':'mm':'ss'.'ffff zzzz";
				formats[28] = "ddd',' d MMM yy HH':'mm':'ss'.'fff zzzz";
				formats[29] = "ddd',' d MMM yy HH':'mm':'ss'.'ff zzzz";
				formats[30] = "ddd',' d MMM yy HH':'mm':'ss'.'f zzzz";
				formats[31] = "ddd',' d MMM yy HH':'mm':'ss zzzz";

				formats[32] = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";
				formats[33] = DateTimeFormatInfo.InvariantInfo.UniversalSortableDateTimePattern;
				formats[34] = DateTimeFormatInfo.InvariantInfo.SortableDateTimePattern;

				return formats;
			}
		}
	}

	public static DateTime Parse(string s)
	{
		DateTime result;
		if (TryParse(Clean(s), out result))
		{
			return result;
		}
		else
		{
			return DateTime.UtcNow;
		}
	}


	public static string ConvertZoneToLocalDifferential(string s)
	{
		string zoneRepresentedAsLocalDifferential = String.Empty;


		if (s.EndsWith(" UT", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" UT") + 1)), "+00:00");
		}
		else if (s.EndsWith(" GMT", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" GMT") + 1)), "+00:00");
		}
		else if (s.EndsWith(" EST", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" EST") + 1)), "-05:00");
		}
		else if (s.EndsWith(" EDT", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" EDT") + 1)), "-04:00");
		}
		else if (s.EndsWith(" CST", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" CST") + 1)), "-06:00");
		}
		else if (s.EndsWith(" CDT", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" CDT") + 1)), "-05:00");
		}
		else if (s.EndsWith(" MST", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" MST") + 1)), "-07:00");
		}
		else if (s.EndsWith(" MDT", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" MDT") + 1)), "-06:00");
		}
		else if (s.EndsWith(" PST", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" PST") + 1)), "-08:00");
		}
		else if (s.EndsWith(" PDT", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" PDT") + 1)), "-07:00");
		}
		else if (s.EndsWith(" Z", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" Z") + 1)), "+00:00");
		}
		else if (s.EndsWith(" A", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" A") + 1)), "-01:00");
		}
		else if (s.EndsWith(" M", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" M") + 1)), "-12:00");
		}
		else if (s.EndsWith(" N", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" N") + 1)), "+01:00");
		}
		else if (s.EndsWith(" Y", StringComparison.OrdinalIgnoreCase))
		{
			zoneRepresentedAsLocalDifferential = String.Concat(s.Substring(0, (s.LastIndexOf(" Y") + 1)), "+12:00");
		}
		else
		{
			zoneRepresentedAsLocalDifferential = s;
		}

		return zoneRepresentedAsLocalDifferential;
	}

	public static string ToString(DateTime utcDateTime)
	{
		if (utcDateTime.Kind != DateTimeKind.Utc)
		{
			throw new ArgumentException("utcDateTime");
		}

		return utcDateTime.ToString(DateTimeFormat, DateTimeFormatInfo.InvariantInfo);
	}



	public static bool TryParse(string s, out DateTime result)
	{
		bool wasConverted = false;
		result = DateTime.MinValue;

		if (!String.IsNullOrEmpty(Clean(s)))
		{
			DateTime parseResult;
			if (DateTime.TryParseExact(ConvertZoneToLocalDifferential(Clean(s)), DateTimePatterns, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AdjustToUniversal, out parseResult))
			{
				result = DateTime.SpecifyKind(parseResult, DateTimeKind.Utc);
				wasConverted = true;
			}
		}

		return wasConverted;
	}

	public static string Clean(string input)
	{
		string data = input.Replace("\r", "");
		data = data.Replace("\t", "");
		data = data.Replace("\n", "");
		data = data.Trim();
		return data;
	}

}