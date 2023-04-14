using System.Text.RegularExpressions;
using NUnit.Framework;

namespace FluentRegex.Tests
{
	/// <summary>
	/// A set of simple tests which test only a single property or method.
	/// </summary>
	[TestFixture]
	public class SimplePatternTests
	{
		[Test]
		public void StartOfLine()
		{
			Pattern p = Pattern.With.StartOfLine;

			Assert.That(p.ToString(), Is.EqualTo("^"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void EndOfLine()
		{
			Pattern p = Pattern.With.EndOfLine;

			Assert.That(p.ToString(), Is.EqualTo("$"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Anything()
		{
			Pattern p = Pattern.With.Anything;

			Assert.That(p.ToString(), Is.EqualTo("."));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Literal()
		{
			Pattern p = Pattern.With.Literal("a");

			Assert.That(p.ToString(), Is.EqualTo("a"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Digit()
		{
			Pattern p = Pattern.With.Digit;

			Assert.That(p.ToString(), Is.EqualTo("\\d"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void NonDigit()
		{
			Pattern p = Pattern.With.NonDigit;

			Assert.That(p.ToString(), Is.EqualTo("\\D"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Word()
		{
			Pattern p = Pattern.With.Word;

			Assert.That(p.ToString(), Is.EqualTo("\\w"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void NonWord()
		{
			Pattern p = Pattern.With.NonWord;

			Assert.That(p.ToString(), Is.EqualTo("\\W"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void WordBoundary()
		{
			Pattern p = Pattern.With.WordBoundary;

			Assert.That(p.ToString(), Is.EqualTo("\\b"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Letter()
		{
			Pattern p = Pattern.With.Letter;

			Assert.That(p.ToString(), Is.EqualTo("a-zA-Z"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void LowercaseLetter()
		{
			Pattern p = Pattern.With.LowercaseLetter;

			Assert.That(p.ToString(), Is.EqualTo("a-z"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void UppercaseLetter()
		{
			Pattern p = Pattern.With.UppercaseLetter;

			Assert.That(p.ToString(), Is.EqualTo("A-Z"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Whitespace()
		{
			Pattern p = Pattern.With.Whitespace;

			Assert.That(p.ToString(), Is.EqualTo("\\s"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void NonWhitespace()
		{
			Pattern p = Pattern.With.NonWhitespace;

			Assert.That(p.ToString(), Is.EqualTo("\\S"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Tab()
		{
			Pattern p = Pattern.With.Tab;

			Assert.That(p.ToString(), Is.EqualTo("\\t"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void CarriageReturn()
		{
			Pattern p = Pattern.With.CarriageReturn;

			Assert.That(p.ToString(), Is.EqualTo("\\r"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Newline()
		{
			Pattern p = Pattern.With.Newline;

			Assert.That(p.ToString(), Is.EqualTo("\\n"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}
	}
}
