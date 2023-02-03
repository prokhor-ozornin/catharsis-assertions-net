﻿using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ComparableAssertions"/>.</para>
/// </summary>
public sealed class ComparableAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.Positive{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Positive_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Positive<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
  ///   <para>Performs testing of <see cref="ComparableAssertions.Negative{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Negative<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
  ///   <para>Performs testing of <see cref="ComparableAssertions.Zero{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Zero<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
  ///   <para>Performs testing of <see cref="ComparableAssertions.Greater{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Greater_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Greater<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
  ///   <para>Performs testing of <see cref="ComparableAssertions.GreaterOrEqual{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void GreaterOrEqual_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.GreaterOrEqual<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
  ///   <para>Performs testing of <see cref="ComparableAssertions.Lesser{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Lesser_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Lesser<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
  ///   <para>Performs testing of <see cref="ComparableAssertions.LesserOrEqual{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LesserOrEqual_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.Lesser<int>(null, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

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
  ///   <para>Performs testing of <see cref="ComparableAssertions.InRange{T}(IAssertion, T, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InRange_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.InRange<int>(null, default, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ComparableAssertions.OutOfRange{T}(IAssertion, T, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OutOfRange_Method()
  {
    AssertionExtensions.Should(() => ComparableAssertions.OutOfRange<int>(null, default, default, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}