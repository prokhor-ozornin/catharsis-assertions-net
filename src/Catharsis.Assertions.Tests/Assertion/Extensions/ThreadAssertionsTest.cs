using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ThreadAssertions"/>.</para>
/// </summary>
/// <seealso cref="ThreadAssertions"/>
public sealed class ThreadAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ThreadAssertions.State(IAssertion, Thread, ThreadState, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void State_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ThreadAssertions.State(null, Thread.CurrentThread, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.State(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("thread");

      Thread.CurrentThread.With(thread => Test(true, thread, thread.ThreadState));
      Test(false, Thread.CurrentThread, ThreadState.Unstarted);
    }

    return;

    static void Test(bool result, Thread thread, ThreadState state)
    {
      if (result)
      {
        Assert.To.State(thread, state).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.State(thread, state, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ThreadAssertions.Priority(IAssertion, Thread, ThreadPriority, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Priority_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ThreadAssertions.Priority(null, Thread.CurrentThread, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Priority(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("thread");

      Thread.CurrentThread.With(thread => Test(true, thread, thread.Priority));
      Test(false, Thread.CurrentThread, ThreadPriority.Highest);
    }

    return;

    static void Test(bool result, Thread thread, ThreadPriority priority)
    {
      if (result)
      {
        Assert.To.Priority(thread, priority).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Priority(thread, priority, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}