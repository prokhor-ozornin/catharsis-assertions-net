using Xunit;
using FluentAssertions;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Assertion"/>.</para>
/// </summary>
/// <seealso cref="Assertion"/>
public sealed class AssertionTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  [Fact]
  public void Constructors()
  {
    typeof(Assertion).Should().BeDerivedFrom<object>().And.Implement<IAssertion>();

    new Assertion(true).With(assertion => assertion.GetFieldValue<bool>("state").Should().BeTrue());
    new Assertion(false).With(assertion => assertion.GetFieldValue<bool>("state").Should().BeFalse());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Assertion.Valid(bool)"/> method.</para>
  /// </summary>
  [Fact]
  public void Valid_Method()
  {
    using (new AssertionScope())
    {
      new Assertion(true).With(assertion =>
      {
        assertion.Valid(true).Should().BeTrue();
        assertion.Valid(false).Should().BeFalse();
      });

      new Assertion(false).With(assertion =>
      {
        assertion.Valid(true).Should().BeFalse();
        assertion.Valid(false).Should().BeTrue();
      });
    }

    return;

    static void Test()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Assertion.Invalid(bool)"/> method.</para>
  /// </summary>
  [Fact]
  public void Invalid_Method()
  {
    using (new AssertionScope())
    {
      new Assertion(true).With(assertion =>
      {
        assertion.Invalid(true).Should().BeFalse();
        assertion.Invalid(false).Should().BeTrue();
      });

      new Assertion(false).With(assertion =>
      {
        assertion.Invalid(true).Should().BeTrue();
        assertion.Invalid(false).Should().BeFalse();
      });
    }

    return;

    static void Test()
    {

    }
  }
}