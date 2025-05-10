using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectAssertions"/>.</para>
/// </summary>
public sealed class ObjectAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Same{T}(IAssertion, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Same_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.Same(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test<object>(true, null, null);
      new object().With(instance => Test(true, instance, instance));
      Test(false, new object(), null);
      Test<object>(false, null, new object());
    }

    return;

    static void Test<T>(bool result, T instance, object other)
    {
      if (result)
      {
        Assert.To.Same(instance, other).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Same(instance, other, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Equal{T}(IAssertion, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.Equal(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test<object>(true, null, null);
      new object().With(instance => Test(true, instance, instance));

      Test(true, 0, 0);
      Test(true, DateTime.Today, DateTime.Today);

      Test(false, new object(), null);
      Test<object>(false, null, new object());
      Test(false, Guid.NewGuid(), Guid.NewGuid());
    }

    return;

    static void Test<T>(bool result, T instance, object other)
    {
      if (result)
      {
        Assert.To.Equal(instance, other).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Equal(instance, other, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Default{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.Default(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test<object>(true, null);
      Test(false, new object());

      Test(true, 0);
      Test(false, int.MinValue);

      Test(true, DateTime.MinValue);
      Test(false, DateTime.Today);

      Test(true, Guid.Empty);
      Test(false, Guid.NewGuid());
    }

    return;

    static void Test<T>(bool result, T instance)
    {
      if (result)
      {
        Assert.To.Default(instance).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Default(instance, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ObjectAssertions.OfType(IAssertion, object, Type, string)"/></description></item>
  ///     <item><description><see cref="ObjectAssertions.OfType{T}(IAssertion, object, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void OfType_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.OfType(null, new object(), typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.OfType(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("instance");
      AssertionExtensions.Should(() => Assert.To.OfType(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, new object(), typeof(object));
      Test(false, new object(), typeof(string));

      static void Test(bool result, object instance, Type type)
      {
        if (result)
        {
          Assert.To.OfType(instance, type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.OfType(instance, type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.OfType<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.OfType<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("instance");

      Test<object>(true, new object());
      Test<string>(false, new object());

      static void Test<T>(bool result, object instance)
      {
        if (result)
        {
          Assert.To.OfType<T>(instance).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.OfType<T>(instance, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Null{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.Null(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Test<object>(true, null);
      Test(false, new object());
    }

    return;

    static void Test<T>(bool result, T instance)
    {
      if (result)
      {
        Assert.To.Null(instance).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Null(instance, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.OneOf{T}(IAssertion, T, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OneOf_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.OneOf(null, new object(), [])).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.OneOf(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Test(true, null, new object[] { null, new(), null });
      Test(true, string.Empty, new object[] { string.Empty, Guid.Empty, new() });
      Test(false, null, Enumerable.Empty<object>());
      Test(false, new object(), [new object()]);
    }

    return;

    static void Test<T>(bool result, T value, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.OneOf(value, sequence, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.OneOf(value, sequence, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}