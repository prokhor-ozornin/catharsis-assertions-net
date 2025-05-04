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

      Validate(true, (int?) 0);
      Validate(false, (int?) null);
    }

    return;

    static void Validate<T>(bool result, T? instance) where T : struct => instance.Expect().HasValue().Should().BeOfType<Expectation<T?>>().Which.Result.Should().Be(result);
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

      Validate(true, 0, 0);
      Validate(true, null, 0);
      Validate(false, null, int.MinValue);
      Validate(false, null, int.MaxValue);

      Validate(true, DateTime.MinValue, DateTime.MinValue);
      Validate(true, DateTime.MaxValue, DateTime.MaxValue);
      Validate(true, null, DateTime.MinValue);
      Validate(false, null, DateTime.MaxValue);

      Validate(true, Guid.Empty, Guid.Empty);
      Validate(true, null, Guid.Empty);
      Validate(false, null, Guid.NewGuid());
    }

    return;

    static void Validate<T>(bool result, T? instance, T value) where T : struct => instance.Expect().Value(value).Should().BeOfType<Expectation<T?>>().Which.Result.Should().Be(result);
  }
}