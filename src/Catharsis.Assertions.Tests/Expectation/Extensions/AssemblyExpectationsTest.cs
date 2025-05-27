using System.Reflection;
using System.Reflection.Emit;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="AssemblyExpectations"/>.</para>
/// </summary>
public sealed class AssemblyExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="AssemblyExpectations.Define(IExpectation{Assembly}, Type)"/></description></item>
  ///     <item><description><see cref="AssemblyExpectations.Define{T}(IExpectation{Assembly})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Define_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyExpectations.Define(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Assembly) null).Expect().Define(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Assembly.GetExecutingAssembly().Expect().Define(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, Assembly.GetAssembly(typeof(object)), typeof(object));
      Test(false, Assembly.GetExecutingAssembly(), typeof(object));

      static void Test(bool result, Assembly assembly, Type type) => assembly.Expect().Define(type).Should().BeOfType<Expectation<Assembly>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyExpectations.Define<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Assembly) null).Expect().Define<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test<object>(true, Assembly.GetAssembly(typeof(object)));
      Test<object>(false, Assembly.GetExecutingAssembly());

      static void Test<T>(bool result, Assembly assembly) => assembly.Expect().Define<T>().Should().BeOfType<Expectation<Assembly>>().Which.Result.Should().Be(result);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AssemblyExpectations.Dynamic(IExpectation{Assembly})"/> method.</para>
  /// </summary>
  [Fact]
  public void Dynamic_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyExpectations.Dynamic(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Assembly) null).Expect().Dynamic()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Random.Letters(byte.MaxValue)), AssemblyBuilderAccess.RunAndCollect));
      Test(false, Assembly.GetExecutingAssembly());
    }

    static void Test(bool result, Assembly assembly) => assembly.Expect().Dynamic().Should().BeOfType<Expectation<Assembly>>().Which.Result.Should().Be(result);
  }
}