using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RangeExpectations.EndIndex(IExpectation{Range}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndIndex_Method()
  {
    AssertionExtensions.Should(() => RangeExpectations.EndIndex(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }
}