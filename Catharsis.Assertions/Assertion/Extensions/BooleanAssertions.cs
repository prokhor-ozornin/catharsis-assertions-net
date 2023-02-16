namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="bool"/> basic type.</para>
/// </summary>
/// <seealso cref="bool"/>
public static class BooleanAssertions
{
  /// <summary>
  ///   <para>Asserts that a given boolean expression evaluates to be <see langword="true"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="expected">Boolean expression to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion True(this IAssertion assertion, bool? expected, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));

    if (assertion.Invalid(expected.GetValueOrDefault()))
    {
      throw new InvalidOperationException(error);
    }

    return assertion;
  }

  /// <summary>
  ///   <para>Asserts that a given boolean expression evaluates to be <see langword="false"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="expected">Boolean expression to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion False(this IAssertion assertion, bool? expected, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));

    if (assertion.Invalid(!expected.GetValueOrDefault()))
    {
      throw new InvalidOperationException(error);
    }

    return assertion;
  }
}