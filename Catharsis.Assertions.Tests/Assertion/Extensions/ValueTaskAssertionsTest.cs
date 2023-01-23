using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ValueTaskAssertions"/>.</para>
/// </summary>
public sealed class ValueTaskAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Successful(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Successful{T}(IAssertion, ValueTask{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Successful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Successful(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Successful<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Unsuccessful(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Unsuccessful{T}(IAssertion, ValueTask, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Unsuccessful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Unsuccessful(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Unsuccessful<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Canceled(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Canceled{T}(IAssertion, ValueTask, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Canceled_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Canceled(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Canceled<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Completed(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Completed{T}(IAssertion, ValueTask, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Completed_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Completed(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Completed<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    }

    throw new NotImplementedException();
  }
}