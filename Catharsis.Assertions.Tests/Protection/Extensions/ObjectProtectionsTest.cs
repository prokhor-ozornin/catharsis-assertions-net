using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectProtections"/>.</para>
/// </summary>
public sealed class ObjectProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Same{T}(IProtection, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Same_Method()
  {
    AssertionExtensions.Should(() => ObjectProtections.Same(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Same<object>(null, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    new object().With(instance => Protect.From.Same(instance, null).Should().NotBeNull().And.BeSameAs(instance));
    Protect.From.Same<object>(null, new object()).Should().BeNull();
    AssertionExtensions.Should(() => new object().With(instance => Protect.From.Same(instance, instance, "error"))).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ObjectProtections.OfType(IProtection, object, Type, string)"/></description></item>
  ///     <item><description><see cref="ObjectProtections.OfType{T}(IProtection, object, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void OfType_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.OfType(null, new object(), typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.OfType(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("instance");
      AssertionExtensions.Should(() => Protect.From.OfType(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      AssertionExtensions.Should(() => Protect.From.OfType(new object(), typeof(object), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      new object().With(instance => Protect.From.OfType(instance, typeof(string)).Should().NotBeNull().And.BeSameAs(instance));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.OfType<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.OfType<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("instance");

      AssertionExtensions.Should(() => Protect.From.OfType<object>(new object(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      new object().With(instance => Protect.From.OfType<string>(instance).Should().NotBeNull().And.BeSameAs(instance));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Equality{T}(IProtection, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equality_Method()
  {
    AssertionExtensions.Should(() => ObjectProtections.Equality(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Equality<object>(null, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    new object().With(instance => AssertionExtensions.Should(() => Protect.From.Equality(instance, instance, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    new object().With(instance => Protect.From.Equality(instance, null).Should().NotBeNull().And.BeSameAs(instance));
    Protect.From.Equality<object>(null, new object()).Should().BeNull();
    AssertionExtensions.Should(() => Protect.From.Equality(0, 0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Protect.From.Equality(DateTime.Today, DateTime.Today, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Guid.NewGuid().With(guid => Protect.From.Equality(guid, Guid.NewGuid()).Should().Be(guid));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Default{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    AssertionExtensions.Should(() => ObjectProtections.Default(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Default<object>(null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    new object().With(instance => Protect.From.Default(instance).Should().NotBeNull().And.BeSameAs(instance));

    AssertionExtensions.Should(() => Protect.From.Default(0, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Protect.From.Default(int.MinValue).Should().Be(int.MinValue);

    AssertionExtensions.Should(() => Protect.From.Default(DateTime.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Protect.From.Default(DateTime.Today).Should().Be(DateTime.Today);

    AssertionExtensions.Should(() => Protect.From.Default(Guid.Empty, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Guid.NewGuid().With(guid => Protect.From.Default(guid).Should().Be(guid));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Null{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    AssertionExtensions.Should(() => ObjectProtections.Null(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Null((object) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");
    new object().With(instance => Protect.From.Null(instance).Should().NotBeNull().And.BeSameAs(instance));
  }
}