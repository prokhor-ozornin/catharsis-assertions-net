using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NullableAssertions"/>.</para>
/// </summary>
public sealed class NullableAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NullableAssertions.HasValue{T}(IAssertion, Nullable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void HasValue_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NullableAssertions.HasValue<int>(null, null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test(true, (int?) 0);
      Test(false, (int?) null);
    }

    return;

    static void Test<T>(bool result, T? instance) where T : struct
    {
      if (result)
      {
        Assert.To.HasValue(instance).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.HasValue(instance, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NullableAssertions.Value{T}(IAssertion, Nullable{T}, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NullableAssertions.Value(null, null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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

    static void Test<T>(bool result, T? instance, T value) where T : struct
    {
      if (result)
      {
        Assert.To.Value(instance, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Value(instance, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}