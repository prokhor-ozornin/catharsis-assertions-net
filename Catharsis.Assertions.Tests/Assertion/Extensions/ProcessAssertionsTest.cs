using System.Diagnostics;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
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
    AssertionExtensions.Should(() => ProcessAssertions.Exited(null, Process.GetCurrentProcess())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Exited(null)).ThrowExactly<ArgumentNullException>().WithParameterName("process");

    AssertionExtensions.Should(() => Assert.To.Exited(Process.GetCurrentProcess(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    ShellProcess.With(process =>
    {
      process.TryFinallyKill(process => process.Start());
      Assert.To.Exited(process).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessAssertions.ExitCode(IAssertion, Process, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ExitCode_Method()
  {
    AssertionExtensions.Should(() => Assert.To.ExitCode(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("process");

    AssertionExtensions.Should(() => Assert.To.ExitCode(Process.GetCurrentProcess(), 0, "error")).ThrowExactly<InvalidOperationException>();

    ShellProcess.With(process =>
    {
      process.TryFinallyKill(process => process.Start());

      AssertionExtensions.Should(() => ProcessAssertions.ExitCode(null, process, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ExitCode(process, 0, "error")).ThrowExactly<InvalidOperationException>();
      Assert.To.ExitCode(process, process.ExitCode).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }
}