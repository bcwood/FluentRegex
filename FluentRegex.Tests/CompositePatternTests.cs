using System.Text.RegularExpressions;
using NUnit.Framework;

namespace FluentRegex.Tests
{
	/// <summary>
	/// A set of slightly more complex tests which test multiple properties/methods at once.
	/// </summary>
	[TestFixture]
	public class CompositePatternTests
	{
		[Test]
		public void Group()
		{
			Pattern p = Pattern.With.Group(Pattern.With
												  .Digit
												  .Word);

			Assert.That(p.ToString(), Is.EqualTo(@"(\d\w)"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}
		
		[Test]
		public void NamedGroup()
		{
			Pattern p = Pattern.With.NamedGroup("Name", Pattern.With
				.Digit
				.Word);

			Assert.That(p.ToString(), Is.EqualTo(@"(?<Name>\d\w)"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}
		
		[Test]
		public void NamedGroup_InvalidGroupName_ThrowsArgumentException()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				Pattern p = Pattern.With.NamedGroup("Invalid!Name", Pattern.With
					.Digit
					.Word);
			});
		}


		[Test]
		public void Set()
		{
			Pattern p = Pattern.With.Set(Pattern.With
												.Digit
												.Word);

			Assert.That(p.ToString(), Is.EqualTo(@"[\d\w]"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}
		
		[Test]
		public void Set_With_Dash()
		{
			Pattern p = Pattern.With.Set(Pattern.With.Literal(".- _"));

			Assert.That(p.ToString(), Is.EqualTo(@"[\.\- _]"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}
		
		[Test]
		public void Set_With_Dash_And_Letters()
		{
			Pattern p = Pattern.With.Set(Pattern.With.Literal(".- _").Letter);

			Assert.That(p.ToString(), Is.EqualTo(@"[\.\- _a-zA-Z]"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void NegatedSet()
		{
			Pattern p = Pattern.With.NegatedSet(Pattern.With
													   .Digit
													   .Word);

			Assert.That(p.ToString(), Is.EqualTo(@"[^\d\w]"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Choice_With2Options()
		{
			Pattern p = Pattern.With.Choice(Pattern.With.Digit.Repeat.Times(3),
											Pattern.With.Whitespace);

			Assert.That(p.ToString(), Is.EqualTo("(\\d{3}|\\s)"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Choice_With3Options()
		{
			Pattern p = Pattern.With.Choice(Pattern.With.Digit.Repeat.Times(3),
											Pattern.With.Whitespace,
											Pattern.With.Literal("a"));

			Assert.That(p.ToString(), Is.EqualTo("(\\d{3}|\\s|a)"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Email()
		{
			string regex = @"^[a-zA-Z\d_\-\.]+@[a-zA-Z\d\.\-]+\.[a-zA-Z]{2,4}$";

			Pattern p = Pattern.With
			                   .StartOfLine
			                   .Set(Pattern.With.Letter.Digit.Literal("_-.")).Repeat.OneOrMore
			                   .Literal("@")
			                   .Set(Pattern.With.Letter.Digit.Literal(".-")).Repeat.OneOrMore
			                   .Literal(".")
			                   .Set(Pattern.With.Letter).Repeat.Times(2, 4)
			                   .EndOfLine;

			Assert.That(p.ToString(), Is.EqualTo(regex));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(regex), Throws.Nothing);
		}

		[Test]
		public void SSN()
		{
			string regex = @"^\d{3}\-?\d{2}\-?\d{4}$";

			Pattern p = Pattern.With
							   .StartOfLine
			                   .Digit.Repeat.Times(3)
			                   .Literal("-").Repeat.Optional
			                   .Digit.Repeat.Times(2)
			                   .Literal("-").Repeat.Optional
			                   .Digit.Repeat.Times(4)
			                   .EndOfLine;

			Assert.That(p.ToString(), Is.EqualTo(regex));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}
	}
}
