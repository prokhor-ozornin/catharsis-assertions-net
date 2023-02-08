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
    new Assertion(true).With(assertion => assertion.GetFieldValue<bool>("flag").Should().BeTrue());
    new Assertion(false).With(assertion => assertion.GetFieldValue<bool>("flag").Should().BeFalse());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Assertion.Confirmed(bool)"/> method.</para>
  /// </summary>
  [Fact]
  public void Confirmed_Method()
  {
    new Assertion(true).With(assertion =>
    {
      assertion.Confirmed(true).Should().BeTrue();
      assertion.Confirmed(false).Should().BeFalse();
    });

    new Assertion(false).With(assertion =>
    {
      assertion.Confirmed(true).Should().BeFalse();
      assertion.Confirmed(false).Should().BeTrue();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Assertion.Unconfirmed(bool)"/> method.</para>
  /// </summary>
  [Fact]
  public void Unconfirmed_Method()
  {
    new Assertion(true).With(assertion =>
    {
      assertion.Unconfirmed(true).Should().BeFalse();
      assertion.Unconfirmed(false).Should().BeTrue();
    });

    new Assertion(false).With(assertion =>
    {
      assertion.Unconfirmed(true).Should().BeTrue();
      assertion.Unconfirmed(false).Should().BeFalse();
    });
  }
}