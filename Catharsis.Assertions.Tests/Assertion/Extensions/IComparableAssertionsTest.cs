using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IComparableAssertions"/>.</para>
/// </summary>
public sealed class IComparableAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Positive{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Positive_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.Positive<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.Positive(int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Positive(0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Positive(int.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);

    AssertionExtensions.Should(() => Assert.To.Positive(DateTime.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Positive(DateTime.Today).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Positive(DateTime.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);

    AssertionExtensions.Should(() => Assert.To.Positive(Guid.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Positive(Guid.NewGuid()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Negative{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.Negative<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.Negative(int.MinValue, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Negative(0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Negative(int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    AssertionExtensions.Should(() => Assert.To.Negative(DateTime.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Negative(DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Negative(DateTime.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    AssertionExtensions.Should(() => Assert.To.Negative(Guid.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Negative(Guid.NewGuid(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Zero{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.Zero<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.Zero(int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Zero(0).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Zero(int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.Zero(DateTime.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Zero(DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Zero(DateTime.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.Zero(Guid.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Zero(Guid.NewGuid(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Greater{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Greater_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.Greater<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.Greater(0, int.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Greater(0, 0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Greater(0, int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.Greater(DateTime.Today, DateTime.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Greater(DateTime.Today, DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Greater(DateTime.Today, DateTime.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    AssertionExtensions.Should(() => Assert.To.Greater(Guid.Empty, Guid.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Greater(Guid.Empty, Guid.NewGuid(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.GreaterOrEqual{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void GreaterOrEqual_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.GreaterOrEqual<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.GreaterOrEqual(0, int.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.GreaterOrEqual(0, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.GreaterOrEqual(0, int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.GreaterOrEqual(DateTime.Today, DateTime.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.GreaterOrEqual(DateTime.Today, DateTime.Today).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.GreaterOrEqual(DateTime.Today, DateTime.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.GreaterOrEqual(Guid.Empty, Guid.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.GreaterOrEqual(Guid.Empty, Guid.NewGuid(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Lesser{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Lesser_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.Lesser<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.Lesser(0, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Lesser(0, 0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Lesser(0, int.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);

    AssertionExtensions.Should(() => Assert.To.Lesser(DateTime.Today, DateTime.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Lesser(DateTime.Today, DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Lesser(DateTime.Today, DateTime.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);

    AssertionExtensions.Should(() => Assert.To.Lesser(Guid.Empty, Guid.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Lesser(Guid.Empty, Guid.NewGuid()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.LesserOrEqual{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LesserOrEqual_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.Lesser<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.LesserOrEqual(0, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.LesserOrEqual(0, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.LesserOrEqual(0, int.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);

    AssertionExtensions.Should(() => Assert.To.LesserOrEqual(DateTime.Today, DateTime.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.LesserOrEqual(DateTime.Today, DateTime.Today).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.LesserOrEqual(DateTime.Today, DateTime.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);

    Assert.To.LesserOrEqual(Guid.Empty, Guid.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.LesserOrEqual(Guid.Empty, Guid.NewGuid()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.InRange{T}(IAssertion, T, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InRange_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.InRange<int>(null, default, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.InRange(0, 0, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.InRange(0, int.MinValue, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.InRange(0, int.MinValue, int.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.InRange(0, int.MaxValue, 0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.InRange(0, int.MaxValue, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.InRange(DateTime.Today, DateTime.Today, DateTime.Today).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.InRange(DateTime.Today, DateTime.MinValue, DateTime.Today).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.InRange(DateTime.Today, DateTime.MinValue, DateTime.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.InRange(DateTime.Today, DateTime.MaxValue, DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.InRange(DateTime.MaxValue, DateTime.MinValue, DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.OutOfRange{T}(IAssertion, T, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OutOfRange_Method()
  {
    AssertionExtensions.Should(() => IComparableAssertions.OutOfRange<int>(null, default, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    AssertionExtensions.Should(() => Assert.To.OutOfRange(0, 0, 0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.OutOfRange(0, int.MinValue, 0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.OutOfRange(0, int.MinValue, int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.OutOfRange(0, int.MaxValue, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.OutOfRange(0, int.MaxValue, int.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.OutOfRange(0, 1, int.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.OutOfRange(0, int.MinValue, -1).Should().NotBeNull().And.BeSameAs(Assert.To);
    
    AssertionExtensions.Should(() => Assert.To.OutOfRange(DateTime.Today, DateTime.Today, DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.OutOfRange(DateTime.Today, DateTime.MinValue, DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.OutOfRange(DateTime.Today, DateTime.MinValue, DateTime.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.OutOfRange(DateTime.Today, DateTime.MaxValue, DateTime.Today).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.OutOfRange(DateTime.MaxValue, DateTime.MinValue, DateTime.Today).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.OutOfRange(DateTime.Today, DateTime.Today.AddDays(1), DateTime.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.OutOfRange(DateTime.Today, DateTime.MinValue, DateTime.Today.AddDays(-1)).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}