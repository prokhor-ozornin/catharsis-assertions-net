using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Sealed(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Sealed_Method()
  {
    AssertionExtensions.Should(() => TypeAssertions.Sealed(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Sealed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeAssertions.Static(IAssertion, Type, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => TypeAssertions.Static(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => TypeAssertions.Static(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    throw new NotImplementedException();
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
      AssertionExtensions.Should(() => Assert.To.AssignableTo(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("current");
      AssertionExtensions.Should(() => Assert.To.AssignableTo(typeof(object), null)).ThrowExactly<ArgumentNullException>().WithParameterName("target");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.AssignableTo<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.AssignableTo<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("current");

    }

    throw new NotImplementedException();
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
      AssertionExtensions.Should(() => Assert.To.AssignableFrom(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("current");
      AssertionExtensions.Should(() => Assert.To.AssignableFrom(typeof(object), null)).ThrowExactly<ArgumentNullException>().WithParameterName("target");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeAssertions.AssignableFrom<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.AssignableFrom<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("current");

    }

    throw new NotImplementedException();
  }
}