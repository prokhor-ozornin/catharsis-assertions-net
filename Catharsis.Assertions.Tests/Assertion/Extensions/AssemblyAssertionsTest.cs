using System.Reflection;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="AssemblyAssertions"/>.</para>
/// </summary>
public sealed class AssemblyAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="AssemblyAssertions.Define(IAssertion, Assembly, Type, string)"/></description></item>
  ///     <item><description><see cref="AssemblyAssertions.Define{T}(IAssertion, Assembly, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Define_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyAssertions.Define(null, Assembly.GetExecutingAssembly(), typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Define(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assembly");
      AssertionExtensions.Should(() => Assert.To.Define(Assembly.GetExecutingAssembly(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyAssertions.Define<object>(null, Assembly.GetExecutingAssembly())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Define<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("assembly");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AssemblyAssertions.Dynamic(IAssertion, Assembly, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Dynamic_Method()
  {
    AssertionExtensions.Should(() => AssemblyAssertions.Dynamic(null, Assembly.GetExecutingAssembly())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Dynamic(null)).ThrowExactly<ArgumentNullException>().WithParameterName("assembly");

    throw new NotImplementedException();
  }
}