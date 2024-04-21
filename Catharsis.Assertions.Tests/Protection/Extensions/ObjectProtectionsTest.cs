using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectProtections"/>.</para>
/// </summary>
public sealed class ObjectProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Same{T}(IProtection, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Same_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.Same(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Validate(false, (object) null, null);
      new object().With(instance => Validate(false, instance, instance));
      Validate(true, new object(), null);
      Validate(true, (object) null, new object());
    }

    return;

    static void Validate<T>(bool result, T instance, object other)
    {
      if (result)
      {
        Protect.From.Same(instance, other).Should().BeSameAs(instance);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Same(instance, other, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ObjectProtections.OfType(IProtection, object, Type, string)"/></description></item>
  ///     <item><description><see cref="ObjectProtections.OfType{T}(IProtection, object, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void OfType_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.OfType(null, new object(), typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.OfType(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("instance");
      AssertionExtensions.Should(() => Protect.From.OfType(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Validate(true, new object(), typeof(string));
      Validate(false, new object(), typeof(object));

      static void Validate(bool result, object instance, Type type)
      {
        if (result)
        {
          Protect.From.OfType(instance, type).Should().BeOfType<object>().And.BeSameAs(instance);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.OfType(instance, type, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.OfType<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.OfType<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("instance");

      //Validate<string>(true, new object());
      Validate(false, new object());

      static void Validate<T>(bool result, T instance)
      {
        if (result)
        {
          Protect.From.OfType<T>(instance).Should().BeOfType<T>().And.BeSameAs(instance);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.OfType<object>(new object(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Equality{T}(IProtection, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equality_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.Equality(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Validate(false, (object) null, null);
      new object().With(instance => Validate(false, instance, instance));

      Validate(false, 0, 0);
      Validate(false, DateTime.Today, DateTime.Today);

      Validate(true, new object(), null);
      Validate(true, (object) null, new object());
      Validate(true, Guid.NewGuid(), Guid.NewGuid());
    }

    return;

    static void Validate<T>(bool result, T instance, object other)
    {
      if (result)
      {
        Protect.From.Equality(instance, other).Should().Be(instance);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Equality(instance, other, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Default{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.Default(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Validate(true, new object());
      Validate(true, int.MinValue);
      Validate(true, DateTime.Today);
      Validate(true, Guid.NewGuid());

      Validate(false, (object) null);
      Validate(false, 0);
      Validate(false, DateTime.MinValue);
      Validate(false, Guid.Empty);
    }

    return;

    static void Validate<T>(bool result, T instance)
    {
      if (result)
      {
        Protect.From.Default(instance).Should().BeOfType<T>().And.Be(instance);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Default(instance, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Null{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.Null(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Validate(true, new object());
      Validate(false, (object) null);
    }

    return;

    static void Validate<T>(bool result, T instance)
    {
      if (result)
      {
        Protect.From.Null(instance).Should().BeOfType<T>().And.BeSameAs(instance);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Null(instance, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ObjectProtections.AnyOf{T}(IProtection,T, IEnumerable{T}, string)"/></description></item>
  ///     <item><description><see cref="ObjectProtections.AnyOf{T}(IProtection, T, string, T[])"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AnyOf_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.AnyOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.AnyOf(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("values");

      Validate<object>(false, Enumerable.Empty<object>(), [string.Empty, Enumerable.Empty<object>()]);
      Validate<object>(true, Attributes.RandomSequence(), [string.Empty, Enumerable.Empty<object>()]);
      Validate<object>(false, null, [string.Empty, null]);

      static void Validate<T>(bool result, T value, IEnumerable<T> values)
      {
        if (result)
        {
          Protect.From.AnyOf(value, values).Should().BeAssignableTo<IEnumerable<T>>().And.BeSameAs(value);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.AnyOf(value, values, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.AnyOf(null, new object(), null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.AnyOf(new object(), "error", null)).ThrowExactly<ArgumentNullException>().WithParameterName("values");

      Validate<object>(false, Enumerable.Empty<object>(), string.Empty, Enumerable.Empty<object>());
      Validate<object>(true, Attributes.RandomSequence(), string.Empty, Enumerable.Empty<object>());
      Validate<object>(false, null, string.Empty, null);

      static void Validate<T>(bool result, T value, params T[] values)
      {
        if (result)
        {
          Protect.From.AnyOf(value, "error", values).Should().BeAssignableTo<IEnumerable<T>>().And.BeSameAs(value);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.AnyOf(value, "error", values)).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}