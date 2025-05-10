using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NullableExpectations"/>.</para>
/// </summary>
public sealed class NullableExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NullableExpectations.HasValue{T}(IExpectation{Nullable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void HasValue_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NullableExpectations.HasValue<int>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test(true, (int?) 0);
      Test(false, (int?) null);
    }

    return;

    static void Test<T>(bool result, T? instance) where T : struct => instance.Expect().HasValue().Should().BeOfType<Expectation<T?>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NullableExpectations.Value{T}(IExpectation{Nullable{T}}, T)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NullableExpectations.Value(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test(true, 0, 0);
      Test(true, null, 0);
      Test(false, null, int.MinValue);
      Test(false, null, int.MaxValue);

      Test(true, DateTime.MinValue, DateTime.MinValue);
      Test(true, DateTime.MaxValue, DateTime.MaxValue);
      Test(true, null, DateTime.MinValue);
      Test(false, null, DateTime.MaxValue);

      Test(true, Guid.Empty, Guid.Empty);
      Test(true, null, Guid.Empty);
      Test(false, null, Guid.NewGuid());
    }

    return;

    static void Test<T>(bool result, T? instance, T value) where T : struct => instance.Expect().Value(value).Should().BeOfType<Expectation<T?>>().Which.Result.Should().Be(result);
  }
}