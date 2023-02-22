using System.Reflection;
using Catharsis.Extensions;
using System.Reflection.Emit;
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

      Assert.To.Define(Assembly.GetAssembly(typeof(object)), typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Define(Assembly.GetExecutingAssembly(), typeof(object), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyAssertions.Define<object>(null, Assembly.GetExecutingAssembly())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Define<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("assembly");

      Assert.To.Define<object>(Assembly.GetAssembly(typeof(object))).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Define<object>(Assembly.GetExecutingAssembly(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AssemblyAssertions.Dynamic(IAssertion, Assembly, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Dynamic_Method()
  {
    AssertionExtensions.Should(() => AssemblyAssertions.Dynamic(null, Assembly.GetExecutingAssembly())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Dynamic(null)).ThrowExactly<ArgumentNullException>().WithParameterName("assembly");

    AssertionExtensions.Should(() => Assert.To.Dynamic(Assembly.GetExecutingAssembly(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Dynamic(AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Randomizer.Letters(byte.MaxValue)), AssemblyBuilderAccess.RunAndCollect)).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}