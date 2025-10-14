using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IAssertionExtensions"/>.</para>
/// </summary>
/// <seealso cref="IAssertionExtensions"/>
public sealed class IAssertionExtensionsTest : Test
{
  private IAssertion Assertion => Assert.To;

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.And(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void And_Method()
  {
    using (new AssertionScope())
    {
      ((IAssertion)null).And().Should().BeNull();
      Assertion.And().Should().BeOfType<Assertion>().And.BeSameAs(Assertion);
    }

    return;

    static void Test()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.Be(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void Be_Method()
  {
    using (new AssertionScope())
    {
      ((IAssertion)null).Be().Should().BeNull();
      Assertion.Be().Should().BeOfType<Assertion>().And.BeSameAs(Assertion);
    }

    return;

    static void Test()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.Having(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void Having_Method()
  {
    using (new AssertionScope())
    {
      ((IAssertion)null).Having().Should().BeNull();
      Assertion.Having().Should().BeOfType<Assertion>().And.BeSameAs(Assertion);
    }

    return;

    static void Test()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.With(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void With_Method()
  {
    using (new AssertionScope())
    {
      ((IAssertion)null).With().Should().BeNull();
      Assertion.With().Should().BeOfType<Assertion>().And.BeSameAs(Assertion);
    }

    return;

    static void Test()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.Of(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void Of_Method()
  {
    using (new AssertionScope())
    {
      ((IAssertion)null).Of().Should().BeNull();
      Assertion.Of().Should().BeOfType<Assertion>().And.BeSameAs(Assertion);
    }

    return;

    static void Test()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.At(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void At_Method()
  {
    using (new AssertionScope())
    {
      ((IAssertion)null).At().Should().BeNull();
      Assertion.At().Should().BeOfType<Assertion>().And.BeSameAs(Assertion);
    }

    return;

    static void Test()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IAssertionExtensions.On(IAssertion)"/> method.</para>
  /// </summary>
  [Fact]
  public void On_Method()
  {
    using (new AssertionScope())
    {
      ((IAssertion)null).On().Should().BeNull();
      Assertion.On().Should().BeOfType<Assertion>().And.BeSameAs(Assertion);
    }

    return;

    static void Test()
    {

    }
  }
}