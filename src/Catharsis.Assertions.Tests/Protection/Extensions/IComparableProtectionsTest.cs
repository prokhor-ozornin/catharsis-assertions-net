using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IComparableProtections"/>.</para>
/// </summary>
public sealed class IComparableProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableProtections.Positive{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Positive_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableProtections.Positive(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Test(true, int.MinValue);
      Test(true, 0);
      Test(true, DateTime.MinValue);
      Test(true, Guid.Empty);

      Test(false, int.MaxValue);
      Test(false, DateTime.Today);
      Test(false, DateTime.MaxValue);
      Test(false, Guid.NewGuid());
    }

    return;

    static void Test<T>(bool result, T comparable) where T : struct, IComparable<T>
    {
      if (result)
      {
        Protect.From.Positive(comparable).Should().BeOfType<T>().And.Be(comparable);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Positive(comparable, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableProtections.Negative{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableProtections.Negative(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Test(true, 0);
      Test(true, int.MaxValue);
      Test(true, DateTime.MinValue);
      Test(true, DateTime.Today);
      Test(true, DateTime.MaxValue);
      Test(true, Guid.Empty);
      Test(true, Guid.NewGuid());

      Test(false, int.MinValue);
    }

    return;

    static void Test<T>(bool result, T comparable) where T : struct, IComparable<T>
    {
      if (result)
      {
        Protect.From.Negative(comparable).Should().BeOfType<T>().And.Be(comparable);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Negative(comparable, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableProtections.Zero{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableProtections.Zero(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Test(true, int.MinValue);
      Test(true, int.MaxValue);
      Test(true, DateTime.Today);
      Test(true, DateTime.MaxValue);
      Test(true, Guid.NewGuid());

      Test(false, 0);
      Test(false, DateTime.MinValue);
      Test(false, Guid.Empty);
    }

    return;

    static void Test<T>(bool result, T comparable) where T : struct, IComparable<T>
    {
      if (result)
      {
        Protect.From.Zero(comparable).Should().BeOfType<T>().And.Be(comparable);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Zero(comparable, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IComparableProtections.OutOfRange{T}(IProtection, T, T, T, string)"/></description></item>
  ///     <item><description><see cref="IComparableProtections.OutOfRange(IProtection, int, Range, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void OutOfRange_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableProtections.OutOfRange(null, 0, 0, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Test(true, 0, 0, 0);
      Test(true, 0, int.MinValue, 0);
      Test(true, 0, 0, int.MaxValue);
      Test(true, DateTime.Today, DateTime.Today, DateTime.Today);
      Test(true, DateTime.Today, DateTime.MinValue, DateTime.Today);
      Test(true, DateTime.Today, DateTime.MinValue, DateTime.Today);
      Test(true, DateTime.Today, DateTime.Today, DateTime.MaxValue);

      Test(false, int.MinValue, 0, int.MaxValue);
      Test(false, DateTime.MinValue, DateTime.Today, DateTime.MaxValue);

      static void Test<T>(bool result, T comparable, T min, T max) where T : struct, IComparable<T>
      {
        if (result)
        {
          Protect.From.OutOfRange(comparable, min, max).Should().BeOfType<T>().And.Be(comparable);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.OutOfRange(comparable, min, max, "error")).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableProtections.OutOfRange(null, 0, ..0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Test(true, 0, ..0);
      Test(true, 0, ..int.MaxValue);

      Test(false, int.MinValue, ..int.MaxValue);

      static void Test(bool result, int value, Range range)
      {
        if (result)
        {
          Protect.From.OutOfRange(value, range).Should().Be(value);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.OutOfRange(value, range, "error")).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("error");
        }
      }
    }
  }
}