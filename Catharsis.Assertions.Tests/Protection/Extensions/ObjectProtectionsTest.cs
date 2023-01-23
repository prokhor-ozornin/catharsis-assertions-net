using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ObjectProtections"/>.</para>
/// </summary>
public sealed class ObjectProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectProtections.Being{T}(IProtection, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Being_Method()
  {
    AssertionExtensions.Should(() => ObjectProtections.Being(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

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