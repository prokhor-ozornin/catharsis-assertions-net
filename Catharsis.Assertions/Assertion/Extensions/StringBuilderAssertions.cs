using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="StringBuilder"/> type.</para>
/// </summary>
/// <seealso cref="StringBuilder"/>
public static class StringBuilderAssertions
{
  /// <summary>
  ///   <para>Asserts that a given string builder contains a specified number of characters.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="builder">String builder to inspect.</param>
  /// <param name="length">Asserted string builder length.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="builder"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Length(this IAssertion assertion, StringBuilder builder, int length, string error = null) => builder is not null ? assertion.True(builder.Length == length, error) : throw new ArgumentNullException(nameof(builder));

  /// <summary>
  ///   <para>Asserts that a given string builder is empty (contains to characters).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="builder">String builder to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="builder"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, StringBuilder builder, string error = null) => assertion.Length(builder, 0, error);
}