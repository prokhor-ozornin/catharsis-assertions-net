using System.Reflection;
using Catharsis.Commons;
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

      Validate(true, Assembly.GetAssembly(typeof(object)), typeof(object));
      Validate(false, Assembly.GetExecutingAssembly(), typeof(object));

      static void Validate(bool result, Assembly assembly, Type type)
      {
        if (result)
        {
          Assert.To.Define(assembly, type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Define(assembly, type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyAssertions.Define<object>(null, Assembly.GetExecutingAssembly())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Define<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("assembly");

      Validate<object>(true, Assembly.GetAssembly(typeof(object)));
      Validate<object>(false, Assembly.GetExecutingAssembly());

      static void Validate<T>(bool result, Assembly assembly)
      {
        if (result)
        {
          Assert.To.Define<T>(assembly).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Define<T>(assembly, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AssemblyAssertions.Dynamic(IAssertion, Assembly, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Dynamic_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyAssertions.Dynamic(null, Assembly.GetExecutingAssembly())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Dynamic(null)).ThrowExactly<ArgumentNullException>().WithParameterName("assembly");
    }

    return;

    static void Validate(bool result, Assembly assembly)
    {
      if (result)
      {
        Assert.To.Dynamic(assembly).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Dynamic(assembly, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}