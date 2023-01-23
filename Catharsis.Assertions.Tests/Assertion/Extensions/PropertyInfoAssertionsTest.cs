using System.Reflection;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PropertyInfoAssertions"/>.</para>
/// </summary>
public sealed class PropertyInfoAssertionsTest : UnitTest
{
  private PropertyInfo Property { get; } = typeof(string).AnyProperty(nameof(string.Length));

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.Readable(IAssertion, System.Reflection.PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoAssertions.Readable(null, Property)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => PropertyInfoAssertions.Readable(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.Writable(IAssertion, System.Reflection.PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoAssertions.Writable(null, Property)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => PropertyInfoAssertions.Writable(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.Value(IAssertion, System.Reflection.PropertyInfo, object, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoAssertions.Value(null, Property, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => PropertyInfoAssertions.Value(Assert.To, null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("property");
    AssertionExtensions.Should(() => Assert.To.Value(Property, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}