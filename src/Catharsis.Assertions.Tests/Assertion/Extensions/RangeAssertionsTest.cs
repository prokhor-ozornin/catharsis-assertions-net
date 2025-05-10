using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RangeAssertions"/>.</para>
/// </summary>
public sealed class RangeAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RangeAssertions.StartIndex(IAssertion, Range, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartIndex_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => RangeAssertions.StartIndex(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test(true, ..0, 0);
      Test(true, .., 0);
      Test(true, ^0..0, 0);
      Test(false, ..0, int.MinValue);
    }

    return;

    static void Test(bool result, Range range, int index)
    {
      if (result)
      {
        Assert.To.StartIndex(range, index).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.StartIndex(range, index, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RangeAssertions.EndIndex(IAssertion, Range, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndIndex_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => RangeAssertions.EndIndex(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test(true, ..0, 0);
      Test(true, .., 0);
      Test(true, ..^int.MaxValue, int.MaxValue);
      Test(false, ..0, int.MinValue);
    }

    return;

    static void Test(bool result, Range range, int index)
    {
      if (result)
      {
        Assert.To.EndIndex(range, index).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.EndIndex(range, index, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}