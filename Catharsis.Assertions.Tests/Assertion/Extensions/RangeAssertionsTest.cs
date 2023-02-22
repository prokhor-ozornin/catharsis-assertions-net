using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RangeAssertions"/>.</para>
/// </summary>
public sealed class RangeAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RangeAssertions.StartIndex(IAssertion, Range, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartIndex_Method()
  {
    AssertionExtensions.Should(() => RangeAssertions.StartIndex(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.StartIndex(..0, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.StartIndex(..0, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.StartIndex(.., 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.StartIndex(^0..0, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RangeAssertions.EndIndex(IAssertion, Range, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndIndex_Method()
  {
    AssertionExtensions.Should(() => RangeAssertions.EndIndex(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.EndIndex(..0, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.EndIndex(..0, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.EndIndex(.., 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.EndIndex(..^int.MaxValue, int.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}