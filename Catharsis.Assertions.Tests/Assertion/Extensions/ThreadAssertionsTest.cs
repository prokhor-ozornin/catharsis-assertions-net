using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ThreadAssertions"/>.</para>
/// </summary>
public sealed class ThreadAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ThreadAssertions.State(IAssertion, Thread, ThreadState, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void State_Method()
  {
    AssertionExtensions.Should(() => ThreadAssertions.State(null, Thread.CurrentThread, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.State(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("thread");

    AssertionExtensions.Should(() => Assert.To.State(Thread.CurrentThread, ThreadState.Unstarted, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.State(Thread.CurrentThread, Thread.CurrentThread.ThreadState).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ThreadAssertions.Priority(IAssertion, Thread, ThreadPriority, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Priority_Method()
  {
    AssertionExtensions.Should(() => ThreadAssertions.Priority(null, Thread.CurrentThread, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Priority(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("thread");

    AssertionExtensions.Should(() => Assert.To.Priority(Thread.CurrentThread, ThreadPriority.Highest, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Priority(Thread.CurrentThread, Thread.CurrentThread.Priority).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}