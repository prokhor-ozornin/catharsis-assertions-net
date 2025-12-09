using System.Diagnostics;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ProcessExpectations"/>.</para>
/// </summary>
/// <seealso cref="ProcessExpectations"/>
public sealed class ProcessExpectationsTest : Test
{
  private Process ShellProcess { get; } = "cmd.exe".ToProcess();

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessExpectations.Exited(IExpectation{Process})"/> method.</para>
  /// </summary>
  [Fact]
  public void Exited_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ProcessExpectations.Exited(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Process) null).Expect().Exited()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, ShellProcess.Run(TimeSpan.Zero));
      Test(false, Process.GetCurrentProcess());
    }

    return;

    static void Test(bool result, Process process) => process.Expect().Exited().Should().BeOfType<Expectation<Process>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessExpectations.ExitCode(IExpectation{Process}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void ExitCode_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ProcessExpectations.ExitCode(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Process) null).Expect().ExitCode(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      AssertionExtensions.Should(() => Process.GetCurrentProcess().Expect().ExitCode(0)).ThrowExactly<InvalidOperationException>();

      Test(true, ShellProcess, ShellProcess.Run(TimeSpan.Zero).ExitCode);
      Test(false, ShellProcess, 0);
    }

    return;

    static void Test(bool result, Process process, int code) => process.Expect().ExitCode(code).Should().BeOfType<Expectation<Process>>().Which.Result.Should().Be(result);
  }
}