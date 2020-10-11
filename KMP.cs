using System;

namespace Algorithms.Strings
{
	public static class KMP
	{
		private static int[] GetPrefix(string s)
		{
			int[] result = new int[s.Length];
			result[0] = 0;
			int index = 0;

			for (int i = 1; i < s.Length; i++)
			{
				while (index >= 0 && s[index] != s[i]) 
				{
					index--; 
				}

				index++;
				result[i] = index;
			}

			return result;
		}

		public static int FindSubstring(string pattern, string text)
		{
			int[] pf = GetPrefix(pattern);
			int index = 0;

			for (int i = 0; i < text.Length; i++)
			{
				while (index > 0 && pattern[index] != text[i]) 
				{ 
					index = pf[index - 1]; 
				}

				if (pattern[index] == text[i]) 
				{
					index++;
				}

				if (index == pattern.Length)
				{
					return i - index + 1;
				}
			}

			return -1;
		}
	}
}
