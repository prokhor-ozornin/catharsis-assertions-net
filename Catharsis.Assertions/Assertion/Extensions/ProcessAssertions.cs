using System.Diagnostics;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="Process"/> type.</para>
/// </summary>
/// <seealso cref="Process"/>
public static class ProcessAssertions
{
  /// <summary>
  ///   <para>Asserts that a given system process has been terminated.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="process">Local or remote process to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="process"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Exited(this IAssertion assertion, Process process, string error = null) => process is not null ? assertion.True(process.HasExited, error) : throw new ArgumentNullException(nameof(process));

  /// <summary>
  ///   <para>Asserts that a given system process has set a specified exit code when it terminated.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="process">Local or remote process to inspect.</param>
  /// <param name="code">Process exit code.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="process"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ExitCode(this IAssertion assertion, Process process, int code, string error = null) => process is not null ? assertion.True(process.ExitCode == code, error) : throw new ArgumentNullException(nameof(process));
}