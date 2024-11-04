using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NullableAssertions"/>.</para>
/// </summary>
public sealed class NullableAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NullableAssertions.HasValue{T}(IAssertion, Nullable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void HasValue_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NullableAssertions.HasValue<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Validate(true, (int?) 0);
      Validate(false, (int?) null);
    }

    return;

    static void Validate<T>(bool result, T? instance) where T : struct
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
      AssertionExtensions.Should(() => NullableAssertions.Value(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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

    static void Validate<T>(bool result, T? instance, T value) where T : struct
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