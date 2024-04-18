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

      Validate(true, new object(), new object());
      Validate(true, (object) null, new object());

      Validate(false, (object) null, null);
      Validate(false, Stream.Null, Stream.Null);
    }

    return;

    static void Validate<T>(bool result, T instance, object other)
    {
      if (result)
      {
        Protect.From.Same(instance, other).Should().BeOfType<T>().And.BeSameAs(instance);
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

      Validate<string>(true, new object());
      Validate(false, null);

      static void Validate<T>(bool result, T instance)
      {
        if (result)
        {
          Protect.From.OfType<T>(instance).Should().BeOfType<object>().And.BeSameAs(instance);
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

      Validate(true, null);
      Validate(false, null);
    }

    return;

    static void Validate<T>(bool result, T instance, object other)
    {
      if (result)
      {
        new object().With(instance => Protect.From.Equality(instance, null).Should().BeOfType<object>().And.BeSameAs(instance));
        Protect.From.Equality<object>(null, new object()).Should().BeNull();

        Guid.NewGuid().With(guid => Protect.From.Equality(guid, Guid.NewGuid()).Should().Be(guid));
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Equality<object>(null, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        new object().With(instance => AssertionExtensions.Should(() => Protect.From.Equality(instance, instance, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));

        AssertionExtensions.Should(() => Protect.From.Equality(0, 0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        AssertionExtensions.Should(() => Protect.From.Equality(DateTime.Today, DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
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
      Validate(false, null);
    }

    return;

    static void Validate<T>(bool result, T instance)
    {
      if (result)
      {
        new object().With(instance => Protect.From.Default(instance).Should().BeOfType<object>().And.BeSameAs(instance));

        Protect.From.Default(int.MinValue).Should().Be(int.MinValue);

        Protect.From.Default(DateTime.Today).Should().Be(DateTime.Today);

        Guid.NewGuid().With(guid => Protect.From.Default(guid).Should().Be(guid));
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Default<object>(null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

        AssertionExtensions.Should(() => Protect.From.Default(0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

        AssertionExtensions.Should(() => Protect.From.Default(DateTime.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

        AssertionExtensions.Should(() => Protect.From.Default(Guid.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
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

      Validate(true, null);
      Validate(false, null);

      static void Validate<T>(bool result, T value, IEnumerable<T> values)
      {
        if (result)
        {
          Attributes.EmptySequence().With(sequence => Protect.From.AnyOf(string.Empty, sequence).Should().BeOfType<string>().And.BeSameAs(string.Empty));
          Attributes.RandomSequence().With(sequence => Protect.From.AnyOf(string.Empty, sequence).Should().BeOfType<string>().And.BeSameAs(string.Empty));
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.AnyOf(null, [string.Empty, null], "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.AnyOf(null, new object(), null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.AnyOf(new object(), "error", null)).ThrowExactly<ArgumentNullException>().WithParameterName("values");

      Validate(true, null);
      Validate(false, null);

      static void Validate<T>(bool result, T value)
      {
        if (result)
        {
          Attributes.EmptySequence().With(sequence => Protect.From.AnyOf(string.Empty, sequence.AsArray()).Should().BeOfType<string>().And.BeSameAs(string.Empty));
          Attributes.RandomSequence().With(sequence => Protect.From.AnyOf(string.Empty, sequence.AsArray()).Should().BeOfType<string>().And.BeSameAs(string.Empty));
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.AnyOf(null, "error", string.Empty, null)).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}