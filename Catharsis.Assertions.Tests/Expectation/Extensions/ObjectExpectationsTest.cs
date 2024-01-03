using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

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

    ((object) null).Expect().Same(null).Result.Should().BeTrue();
    new object().With(instance => instance.Expect().Same(null).Result.Should().BeFalse());
    ((object) null).Expect().Same(new object()).Result.Should().BeFalse();
    new object().With(instance => instance.Expect().Same(instance).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Equal{T}(IExpectation{T}, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equal_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.Equal<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    ((object) null).Expect().Equal(null).Result.Should().BeTrue();
    new object().With(instance => instance.Expect().Equal(instance).Result.Should().BeTrue());
    new object().Expect().Equal(null).Result.Should().BeFalse();
    ((object) null).Expect().Equal(new object()).Result.Should().BeFalse();
    0.Expect().Equal(0).Result.Should().BeTrue();
    DateTime.Today.Expect().Equal(DateTime.Today).Result.Should().BeTrue();
    Guid.NewGuid().Expect().Equal(Guid.NewGuid()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Default{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.Default<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    ((object) null).Expect().Default().Result.Should().BeTrue();
    new object().Expect().Default().Result.Should().BeFalse();

    0.Expect().Default().Result.Should().BeTrue();
    int.MinValue.Expect().Default().Result.Should().BeFalse();

    DateTime.MinValue.Expect().Default().Result.Should().BeTrue();
    DateTime.Today.Expect().Default().Result.Should().BeFalse();

    Guid.Empty.Expect().Default().Result.Should().BeTrue();
    Guid.NewGuid().Expect().Default().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.OfType{T}(IExpectation{T}, Type)"/> method.</para>
  /// </summary>
  [Fact]
  public void OfType_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.OfType<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((object) null).Expect().OfType(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => new object().Expect().OfType(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

    new object().Expect().OfType(typeof(object)).Result.Should().BeTrue();
    new object().Expect().OfType(typeof(string)).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Null{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.Null<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    ((object) null).Expect().Null().Result.Should().BeTrue();
    new object().Expect().Null().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.OneOf{T}(IExpectation{T}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void OneOf_Method()
  {
    AssertionExtensions.Should(() => ObjectExpectations.OneOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => new object().Expect().OneOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    ((object) null).Expect().OneOf(Enumerable.Empty<object>()).Result.Should().BeFalse();
    ((object) null).Expect().OneOf(new object[] { null, new(), null }).Result.Should().BeTrue();
    new object().Expect().OneOf(new object[] { new() }).Result.Should().BeFalse();
    string.Empty.Expect().OneOf(new object[] { string.Empty, Guid.Empty, new() }).Result.Should().BeTrue();
  }
}