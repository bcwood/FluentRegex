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
		}

		[Test]
		public void EndOfLine()
		{
			Pattern p = Pattern.With.EndOfLine;

			Assert.That(p.ToString(), Is.EqualTo("$"));
		}

		[Test]
		public void Anything()
		{
			Pattern p = Pattern.With.Anything;

			Assert.That(p.ToString(), Is.EqualTo("."));
		}

		[Test]
		public void Literal()
		{
			Pattern p = Pattern.With.Literal("a");

			Assert.That(p.ToString(), Is.EqualTo("a"));
		}

		[Test]
		public void Digit()
		{
			Pattern p = Pattern.With.Digit;

			Assert.That(p.ToString(), Is.EqualTo("\\d"));
		}

		[Test]
		public void NonDigit()
		{
			Pattern p = Pattern.With.NonDigit;

			Assert.That(p.ToString(), Is.EqualTo("\\D"));
		}

		[Test]
		public void Word()
		{
			Pattern p = Pattern.With.Word;

			Assert.That(p.ToString(), Is.EqualTo("\\w"));
		}

		[Test]
		public void NonWord()
		{
			Pattern p = Pattern.With.NonWord;

			Assert.That(p.ToString(), Is.EqualTo("\\W"));
		}

		[Test]
		public void WordBoundary()
		{
			Pattern p = Pattern.With.WordBoundary;

			Assert.That(p.ToString(), Is.EqualTo("\\b"));
		}

		[Test]
		public void Letter()
		{
			Pattern p = Pattern.With.Letter;

			Assert.That(p.ToString(), Is.EqualTo("a-zA-Z"));
		}

		[Test]
		public void LowercaseLetter()
		{
			Pattern p = Pattern.With.LowercaseLetter;

			Assert.That(p.ToString(), Is.EqualTo("a-z"));
		}

		[Test]
		public void UppercaseLetter()
		{
			Pattern p = Pattern.With.UppercaseLetter;

			Assert.That(p.ToString(), Is.EqualTo("A-Z"));
		}

		[Test]
		public void Whitespace()
		{
			Pattern p = Pattern.With.Whitespace;

			Assert.That(p.ToString(), Is.EqualTo("\\s"));
		}

		[Test]
		public void NonWhitespace()
		{
			Pattern p = Pattern.With.NonWhitespace;

			Assert.That(p.ToString(), Is.EqualTo("\\S"));
		}

		[Test]
		public void Tab()
		{
			Pattern p = Pattern.With.Tab;

			Assert.That(p.ToString(), Is.EqualTo("\\t"));
		}

		[Test]
		public void CarriageReturn()
		{
			Pattern p = Pattern.With.CarriageReturn;

			Assert.That(p.ToString(), Is.EqualTo("\\r"));
		}

		[Test]
		public void Newline()
		{
			Pattern p = Pattern.With.Newline;

			Assert.That(p.ToString(), Is.EqualTo("\\n"));
		}
	}
}
