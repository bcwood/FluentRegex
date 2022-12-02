# Fluent Regex

[![Build status](https://ci.appveyor.com/api/projects/status/jggr83skbyp09d0e?svg=true)](https://ci.appveyor.com/project/bcwood/fluentregex) [![NuGet](https://img.shields.io/nuget/v/Fluent-Regex)](https://www.nuget.org/packages/Fluent-Regex/)

The *original* fluent regular expression builder for .NET.

## Introduction

> Some people, when confronted with a problem, think "I know, I'll use regular expressions." Now they have two problems. *- Jamie Zawinski*

Does that make this a 3rd problem?

Regular expressions can be extremely useful in the right circumstances, but they can also be terriblly complicated to understand. Consider this regular expression for parsing email addresses based on the RFC 5322 standard:

```
(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*
  |  "(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]
      |  \\[\x01-\x09\x0b\x0c\x0e-\x7f])*")
@ (?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?
  |  \[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}
       (?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:
          (?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]
          |  \\[\x01-\x09\x0b\x0c\x0e-\x7f])+)
     \])
```

What human can possibly read and understand that? 

In an effort to create a more readable method of writing regular expressions in .NET, I've created **FluentRegex**.

## Install from NuGet

    Install-Package Fluent-Regex

## Examples

Let's use a simpler email regular expression to demonstrate some of the library's capabilities.

Normally, we'd write the regular expression something like this:
```
string regex = @"^[a-zA-Z\d\.-_]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,4}$";
```

With FluentRegex, we can express it like this:
```
Pattern p = Pattern.With
                   .StartOfLine
                   .Set(Pattern.With.Letter.Digit.Literal(".-_")).Repeat.OneOrMore
                   .Literal("@")
                   .Set(Pattern.With.Letter.Digit.Literal(".-")).Repeat.OneOrMore
                   .Literal(".")
                   .Set(Pattern.With.Letter).Repeat.Times(2, 4)
                   .EndOfLine;
```
