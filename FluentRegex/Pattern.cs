using System;
using System.Text;

namespace FluentRegex
{
	public class Pattern
	{
		private const string SPECIAL_CHARS = @"^$.|{}[]()*+?\";

		private StringBuilder _builder = new StringBuilder();

		/// <summary>
		/// Static method for getting new Pattern instance.
		/// </summary>
		public static Pattern With
		{
			get { return new Pattern(); }
		}

		/// <summary>
		/// Compiles the pattern into a regular expression string.
		/// </summary>
		/// <returns>Returns the regular expression string.</returns>
		public override string ToString()
		{
			return _builder.ToString();
		}

		/// <summary>
		/// Adds an explicit regex to the pattern.
		/// </summary>
		/// <param name="regex">Regex to add.</param>
		public Pattern RegEx(string regex)
		{
			_builder.Append(regex);
			return this;
		}

		public Pattern StartOfLine
		{
			get
			{
				_builder.Append("^");
				return this;
			}
		}

		public Pattern EndOfLine
		{
			get
			{
				_builder.Append("$");
				return this;
			}
		}

		public Pattern Anything
		{
			get
			{
				_builder.Append(".");
				return this;
			}
		}

		public Pattern Literal(string literal)
		{
			// handle special chars
			foreach (char c in literal)
			{
				if (SPECIAL_CHARS.IndexOf(c) >= 0)
					_builder.AppendFormat(@"\{0}", c);
				else
					_builder.Append(c);
			}

			return this;
		}

		public Pattern Digit
		{
			get
			{
				_builder.Append("\\d");
				return this;
			}
		}

		public Pattern NonDigit
		{
			get
			{
				_builder.Append("\\D");
				return this;
			}
		}

		public Pattern Word
		{
			get
			{
				_builder.Append("\\w");
				return this;
			}
		}

		public Pattern NonWord
		{
			get
			{
				_builder.Append("\\W");
				return this;
			}
		}

		public Pattern WordBoundary
		{
			get
			{
				_builder.Append("\\b");
				return this;
			}
		}

		public Pattern Letter
		{
			get
			{
				_builder.Append("a-zA-Z");
				return this;
			}
		}

		public Pattern LowercaseLetter
		{
			get
			{
				_builder.Append("a-z");
				return this;
			}
		}

		public Pattern UppercaseLetter
		{
			get
			{
				_builder.Append("A-Z");
				return this;
			}
		}

		public Pattern Whitespace
		{
			get
			{
				_builder.Append("\\s");
				return this;
			}
		}

		public Pattern NonWhitespace
		{
			get
			{
				_builder.Append("\\S");
				return this;
			}
		}

		public Pattern Tab
		{
			get
			{
				_builder.Append("\\t");
				return this;
			}
		}

		public Pattern CarriageReturn
		{
			get
			{
				_builder.Append("\\r");
				return this;
			}
		}

		public Pattern Newline
		{
			get
			{
				_builder.Append("\\n");
				return this;
			}
		}

		public Pattern Group(Pattern pattern)
		{
			_builder.AppendFormat("({0})", pattern);
			return this;
		}
		
		public Pattern NamedGroup(string groupName, Pattern pattern)
		{
			// Check if groupName contains any invalid characters
			foreach (char c in groupName)
			{
				if (!char.IsLetterOrDigit(c) && c != '_')
				{
					throw new ArgumentException("Invalid group name: " + groupName);
				}
			}
			
			_builder.AppendFormat("(?<{0}>{1})", groupName, pattern);
			return this;
		}

		public Pattern Set(Pattern pattern)
		{
			_builder.AppendFormat("[{0}]", pattern);
			return this;
		}

		public Pattern NegatedSet(Pattern pattern)
		{
			_builder.AppendFormat("[^{0}]", pattern);
			return this;
		}

		public Pattern Choice(Pattern firstChoice, Pattern secondChoice, params Pattern[] additionalChoices)
		{
			_builder.AppendFormat("({0}|{1}", firstChoice, secondChoice);

			foreach (Pattern choice in additionalChoices)
				_builder.AppendFormat("|{0}", choice);

			_builder.Append(")");
			return this;
		}

		public Repeat Repeat
		{
			get { return new Repeat(this); }
		}
	}
}
