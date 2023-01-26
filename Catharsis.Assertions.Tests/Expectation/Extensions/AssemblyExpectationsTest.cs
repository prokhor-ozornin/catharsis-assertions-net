using System.Reflection;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="AssemblyExpectations"/>.</para>
/// </summary>
public sealed class AssemblyExpectationsTest : UnitTest
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
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => AssemblyExpectations.Define<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Assembly) null).Expect().Define<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AssemblyExpectations.Dynamic(IExpectation{Assembly})"/> method.</para>
  /// </summary>
  [Fact]
  public void Dynamic_Method()
  {
    AssertionExtensions.Should(() => AssemblyExpectations.Dynamic(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Assembly) null).Expect().Dynamic()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}