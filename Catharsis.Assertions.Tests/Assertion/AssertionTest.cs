using Xunit;
using FluentAssertions;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Assertion"/>.</para>
/// </summary>
public sealed class AssertionTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  [Fact]
  public void Constructors()
  {
    new Assertion(true).With(assertion => assertion.GetFieldValue<bool>("state").Should().BeTrue());
    new Assertion(false).With(assertion => assertion.GetFieldValue<bool>("state").Should().BeFalse());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Assertion.Valid(bool)"/> method.</para>
  /// </summary>
  [Fact]
  public void Valid_Method()
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

  /// <summary>
  ///   <para>Performs testing of <see cref="Assertion.Invalid(bool)"/> method.</para>
  /// </summary>
  [Fact]
  public void Invalid_Method()
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
}