using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectExpectations.Same<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Validate(true, (object) null, null);
      new object().With(instance => Validate(true, instance, instance));
      Validate(false, new object(), null);
      Validate(false, (object) null, new object());
    }

    return;

    static void Validate<T>(bool result, T instance, object other) => instance.Expect().Same(other).Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
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

      Validate(true, (object) null, null);
      new object().With(instance => Validate(true, instance, instance));

      Validate(true, 0, 0);
      Validate(true, DateTime.Today, DateTime.Today);

      Validate(false, new object(), null);
      Validate(false, (object) null, new object());
      Validate(false, Guid.NewGuid(), Guid.NewGuid());
    }

    return;

    static void Validate<T>(bool result, T instance, object other) => instance.Expect().Equal(other).Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
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

      Validate(true, (object) null);
      Validate(false, new object());

      Validate(true, 0);
      Validate(false, int.MinValue);

      Validate(true, DateTime.MinValue);
      Validate(false, DateTime.Today);

      Validate(true, Guid.Empty);
      Validate(false, Guid.NewGuid());
    }

    return;

    static void Validate<T>(bool result, T instance) => instance.Expect().Default().Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
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

      Validate(true, new object(), typeof(object));
      Validate(false, new object(), typeof(string));
    }

    return;

    static void Validate<T>(bool result, T instance, Type type) => instance.Expect().OfType(type).Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
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

      Validate(true, (object) null);
      Validate(false, new object());
    }

    return;

    static void Validate<T>(bool result, T instance) => instance.Expect().Null().Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
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

      Validate(true, null, new object[] { null, new(), null });
      Validate(true, string.Empty, new object[] { string.Empty, Guid.Empty, new() });
      Validate(false, null, Enumerable.Empty<object>());
      Validate(false, new object(), [new object()]);
    }

    return;

    static void Validate<T>(bool result, T instance, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null) => instance.Expect().OneOf(sequence, comparer).Should().BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
  }
}