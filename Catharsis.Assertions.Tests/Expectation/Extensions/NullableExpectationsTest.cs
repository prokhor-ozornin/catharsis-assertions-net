using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

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

    ((int?) 0).Expect().HasValue().Result.Should().BeTrue();
    ((int?) null).Expect().HasValue().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NullableExpectations.Value{T}(IExpectation{T?}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => NullableExpectations.Value(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    ((int?) 0).Expect().Value(0).Result.Should().BeTrue();
    ((int?) null).Expect().Value(0).Result.Should().BeTrue();
    ((int?) null).Expect().Value(int.MinValue).Result.Should().BeFalse();
    ((int?) null).Expect().Value(int.MaxValue).Result.Should().BeFalse();

    ((DateTime?) DateTime.MinValue).Expect().Value(DateTime.MinValue).Result.Should().BeTrue();
    ((DateTime?) DateTime.MaxValue).Expect().Value(DateTime.MaxValue).Result.Should().BeTrue();
    ((DateTime?) null).Expect().Value(DateTime.MinValue).Result.Should().BeTrue();
    ((DateTime?) null).Expect().Value(DateTime.MaxValue).Result.Should().BeFalse();

    ((Guid?) Guid.Empty).Expect().Value(Guid.Empty).Result.Should().BeTrue();
    ((Guid?) null).Expect().Value(Guid.Empty).Result.Should().BeTrue();
    ((Guid?) null).Expect().Value(Guid.NewGuid()).Result.Should().BeFalse();
  }
}