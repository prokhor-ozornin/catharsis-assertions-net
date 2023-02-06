using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectAssertions"/>.</para>
/// </summary>
public sealed class ObjectAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Same{T}(IAssertion, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Same_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.Same(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.Same<object>(null, null).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Same(new object(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Same<object>(null, new object(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    new object().With(instance => Assert.To.Same(instance, instance).Should().NotBeNull().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Equal{T}(IAssertion, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equal_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.Equal(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.Equal<object>(null, null).Should().NotBeNull().And.BeSameAs(Assert.To);
    new object().With(instance => Assert.To.Equal(instance, instance).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.Equal(new object(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Equal<object>(null, new object(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Equal(0, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Equal(DateTime.Today, DateTime.Today).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Equal(Guid.NewGuid(), Guid.NewGuid(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Default{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.Default(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.Default<object>(null).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Default(new object(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.Default(0).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Default(int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.Default(DateTime.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Default(DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Assert.To.Default(Guid.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Default(Guid.NewGuid(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ObjectAssertions.OfType(IAssertion, object, Type, string)"/></description></item>
  ///     <item><description><see cref="ObjectAssertions.OfType{T}(IAssertion, object, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void OfType_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.OfType(null, new object(), typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.OfType(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("instance");
      AssertionExtensions.Should(() => Assert.To.OfType(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Assert.To.OfType(new object(), typeof(object)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.OfType(new object(), typeof(string), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.OfType<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.OfType<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("instance");

      Assert.To.OfType<object>(new object()).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.OfType<string>(new object(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Null{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.Null(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.Null<object>(null).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Null(new object(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.OneOf{T}(IAssertion, T, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OneOf_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.OneOf(null, new object(), Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.OneOf(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.OneOf(null, Enumerable.Empty<object>(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.OneOf(null, new object().ToSequence(null, null)).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.OneOf(new object(), new object().ToSequence(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.OneOf(string.Empty, new object().ToSequence(string.Empty, Guid.Empty)).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}