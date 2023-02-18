namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="Range"/> type.</para>
/// </summary>
/// <seealso cref="Range"/>
public static class RangeAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="range"></param>
  /// <param name="index"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion StartIndex(this IAssertion assertion, Range range, int index, string error = null) => assertion.True(range.Start.Value == index, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="range"></param>
  /// <param name="index"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion EndIndex(this IAssertion assertion, Range range, int index, string error = null) => assertion.True(range.End.Value == index, error);
}