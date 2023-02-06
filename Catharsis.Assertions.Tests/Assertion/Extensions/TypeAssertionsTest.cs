using System.Reflection;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TypeAssertions"/>.</para>
/// </summary>
public sealed class TypeAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Abstract(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Abstract_Method()
  {
    AssertionExtensions.Should(() => TypeAssertions.Abstract(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => TypeAssertions.Abstract(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    AssertionExtensions.Should(() => Assert.To.Abstract(typeof(object), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Abstract(typeof(Stream)).Should().NotBeNull().And.BeSameAs(Assert.To);

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
    {
      if (type.IsAbstract)
      {
        Assert.To.Abstract(type).Should().NotBeNull().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Abstract(type, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Sealed(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sealed_Method()
  {
    AssertionExtensions.Should(() => TypeAssertions.Sealed(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Sealed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    AssertionExtensions.Should(() => Assert.To.Sealed(typeof(object), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Sealed(typeof(FileInfo)).Should().NotBeNull().And.BeSameAs(Assert.To);

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
    {
      if (type.IsSealed)
      {
        Assert.To.Sealed(type).Should().NotBeNull().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Sealed(type, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Static(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => TypeAssertions.Static(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => TypeAssertions.Static(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    AssertionExtensions.Should(() => Assert.To.Static(typeof(object), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Static(typeof(Enumerable)).Should().NotBeNull().And.BeSameAs(Assert.To);

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
    {
      if (type.IsAbstract && type.IsSealed)
      {
        Assert.To.Static(type).Should().NotBeNull().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Static(type, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Public(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => TypeAssertions.Public(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => TypeAssertions.Public(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    Assert.To.Public(typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Public(typeof(Assertion), "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
    {
      if (type.IsPublic && type.IsVisible)
      {
        Assert.To.Public(type).Should().NotBeNull().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Public(type, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Internal(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    AssertionExtensions.Should(() => TypeAssertions.Internal(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Internal((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    AssertionExtensions.Should(() => Assert.To.Internal(typeof(object), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Internal(typeof(Assertion)).Should().NotBeNull().And.BeSameAs(Assert.To);

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
    {
      if (type.IsNotPublic && !type.IsVisible)
      {
        Assert.To.Internal(type).Should().NotBeNull().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Internal(type, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    });
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

      Assert.To.AssignableTo(typeof(object), typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.AssignableTo(typeof(object), typeof(string), "error")).ThrowExactly<ArgumentException>();
      Assert.To.AssignableTo(typeof(string), typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.AssignableTo(typeof(string), typeof(IEnumerable<char>)).Should().NotBeNull().And.BeSameAs(Assert.To);

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Assert.To.AssignableTo(type, type).Should().NotBeNull().And.BeSameAs(Assert.To);
        Assert.To.AssignableTo(type, typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      });
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.AssignableTo<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.AssignableTo<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("from");

      Assert.To.AssignableTo<object>(typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.AssignableTo<string>(typeof(object), "error").Should().NotBeNull().And.BeSameAs(Assert.To)).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.AssignableTo<object>(typeof(string)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.AssignableTo<IEnumerable<char>>(typeof(string)).Should().NotBeNull().And.BeSameAs(Assert.To);

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Assert.To.AssignableTo<object>(type).Should().NotBeNull().And.BeSameAs(Assert.To);
      });
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
      AssertionExtensions.Should(() => Assert.To.AssignableFrom(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("from");
      AssertionExtensions.Should(() => Assert.To.AssignableFrom(typeof(object), null)).ThrowExactly<ArgumentNullException>().WithParameterName("to");

      Assert.To.AssignableFrom(typeof(object), typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.AssignableFrom(typeof(string), typeof(object), "error")).ThrowExactly<ArgumentException>();
      Assert.To.AssignableFrom(typeof(object), typeof(string)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.AssignableFrom(typeof(IEnumerable<char>), typeof(string)).Should().NotBeNull().And.BeSameAs(Assert.To);

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Assert.To.AssignableFrom(type, type).Should().NotBeNull().And.BeSameAs(Assert.To);
        Assert.To.AssignableFrom(typeof(object), type).Should().NotBeNull().And.BeSameAs(Assert.To);
      });
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.AssignableFrom<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.AssignableFrom<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("from");

      Assert.To.AssignableFrom<object>(typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.AssignableFrom<object>(typeof(string), "error").Should().NotBeNull().And.BeSameAs(Assert.To)).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.AssignableFrom<string>(typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.AssignableFrom<string>(typeof(IEnumerable<char>)).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }
}