using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MethodBaseExpectations"/>.</para>
/// </summary>
public sealed class MethodBaseExpectationsTest : UnitTest
{
  private MethodBase Method { get; } = typeof(string).AnyMethod(nameof(string.ToString));

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Abstract(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Abstract_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Abstract(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Abstract()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Final(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Final_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Final(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Final()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Private(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Private(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Private()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Public(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Public(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Public()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Static(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Virtual(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Virtual_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Virtual(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Virtual()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}