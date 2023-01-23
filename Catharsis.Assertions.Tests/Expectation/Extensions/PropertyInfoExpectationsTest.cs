using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="PropertyInfoExpectations"/>.</para>
/// </summary>
public sealed class PropertyInfoExpectationsTest : UnitTest
{
  private PropertyInfo Property { get; } = typeof(string).AnyProperty(nameof(string.Length));

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.Readable(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoExpectations.Readable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().Readable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.Writable(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoExpectations.Writable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().Writable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.Value(IExpectation{PropertyInfo}, object, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoExpectations.Value(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().Value(string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Property.Expect().Value(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}