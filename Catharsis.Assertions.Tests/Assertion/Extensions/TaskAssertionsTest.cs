using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TaskAssertions"/>.</para>
/// </summary>
public sealed class TaskAssertionsTest : UnitTest
{
  private Task<object> TypedTask { get; } = new(() => null);

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Exception(IAssertion, Task, AggregateException, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Exception{T}(IAssertion, Task{T}, AggregateException, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Exception_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Exception(null, Task.CompletedTask, new AggregateException())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Exception(null, new AggregateException())).ThrowExactly<ArgumentNullException>().WithParameterName("task");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Exception(null, TypedTask, new AggregateException())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Exception<object>(null, new AggregateException())).ThrowExactly<ArgumentNullException>().WithParameterName("task");

    }

    throw new NotImplementedException();
  }

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

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Successful(null, TypedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

    }

    throw new NotImplementedException();
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

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Unsuccessful(null, TypedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

    }

    throw new NotImplementedException();
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

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Canceled(null, TypedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

    }

    throw new NotImplementedException();
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

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Completed(null, TypedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

    }

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    TypedTask.Dispose();
  }
}