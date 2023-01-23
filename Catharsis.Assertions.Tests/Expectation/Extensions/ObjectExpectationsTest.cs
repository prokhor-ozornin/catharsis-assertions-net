using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="ObjectExpectations"/>.</para>
/// </summary>
public sealed class ObjectExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Same{T}(IExpectation{T}, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Same_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.Same<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Equal{T}(IExpectation{T}, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equal_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.Equal<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Default{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.Default<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.OfType{T}(IExpectation{T}, Type)"/> method.</para>
  /// </summary>
  [Fact]
  public void OfType_Methods()
  {
    AssertionExtensions.Should(() => ObjectExpectations.OfType<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((object) null).Expect().OfType(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => new object().Expect().OfType(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Null{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.Null(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.OneOf{T}(IExpectation{T}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void OneOf_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.OneOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((object) null).Expect().OneOf(Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => new object().Expect().OneOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("values");

    throw new NotImplementedException();
  }
}