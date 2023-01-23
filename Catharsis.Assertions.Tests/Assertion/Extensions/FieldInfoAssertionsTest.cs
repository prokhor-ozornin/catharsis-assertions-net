using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FieldInfoAssertions"/>.</para>
/// </summary>
public sealed class FieldInfoAssertionsTest : UnitTest
{
  private FieldInfo Field { get; } = typeof(string).AnyField(nameof(string.Empty));

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="FieldInfoAssertions.Type(IAssertion, System.Reflection.FieldInfo, Type, string)"/></description></item>
  ///     <item><description><see cref="FieldInfoAssertions.Type{T}(IAssertion, System.Reflection.FieldInfo, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Type_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Type(null, Field, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Type(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("field");
      AssertionExtensions.Should(() => Assert.To.Type(Field, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Type<object>(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Type<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Private(IAssertion, System.Reflection.FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Private(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Private(Field)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Public(IAssertion, System.Reflection.FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Public(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Public(Field)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Static(IAssertion, System.Reflection.FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Static(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Static(Field)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Value(IAssertion, System.Reflection.FieldInfo, object, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Value(null, Field, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => FieldInfoAssertions.Value(Assert.To, null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("field");
    AssertionExtensions.Should(() => Assert.To.Value(Field, null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}