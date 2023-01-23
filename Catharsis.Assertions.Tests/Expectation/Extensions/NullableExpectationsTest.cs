using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="NullableExpectations"/>.</para>
/// </summary>
public sealed class NullableExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NullableExpectations.HasValue{T}(IExpectation{T?})"/> method.</para>
  /// </summary>
  [Fact]
  public void HasValue_Method()
  {
    AssertionExtensions.Should(() => NullableExpectations.HasValue<int>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NullableExpectations.Value{T}(IExpectation{T?}, T)"/> method.</para>
  /// </summary>
  public void Value_Method()
  {
    AssertionExtensions.Should(() => NullableExpectations.Value(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }
}