using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

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
    AssertionExtensions.Should(() => IComparableProtections.Positive(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    Protect.From.Positive(int.MinValue).Should().Be(int.MinValue);
    Protect.From.Positive(0).Should().Be(0);
    AssertionExtensions.Should(() => Protect.From.Positive(int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Protect.From.Positive(DateTime.MinValue).Should().Be(DateTime.MinValue);
    AssertionExtensions.Should(() => Protect.From.Positive(DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Protect.From.Positive(DateTime.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Protect.From.Positive(Guid.Empty).Should().Be(Guid.Empty);
    AssertionExtensions.Should(() => Protect.From.Positive(Guid.NewGuid(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableProtections.Negative{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    AssertionExtensions.Should(() => IComparableProtections.Negative(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Negative(int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Protect.From.Negative(0).Should().Be(0);
    Protect.From.Negative(int.MaxValue).Should().Be(int.MaxValue);

    Protect.From.Negative(DateTime.MinValue).Should().Be(DateTime.MinValue);
    Protect.From.Negative(DateTime.Today).Should().Be(DateTime.Today);
    Protect.From.Negative(DateTime.MaxValue).Should().Be(DateTime.MaxValue);

    Protect.From.Negative(Guid.Empty).Should().Be(Guid.Empty);
    Guid.NewGuid().With(guid => Protect.From.Negative(guid).Should().Be(guid));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableProtections.Zero{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    AssertionExtensions.Should(() => IComparableProtections.Zero(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    Protect.From.Zero(int.MinValue).Should().Be(int.MinValue);
    AssertionExtensions.Should(() => Protect.From.Zero(0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Protect.From.Zero(int.MaxValue).Should().Be(int.MaxValue);

    AssertionExtensions.Should(() => Protect.From.Zero(DateTime.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Protect.From.Zero(DateTime.Today).Should().Be(DateTime.Today);
    Protect.From.Zero(DateTime.MaxValue).Should().Be(DateTime.MaxValue);

    AssertionExtensions.Should(() => Protect.From.Zero(Guid.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Guid.NewGuid().With(guid => Protect.From.Zero(guid).Should().Be(guid));
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

      Protect.From.OutOfRange(0, 0, 0).Should().Be(0);
      Protect.From.OutOfRange(0, int.MinValue, 0).Should().Be(0);
      Protect.From.OutOfRange(0, 0, int.MaxValue).Should().Be(0);
      AssertionExtensions.Should(() => Protect.From.OutOfRange(int.MinValue, 0, int.MaxValue, "error")).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("error");

      Protect.From.OutOfRange(DateTime.Today, DateTime.Today, DateTime.Today).Should().Be(DateTime.Today);
      Protect.From.OutOfRange(DateTime.Today, DateTime.MinValue, DateTime.Today).Should().Be(DateTime.Today);
      Protect.From.OutOfRange(DateTime.Today, DateTime.Today, DateTime.MaxValue).Should().Be(DateTime.Today);
      AssertionExtensions.Should(() => Protect.From.OutOfRange(DateTime.MinValue, DateTime.Today, DateTime.MaxValue, "error")).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableProtections.OutOfRange(null, 0, ..0)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Protect.From.OutOfRange(0, ..0).Should().Be(0);
      Protect.From.OutOfRange(0, ..int.MaxValue).Should().Be(0);
      AssertionExtensions.Should(() => Protect.From.OutOfRange(int.MinValue, ..int.MaxValue, "error")).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("error");
    }
  }
}