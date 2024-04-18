using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ThreadAssertions.State(null, Thread.CurrentThread, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.State(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("thread");
    }

    return;

    static void Validate(bool result, Thread thread, ThreadState state)
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
    }

    return;

    static void Validate(bool result, Thread thread, ThreadPriority priority)
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