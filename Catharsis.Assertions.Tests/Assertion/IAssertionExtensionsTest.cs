using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IAssertionExtensions"/>.</para>
/// </summary>
public sealed class IAssertionExtensionsTest : UnitTest
{
  private IAssertion Assertion => Assert.To;

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.And(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void And_Method()
  {
    ((IAssertion) null).And().Should().BeNull();
    Assertion.And().Should().NotBeNull().And.BeSameAs(Assertion);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.Be(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void Be_Method()
  {
    ((IAssertion) null).Be().Should().BeNull();
    Assertion.Be().Should().NotBeNull().And.BeSameAs(Assertion);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.Having(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void Having_Method()
  {
    ((IAssertion) null).Having().Should().BeNull();
    Assertion.Having().Should().NotBeNull().And.BeSameAs(Assertion);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.With(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void With_Method()
  {
    ((IAssertion) null).With().Should().BeNull();
    Assertion.With().Should().NotBeNull().And.BeSameAs(Assertion);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.Of(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void Of_Method()
  {
    ((IAssertion) null).Of().Should().BeNull();
    Assertion.Of().Should().NotBeNull().And.BeSameAs(Assertion);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.At(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void At_Method()
  {
    ((IAssertion) null).At().Should().BeNull();
    Assertion.At().Should().NotBeNull().And.BeSameAs(Assertion);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.On(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void On_Method()
  {
    ((IAssertion) null).On().Should().BeNull();
    Assertion.On().Should().NotBeNull().And.BeSameAs(Assertion);
  }
}