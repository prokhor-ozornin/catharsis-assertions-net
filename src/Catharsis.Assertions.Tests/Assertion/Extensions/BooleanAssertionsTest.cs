using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="BooleanAssertions"/>.</para>
/// </summary>
/// <seealso cref="BooleanAssertions"/>
public sealed class BooleanAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="BooleanAssertions.True(IAssertion, bool?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void True_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => BooleanAssertions.True(null, null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test(true, true);
      Test(false, null);
      Test(false, false);
    }

    return;

    static void Test(bool result, bool? value)
    {
      if (result)
      {
        Assert.To.True(value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.True(value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BooleanAssertions.False(IAssertion, bool?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void False_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => BooleanAssertions.False(null, null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test(true, null);
      Test(true, false);
      Test(false, true);
    }

    return;

    static void Test(bool result, bool? value)
    {
      if (result)
      {
        Assert.To.False(value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.False(value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}