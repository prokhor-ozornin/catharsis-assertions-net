using System.Diagnostics;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ProcessAssertions"/>.</para>
/// </summary>
public sealed class ProcessAssertionsTest : UnitTest
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

      Validate(true, ShellProcess.With(process => process.Start()));
      Validate(false, Process.GetCurrentProcess());
    }

    return;

    static void Validate(bool result, Process process)
    {
      process.TryFinallyKill(process =>
      {
        if (result)
        {
          Assert.To.Exited(process).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Exited(process, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      });
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
      AssertionExtensions.Should(() => Assert.To.ExitCode(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("process");
      
      AssertionExtensions.Should(() => Assert.To.ExitCode(Process.GetCurrentProcess(), 0, "error")).ThrowExactly<InvalidOperationException>();

      Validate(true, ShellProcess, ShellProcess.ExitCode);
      Validate(false, ShellProcess, 0);
    }

    return;

    static void Validate(bool result, Process process, int code)
    {
      process.TryFinallyKill(process =>
      {
        if (result)
        {
          Assert.To.ExitCode(process, code).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.ExitCode(process, code, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      });
    }
  }
}