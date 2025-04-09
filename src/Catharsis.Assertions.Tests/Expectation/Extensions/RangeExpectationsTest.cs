using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => RangeExpectations.StartIndex(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Validate(true, ..0, 0);
      Validate(true, .., 0);
      Validate(true, ^0..0, 0);
      Validate(false, ..0, int.MinValue);
    }

    return;

    static void Validate(bool result, Range range, int index) => range.Expect().StartIndex(index).Should().BeOfType<Expectation<Range>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RangeExpectations.EndIndex(IExpectation{Range}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndIndex_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => RangeExpectations.EndIndex(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Validate(true, ..0, 0);
      Validate(true, .., 0);
      Validate(true, ..^int.MaxValue, int.MaxValue);
      Validate(false, ..0, int.MinValue);
    }

    return;

    static void Validate(bool result, Range range, int index) => range.Expect().EndIndex(index).Should().BeOfType<Expectation<Range>>().Which.Result.Should().Be(result);
  }
}