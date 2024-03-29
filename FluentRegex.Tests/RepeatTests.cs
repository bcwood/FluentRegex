﻿using System.Text.RegularExpressions;
using NUnit.Framework;

namespace FluentRegex.Tests
{
	[TestFixture]
	public class RepeatTests
	{
		[Test]
		public void OneOrMore()
		{
			Pattern p = Pattern.With.Literal("a").Repeat.OneOrMore;

			Assert.That(p.ToString(), Is.EqualTo("a+"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void ZeroOrMore()
		{
			Pattern p = Pattern.With.Literal("a").Repeat.ZeroOrMore;

			Assert.That(p.ToString(), Is.EqualTo("a*"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Optional()
		{
			Pattern p = Pattern.With.Literal("a").Repeat.Optional;

			Assert.That(p.ToString(), Is.EqualTo("a?"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Times_Exactly()
		{
			Pattern p = Pattern.With.Literal("a").Repeat.Times(3);

			Assert.That(p.ToString(), Is.EqualTo("a{3}"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void Times_Range()
		{
			Pattern p = Pattern.With.Literal("a").Repeat.Times(3, 5);

			Assert.That(p.ToString(), Is.EqualTo("a{3,5}"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void AtLeast()
		{
			Pattern p = Pattern.With.Literal("a").Repeat.AtLeast(3);

			Assert.That(p.ToString(), Is.EqualTo("a{3,}"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}

		[Test]
		public void AtMost()
		{
			Pattern p = Pattern.With.Literal("a").Repeat.AtMost(3);

			Assert.That(p.ToString(), Is.EqualTo("a{,3}"));
			
			// Check if the regular expression can be compiled without throwing an exception
			Assert.That(() => new Regex(p.ToString()), Throws.Nothing);
		}
	}
}
