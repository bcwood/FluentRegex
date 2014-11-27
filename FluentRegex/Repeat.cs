namespace FluentRegex
{
	public class Repeat
	{
		private Pattern _pattern;

		public Repeat(Pattern parentPattern)
		{
			_pattern = parentPattern;
		}

		public Pattern OneOrMore
		{
			get
			{
				_pattern.RegEx("+");
				return _pattern;
			}
		}

		public Pattern ZeroOrMore
		{
			get
			{
				_pattern.RegEx("*");
				return _pattern;
			}
		}

		public Pattern Optional
		{
			get
			{
				_pattern.RegEx("?");
				return _pattern;
			}
		}

		public Pattern Times(int exactly)
		{
			_pattern.RegEx(string.Format("{{{0}}}", exactly));
			return _pattern;
		}

		public Pattern Times(int min, int max)
		{
			_pattern.RegEx(string.Format("{{{0},{1}}}", min, max));
			return _pattern;
		}

		public Pattern AtLeast(int x)
		{
			_pattern.RegEx(string.Format("{{{0},}}", x));
			return _pattern;
		}

		public Pattern AtMost(int x)
		{
			_pattern.RegEx(string.Format("{{,{0}}}", x));
			return _pattern;
		}
	}
}
