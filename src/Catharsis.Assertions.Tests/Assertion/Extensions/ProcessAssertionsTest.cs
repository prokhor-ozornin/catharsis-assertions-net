using System.Diagnostics;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ProcessAssertions"/>.</para>
/// </summary>
public sealed class ProcessAssertionsTest : Test
{
  private Process ShellProcess { get; } = "cmd.exe".ToProcess();

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessAssertions.Exited(IAssertion, Process, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Exited_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ProcessAssertions.Exited(null, Process.GetCurrentProcess())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Exited(null)).ThrowExactly<ArgumentNullException>().WithParameterName("process");

      Test(true, ShellProcess.Run(TimeSpan.Zero));
      Test(false, Process.GetCurrentProcess());
    }

    return;

    static void Test(bool result, Process process)
    {
      if (result)
      {
        Assert.To.Exited(process).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Exited(process, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessAssertions.ExitCode(IAssertion, Process, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ExitCode_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => Assert.To.ExitCode(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("process");
      
      AssertionExtensions.Should(() => Assert.To.ExitCode(Process.GetCurrentProcess(), 0, "error")).ThrowExactly<InvalidOperationException>();

      Test(true, ShellProcess, ShellProcess.Run(TimeSpan.Zero).ExitCode);
      Test(false, ShellProcess, 0);
    }

    return;

    static void Test(bool result, Process process, int code)
    {
      if (result)
      {
        Assert.To.ExitCode(process, code).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ExitCode(process, code, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}