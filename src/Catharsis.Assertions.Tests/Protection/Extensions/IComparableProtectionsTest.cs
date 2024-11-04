using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IComparableProtections"/>.</para>
/// </summary>
public sealed class IComparableProtectionsTest : UnitTest
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

      Validate(true, int.MinValue);
      Validate(true, 0);
      Validate(true, DateTime.MinValue);
      Validate(true, Guid.Empty);

      Validate(false, int.MaxValue);
      Validate(false, DateTime.Today);
      Validate(false, DateTime.MaxValue);
      Validate(false, Guid.NewGuid());
    }

    return;

    static void Validate<T>(bool result, T comparable) where T : struct, IComparable<T>
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

      Validate(true, 0);
      Validate(true, int.MaxValue);
      Validate(true, DateTime.MinValue);
      Validate(true, DateTime.Today);
      Validate(true, DateTime.MaxValue);
      Validate(true, Guid.Empty);
      Validate(true, Guid.NewGuid());

      Validate(false, int.MinValue);
    }

    return;

    static void Validate<T>(bool result, T comparable) where T : struct, IComparable<T>
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

      Validate(true, int.MinValue);
      Validate(true, int.MaxValue);
      Validate(true, DateTime.Today);
      Validate(true, DateTime.MaxValue);
      Validate(true, Guid.NewGuid());

      Validate(false, 0);
      Validate(false, DateTime.MinValue);
      Validate(false, Guid.Empty);
    }

    return;

    static void Validate<T>(bool result, T comparable) where T : struct, IComparable<T>
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

      Validate(true, 0, 0, 0);
      Validate(true, 0, int.MinValue, 0);
      Validate(true, 0, 0, int.MaxValue);
      Validate(true, DateTime.Today, DateTime.Today, DateTime.Today);
      Validate(true, DateTime.Today, DateTime.MinValue, DateTime.Today);
      Validate(true, DateTime.Today, DateTime.MinValue, DateTime.Today);
      Validate(true, DateTime.Today, DateTime.Today, DateTime.MaxValue);

      Validate(false, int.MinValue, 0, int.MaxValue);
      Validate(false, DateTime.MinValue, DateTime.Today, DateTime.MaxValue);

      static void Validate<T>(bool result, T comparable, T min, T max) where T : struct, IComparable<T>
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

      Validate(true, 0, ..0);
      Validate(true, 0, ..int.MaxValue);

      Validate(false, int.MinValue, ..int.MaxValue);

      static void Validate(bool result, int value, Range range)
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