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

      Assert.To.Successful(ValueTask.CompletedTask).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Successful(ValueTask.FromCanceled(new CancellationToken(true)), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Successful(ValueTask.FromException(new Exception()), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Successful<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Assert.To.Successful(ValueTask.FromResult<object>(null)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Successful(ValueTask.FromCanceled<object>(new CancellationToken(true)), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Successful(ValueTask.FromException<object>(new Exception()), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Unsuccessful(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Unsuccessful{T}(IAssertion, ValueTask{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Unsuccessful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Unsuccessful(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      AssertionExtensions.Should(() => Assert.To.Unsuccessful(ValueTask.CompletedTask, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful(ValueTask.FromCanceled(new CancellationToken(true)), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Unsuccessful(ValueTask.FromException(new Exception())).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Assert.To.Unsuccessful(ValueTask.FromResult<object>(null), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful(ValueTask.FromCanceled<object>(new CancellationToken(true)), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Unsuccessful(ValueTask.FromException<object>(new Exception())).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Canceled(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Canceled{T}(IAssertion, ValueTask{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Canceled_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Canceled(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      AssertionExtensions.Should(() => Assert.To.Canceled(ValueTask.CompletedTask, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Canceled(ValueTask.FromCanceled(new CancellationToken(true))).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Canceled(ValueTask.FromException(new Exception()), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Canceled<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      AssertionExtensions.Should(() => Assert.To.Canceled(ValueTask.FromResult<object>(null), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Canceled(ValueTask.FromCanceled<object>(new CancellationToken(true))).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Canceled(ValueTask.FromException<object>(new Exception()), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Completed(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Completed{T}(IAssertion, ValueTask{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Completed_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Completed(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Assert.To.Completed(ValueTask.CompletedTask).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Completed(ValueTask.FromCanceled(new CancellationToken(true))).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Completed(ValueTask.FromException(new Exception())).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Completed<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Assert.To.Completed(ValueTask.FromResult<object>(null)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Completed(ValueTask.FromCanceled<object>(new CancellationToken(true))).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Completed(ValueTask.FromException<object>(new Exception())).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }
}