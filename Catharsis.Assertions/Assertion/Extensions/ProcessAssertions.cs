using System.Diagnostics;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="Process"/> type.</para>
/// </summary>
/// <seealso cref="Process"/>
public static class ProcessAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="Process"/> has completed.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="process">Local or remote process to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="process"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Exited(this IAssertion assertion, Process process, string error = null) => process is not null ? assertion.True(process.HasExited, error) : throw new ArgumentNullException(nameof(process));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Process"/> has set the specified exit code when it finished.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="process">Local or remote process to inspect.</param>
  /// <param name="code">Asserted exit code.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="process"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ExitCode(this IAssertion assertion, Process process, int code, string error = null) => process is not null ? assertion.True(process.ExitCode == code, error) : throw new ArgumentNullException(nameof(process));
}