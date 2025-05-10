using System.Reflection;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TypeAssertions"/>.</para>
/// </summary>
public sealed class TypeAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Abstract(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Abstract_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.Abstract(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => TypeAssertions.Abstract(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, typeof(Stream));
      Test(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsAbstract && !type.IsSealed, type));
    }

    return;

    static void Test(bool result, Type type)
    {
      if (result)
      {
        Assert.To.Abstract(type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Abstract(type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Sealed(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sealed_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.Sealed(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Sealed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, typeof(FileInfo));
      Test(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsSealed && !type.IsAbstract, type));
    }

    return;

    static void Test(bool result, Type type)
    {
      if (result)
      {
        Assert.To.Sealed(type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Sealed(type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Static(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.Static(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => TypeAssertions.Static(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, typeof(Enumerable));
      Test(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsAbstract && type.IsSealed, type));
    }

    return;

    static void Test(bool result, Type type)
    {
      if (result)
      {
        Assert.To.Static(type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Static(type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Public(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.Public(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => TypeAssertions.Public(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, typeof(object));
      Test(false, typeof(Assertion));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsPublic && type.IsVisible, type));
    }

    return;

    static void Test(bool result, Type type)
    {
      if (result)
      {
        Assert.To.Public(type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Public(type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Internal(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.Internal(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Internal((Type) null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, typeof(Assertion));
      Test(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsNotPublic && !type.IsVisible, type));
    }

    return;

    static void Test(bool result, Type type)
    {
      if (result)
      {
        Assert.To.Internal(type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Internal(type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TypeExpectations.Subclass(IExpectation{Type}, Type)"/></description></item>
  ///     <item><description><see cref="TypeExpectations.Subclass{T}(IExpectation{Type})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Subclass_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.Subclass(null, typeof(object), typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Subclass(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subclass");
      AssertionExtensions.Should(() => Assert.To.Subclass(typeof(object), null)).ThrowExactly<ArgumentNullException>().WithParameterName("superclass");

      Test(true, typeof(string), typeof(object));
      Test(false, typeof(object), typeof(object));
      Test(false, typeof(object), typeof(string));
      Test(false, typeof(string), typeof(IEnumerable<char>));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(true, type, typeof(object)));

      static void Test(bool result, Type subclass, Type superclass)
      {
        if (result)
        {
          Assert.To.Subclass(subclass, superclass).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Subclass(subclass, superclass, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.Subclass<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Subclass<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subclass");

      Test<object>(false, typeof(object));
      Test<string>(false, typeof(object));
      Test<object>(true, typeof(string));
      Test<IEnumerable<char>>(false, typeof(string));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test<object>(true, type));

      static void Test<T>(bool result, Type subclass)
      {
        if (result)
        {
          Assert.To.Subclass<object>(subclass).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Subclass<T>(subclass, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TypeAssertions.AssignableFrom(IAssertion, Type, Type, string)"/></description></item>
  ///     <item><description><see cref="TypeAssertions.AssignableFrom{T}(IAssertion, Type, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AssignableFrom_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.AssignableFrom(null, typeof(object), typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.AssignableFrom(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("to");
      AssertionExtensions.Should(() => Assert.To.AssignableFrom(typeof(object), null)).ThrowExactly<ArgumentNullException>().WithParameterName("from");

      Test(true, typeof(object), typeof(object));
      Test(true, typeof(string), typeof(string));
      Test(true, typeof(object), typeof(string));
      Test(true, typeof(IEnumerable<char>), typeof(string));
      Test(false, typeof(string), typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Test(true, type, type);
        Test(true, typeof(object), type);
      });

      static void Test(bool result, Type to, Type from)
      {
        if (result)
        {
          Assert.To.AssignableFrom(to, from).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.AssignableFrom(to, from, "error")).ThrowExactly<InvalidOperationException>();
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.AssignableFrom<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.AssignableFrom<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("to");

      Test<object>(true, typeof(object));
      Test<string>(true, typeof(string));
      Test<string>(true, typeof(object));
      Test<string>(true, typeof(IEnumerable<char>));
      Test<object>(false, typeof(string));

      static void Test<T>(bool result, Type from)
      {
        if (result)
        {
          Assert.To.AssignableFrom<string>(from).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.AssignableFrom<T>(from, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To)).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TypeAssertions.AssignableTo(IAssertion, Type, Type, string)"/></description></item>
  ///     <item><description><see cref="TypeAssertions.AssignableTo{T}(IAssertion, Type, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AssignableTo_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.AssignableTo(null, typeof(object), typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.AssignableTo(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("from");
      AssertionExtensions.Should(() => Assert.To.AssignableTo(typeof(object), null)).ThrowExactly<ArgumentNullException>().WithParameterName("to");

      Test(true, typeof(object), typeof(object));
      Test(true, typeof(string), typeof(object));
      Test(true, typeof(string), typeof(IEnumerable<char>));
      Test(false, typeof(object), typeof(string));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Test(true, type, type);
        Test(true, type, typeof(object));
      });

      static void Test(bool result, Type type, Type to)
      {
        if (result)
        {
          Assert.To.AssignableTo(type, to).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.AssignableTo(type, to, "error")).ThrowExactly<InvalidOperationException>();
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.AssignableTo<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.AssignableTo<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("from");

      Test<object>(true, typeof(object));
      Test<object>(true, typeof(string));
      Test<IEnumerable<char>>(true, typeof(string));
      Test<string>(false, typeof(object));

      static void Test<T>(bool result, Type type)
      {
        if (result)
        {
          Assert.To.AssignableTo<T>(type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.AssignableTo<T>(type, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To)).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}