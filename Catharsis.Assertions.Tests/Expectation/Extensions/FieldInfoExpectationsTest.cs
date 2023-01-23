using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="FieldInfoExpectations"/>.</para>
/// </summary>
public sealed class FieldInfoExpectationsTest : UnitTest
{
  private FieldInfo Field { get; } = typeof(string).AnyField(nameof(string.Empty));

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="FieldInfoExpectations.Type(IExpectation{FieldInfo}, Type)"/></description></item>
  ///     <item><description><see cref="FieldInfoExpectations.Type{T}(IExpectation{FieldInfo})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Type_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Type(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Type(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Field.Expect().Type(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Type<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Type<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Private(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    AssertionExtensions.Should(() => FieldInfoExpectations.Private(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Private()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Public(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => FieldInfoExpectations.Public(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Public()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Static(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => FieldInfoExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Value(IExpectation{FieldInfo}, object, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => FieldInfoExpectations.Value(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Value(string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Field.Expect().Value(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}