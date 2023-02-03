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
      AssertionExtensions.Should(() => ObjectProtections.Null(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.Null(null, new Lazy<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Equality{T}(IProtection, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equality_Method()
  {
    AssertionExtensions.Should(() => ObjectProtections.Equality(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Default{T}(IProtection, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    AssertionExtensions.Should(() => ObjectProtections.Default(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ObjectProtections.Null{T}(IProtection, T, string)"/></description></item>
  ///     <item><description><see cref="ObjectProtections.Null{T}(IProtection, Lazy{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Null_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.Null(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectProtections.Null(null, new Lazy<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    }

    throw new NotImplementedException();
  }
}