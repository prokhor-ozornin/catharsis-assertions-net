using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TaskAssertions"/>.</para>
/// </summary>
public sealed class TaskAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Successful(IAssertion, Task, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Successful{T}(IAssertion, Task{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Successful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Successful(null, Task.CompletedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => TaskAssertions.Successful(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Assert.To.Successful(Task.CompletedTask).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Successful(Task.FromCanceled(new CancellationToken(true)), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Successful(Task.FromException(new Exception()), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Successful(null, Task.FromResult<object>(null))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Assert.To.Successful(Task.FromResult<object>(null)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Successful(Task.FromCanceled<object>(new CancellationToken(true)), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Successful(Task.FromException<object>(new Exception()), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Unsuccessful(IAssertion, Task, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Unsuccessful{T}(IAssertion, Task{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Unsuccessful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Unsuccessful(null, Task.CompletedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      AssertionExtensions.Should(() => Assert.To.Unsuccessful(Task.CompletedTask, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful(Task.FromCanceled(new CancellationToken(true)), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Unsuccessful(Task.FromException(new Exception())).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Unsuccessful(null, Task.FromResult<object>(null))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      AssertionExtensions.Should(() => Assert.To.Unsuccessful(Task.FromResult<object>(null), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful(Task.FromCanceled<object>(new CancellationToken(true)), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Unsuccessful(Task.FromException<object>(new Exception())).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Canceled(IAssertion, Task, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Canceled{T}(IAssertion, Task{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Canceled_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Canceled(null, Task.CompletedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Canceled(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      AssertionExtensions.Should(() => Assert.To.Canceled(Task.CompletedTask, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Canceled(Task.FromCanceled(new CancellationToken(true))).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Canceled(Task.FromException(new Exception()), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Canceled(null, Task.FromResult<object>(null))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      AssertionExtensions.Should(() => Assert.To.Canceled(Task.FromResult<object>(null), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Canceled(Task.FromCanceled<object>(new CancellationToken(true))).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Canceled(Task.FromException<object>(new Exception()), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Completed(IAssertion, Task, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Completed{T}(IAssertion, Task{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Completed_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Completed(null, Task.CompletedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Completed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Assert.To.Completed(Task.CompletedTask).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Completed(Task.FromCanceled(new CancellationToken(true))).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Completed(Task.FromException(new Exception())).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Completed(null, Task.FromResult<object>(null))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Assert.To.Completed(Task.FromResult<object>(null)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Completed(Task.FromCanceled<object>(new CancellationToken(true))).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Completed(Task.FromException<object>(new Exception())).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }
}