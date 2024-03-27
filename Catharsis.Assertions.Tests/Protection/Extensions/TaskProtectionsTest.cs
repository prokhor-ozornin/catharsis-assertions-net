using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TaskProtections"/>.</para>
/// </summary>
public sealed class TaskProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskProtections.Status(IProtection, Task, TaskStatus, string)"/></description></item>
  ///     <item><description><see cref="TaskProtections.Status{T}(IProtection, Task{T}, TaskStatus, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Status_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskProtections.Status(null, Task.CompletedTask, default)).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("protection").Await();
      AssertionExtensions.Should(() => Protect.From.Status(null, default, "error")).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("task").Await();

      AssertionExtensions.Should(() => Protect.From.Status(Task.CompletedTask, TaskStatus.RanToCompletion, "error")).ThrowExactlyAsync<ArgumentException>().WithMessage("error").Await();
      Task.CompletedTask.With(task => Protect.From.Status(task, TaskStatus.Canceled).Should().BeOfType<Task>().And.BeSameAs(task));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskProtections.Status(null, Task.FromResult<object>(null), default)).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("protection").Await();
      AssertionExtensions.Should(() => Protect.From.Status((Task<object>) null, default)).ThrowExactlyAsync<ArgumentNullException>().WithParameterName("task").Await();

      AssertionExtensions.Should(() => Protect.From.Status(Task.FromResult<object>(null), TaskStatus.RanToCompletion, "error")).ThrowExactlyAsync<ArgumentException>().WithMessage("error").Await();
      Task.FromResult<object>(null).With(task => Protect.From.Status(task, TaskStatus.Canceled).Should().BeOfType<Task<object>>().And.BeSameAs(task));
    }
  }
}