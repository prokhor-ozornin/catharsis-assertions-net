using System.Diagnostics;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class ProcessAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="process"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Exited(this IAssertion assertion, Process process, string message = null) => process is not null ? assertion.True(process.HasExited, message) : throw new ArgumentNullException(nameof(process));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="process"></param>
  /// <param name="code"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion ExitCode(this IAssertion assertion, Process process, int code, string message = null) => process is not null ? assertion.True(process.ExitCode == code, message) : throw new ArgumentNullException(nameof(process));
}