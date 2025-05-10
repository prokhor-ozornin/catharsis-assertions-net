using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectExpectations"/>.</para>
/// </summary>
public sealed class ObjectExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Same{T}(IExpectation{T}, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Same_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectExpectations.Same<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test<object>(true, null, null);
      new object().With(instance => Test(true, instance, instance));
      Test(false, new object(), null);
      Test<object>(false, null, new object());
    }

    return;

    static void Test<T>(bool result, T instance, object other) => instance.Expect().Same(other).Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Equal{T}(IExpectation{T}, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectExpectations.Equal<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test<object>(true, null, null);
      new object().With(instance => Test(true, instance, instance));

      Test(true, 0, 0);
      Test(true, DateTime.Today, DateTime.Today);

      Test(false, new object(), null);
      Test<object>(false, null, new object());
      Test(false, Guid.NewGuid(), Guid.NewGuid());
    }

    return;

    static void Test<T>(bool result, T instance, object other) => instance.Expect().Equal(other).Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Default{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectExpectations.Default<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test<object>(true, null);
      Test(false, new object());

      Test(true, 0);
      Test(false, int.MinValue);

      Test(true, DateTime.MinValue);
      Test(false, DateTime.Today);

      Test(true, Guid.Empty);
      Test(false, Guid.NewGuid());
    }

    return;

    static void Test<T>(bool result, T instance) => instance.Expect().Default().Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.OfType{T}(IExpectation{T}, Type)"/> method.</para>
  /// </summary>
  [Fact]
  public void OfType_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectExpectations.OfType<object>(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((object) null).Expect().OfType(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new object().Expect().OfType(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, new object(), typeof(object));
      Test(false, new object(), typeof(string));
    }

    return;

    static void Test<T>(bool result, T instance, Type type) => instance.Expect().OfType(type).Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.Null{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectExpectations.Null<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test<object>(true, null);
      Test(false, new object());
    }

    return;

    static void Test<T>(bool result, T instance) => instance.Expect().Null().Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectExpectations.OneOf{T}(IExpectation{T}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void OneOf_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectExpectations.OneOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => new object().Expect().OneOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Test(true, null, new object[] { null, new(), null });
      Test(true, string.Empty, new object[] { string.Empty, Guid.Empty, new() });
      Test(false, null, Enumerable.Empty<object>());
      Test(false, new object(), [new object()]);
    }

    return;

    static void Test<T>(bool result, T instance, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null) => instance.Expect().OneOf(sequence, comparer).Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
  }
}