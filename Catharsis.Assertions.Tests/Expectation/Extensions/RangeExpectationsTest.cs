using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RangeExpectations"/>.</para>
/// </summary>
public sealed class RangeExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RangeExpectations.StartIndex(IExpectation{Range}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartIndex_Method()
  {
    AssertionExtensions.Should(() => RangeExpectations.StartIndex(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    (..0).Expect().StartIndex(int.MinValue).Result.Should().BeFalse();
    (..0).Expect().StartIndex(0).Result.Should().BeTrue();
    (..).Expect().StartIndex(0).Result.Should().BeTrue();
    (^0..0).Expect().StartIndex(0).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RangeExpectations.EndIndex(IExpectation{Range}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndIndex_Method()
  {
    AssertionExtensions.Should(() => RangeExpectations.EndIndex(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    (..0).Expect().EndIndex(int.MinValue).Result.Should().BeFalse();
    (..0).Expect().EndIndex(0).Result.Should().BeTrue();
    (..).Expect().EndIndex(0).Result.Should().BeTrue();
    (..^int.MaxValue).Expect().EndIndex(int.MaxValue).Result.Should().BeTrue();
  }
}