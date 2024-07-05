namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="bool"/> type.</para>
/// </summary>
/// <seealso cref="bool"/>
public static class BooleanAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given boolean expression is <see langword="true"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="expected">Boolean expression to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
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
  ///   <para>This function asserts that the given boolean expression is <see langword="false"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="expected">Boolean expression to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
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