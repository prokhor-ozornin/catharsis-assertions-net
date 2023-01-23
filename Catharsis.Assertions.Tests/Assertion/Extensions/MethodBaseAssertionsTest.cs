using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MethodBaseAssertions"/>.</para>
/// </summary>
public sealed class MethodBaseAssertionsTest : UnitTest
{
  private MethodBase Method { get; } = typeof(string).AnyMethod(nameof(string.ToString));

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Abstract(IAssertion, System.Reflection.MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Abstract_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Abstract(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Abstract(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Final(IAssertion, System.Reflection.MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Final_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Final(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Final(null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Private(IAssertion, System.Reflection.MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Private(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Private(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Public(IAssertion, System.Reflection.MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Public(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Public(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Static(IAssertion, System.Reflection.MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Static(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Static(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Virtual(IAssertion, System.Reflection.MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Virtual_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Virtual(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Virtual(null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    throw new NotImplementedException();
  }
}