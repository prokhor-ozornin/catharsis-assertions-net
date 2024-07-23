namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="Range"/> type.</para>
/// </summary>
/// <seealso cref="Range"/>
public static class RangeAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="Range"/>'s start index has a specified value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="range">Range to inspect.</param>
  /// <param name="index">Asserted index value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion StartIndex(this IAssertion assertion, Range range, int index, string error = null) => assertion.True(range.Start.Value == index, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="Range"/>'s end index has a specified value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="range">Range to inspect.</param>
  /// <param name="index">Asserted index value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion EndIndex(this IAssertion assertion, Range range, int index, string error = null) => assertion.True(range.End.Value == index, error);
}