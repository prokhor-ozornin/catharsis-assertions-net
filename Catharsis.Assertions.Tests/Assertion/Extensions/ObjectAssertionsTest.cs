using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectAssertions"/>.</para>
/// </summary>
public sealed class ObjectAssertionsTest : UnitTest
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

      Validate(true, (object) null, null);
      new object().With(instance => Validate(true, instance, instance));
      Validate(false, new object(), null);
      Validate(false, (object) null, new object());
    }

    return;

    static void Validate<T>(bool result, T instance, object other)
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

      Validate(true, (object) null, null);
      new object().With(instance => Validate(true, instance, instance));

      Validate(true, 0, 0);
      Validate(true, DateTime.Today, DateTime.Today);

      Validate(false, new object(), null);
      Validate(false, (object) null, new object());
      Validate(false, Guid.NewGuid(), Guid.NewGuid());
    }

    return;

    static void Validate<T>(bool result, T instance, object other)
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

      Validate(true, (object) null);
      Validate(false, new object());

      Validate(true, 0);
      Validate(false, int.MinValue);

      Validate(true, DateTime.MinValue);
      Validate(false, DateTime.Today);

      Validate(true, Guid.Empty);
      Validate(false, Guid.NewGuid());
    }

    return;

    static void Validate<T>(bool result, T instance)
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

      Validate(true, new object(), typeof(object));
      Validate(false, new object(), typeof(string));

      static void Validate(bool result, object instance, Type type)
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

      Validate<object>(true, new object());
      Validate<string>(false, new object());

      static void Validate<T>(bool result, object instance)
      {
        if (result)
        {
          Assert.To.OfType<T>(instance.Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
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

      Validate(true, (object) null);
      Validate(false, new object());
    }

    return;

    static void Validate<T>(bool result, T instance)
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

      Validate(true, null, new object[] { null, new(), null });
      Validate(true, string.Empty, new object[] { string.Empty, Guid.Empty, new() });
      Validate(false, null, Enumerable.Empty<object>());
      Validate(false, new object(), [new object()]);
    }

    return;

    static void Validate<T>(bool result, T value, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null)
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