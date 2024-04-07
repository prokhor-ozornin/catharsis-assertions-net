using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => RangeAssertions.StartIndex(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      AssertionExtensions.Should(() => Assert.To.StartIndex(..0, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.StartIndex(..0, 0).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      Assert.To.StartIndex(.., 0).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      Assert.To.StartIndex(^0..0, 0).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    }

    return;

    static void Validate()
    {

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
      AssertionExtensions.Should(() => RangeAssertions.EndIndex(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      AssertionExtensions.Should(() => Assert.To.EndIndex(..0, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.EndIndex(..0, 0).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      Assert.To.EndIndex(.., 0).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      Assert.To.EndIndex(..^int.MaxValue, int.MaxValue).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    }

    return;

    static void Validate()
    {

    }
  }
}