using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.Positive<int>(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T comparable) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.Positive(comparable).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Positive(comparable, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Negative{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Negative_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.Negative<int>(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T comparable) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.Negative(comparable, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Negative(comparable, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Zero{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Zero_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.Zero<int>(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T comparable) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.Zero(comparable).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Zero(comparable, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Greater{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Greater_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.Greater<int>(null, 0, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T left, T right) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.Greater(left, right).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Greater(left, right, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.GreaterOrEqual{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void GreaterOrEqual_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.GreaterOrEqual<int>(null, 0, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T left, T right) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.GreaterOrEqual(left, right).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.GreaterOrEqual(left, right, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.Lesser{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Lesser_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.Lesser<int>(null, 0, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T left, T right) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.Lesser(left, right).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Lesser(left, right, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.LesserOrEqual{T}(IAssertion, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void LesserOrEqual_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.LesserOrEqual<int>(null, 0, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T left, T right) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.LesserOrEqual(left, right).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.LesserOrEqual(left, right, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.InRange{T}(IAssertion, T, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InRange_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.InRange<int>(null, 0, 0, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T comparable, T min, T max) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.InRange(comparable, min, max).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.InRange(comparable, min, max, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IComparableAssertions.OutOfRange{T}(IAssertion, T, T, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OutOfRange_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IComparableAssertions.OutOfRange<int>(null, 0, 0, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    }

    return;

    static void Validate<T>(bool result, T comparable, T min, T max) where T : struct, IComparable<T>
    {
      if (result)
      {
        Assert.To.OutOfRange(comparable, min, max).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.OutOfRange(comparable, min, max)).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}