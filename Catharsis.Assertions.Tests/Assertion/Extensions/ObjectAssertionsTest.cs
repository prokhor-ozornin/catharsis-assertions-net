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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Equal{T}(IAssertion, T, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Equal_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.Equal(null, new object(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Default{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Default_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.Default(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
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

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ObjectAssertions.OfType<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.OfType<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("instance");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.Null{T}(IAssertion, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.Null(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ObjectAssertions.OneOf{T}(IAssertion, T, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OneOf_Method()
  {
    AssertionExtensions.Should(() => ObjectAssertions.OneOf(null, new object(), Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.OneOf(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("values");

    throw new NotImplementedException();
  }
}