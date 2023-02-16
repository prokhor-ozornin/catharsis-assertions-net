namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class ComparableAssertions
{
  /// <summary>
  ///   <para>Asserts that a given comparable element is "positive" (higher than its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Negative{T}(IAssertion, T, string)"/>
  public static IAssertion Positive<T>(this IAssertion assertion, T value, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(default) > 0, error);

  /// <summary>
  ///   <para>Asserts that a given comparable element is "negative" (lower than its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Positive{T}(IAssertion, T, string)"/>
  public static IAssertion Negative<T>(this IAssertion assertion, T value, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(default) < 0, error);

  /// <summary>
  ///   <para>Asserts that a given comparable element is "zero" (equal to its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Zero<T>(this IAssertion assertion, T value, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(default) == 0, error);

  /// <summary>
  ///   <para>Asserts that a given comparable element is greater than a specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="other">Value to compare with.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="GreaterOrEqual{T}(IAssertion, T, T, string)"/>
  public static IAssertion Greater<T>(this IAssertion assertion, T value, T other, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(other) > 0, error);

  /// <summary>
  ///   <para>Asserts that a given comparable element is greater than or equal to a specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="other">Value to compare with.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Greater{T}(IAssertion, T, T, string)"/>
  public static IAssertion GreaterOrEqual<T>(this IAssertion assertion, T value, T other, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(other) >= 0, error);

  /// <summary>
  ///   <para>Asserts that a given comparable element is lesser than a specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="other">Value to compare with.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="LesserOrEqual{T}(IAssertion, T, T, string)"/>
  public static IAssertion Lesser<T>(this IAssertion assertion, T value, T other, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(other) < 0, error);

  /// <summary>
  ///   <para>Asserts that a given comparable element is lesser than or equal to a specified value.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="other">Value to compare with.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Lesser{T}(IAssertion, T, T, string)"/>
  public static IAssertion LesserOrEqual<T>(this IAssertion assertion, T value, T other, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(other) <= 0, error);

  /// <summary>
  ///   <para>Asserts that a given comparable element lies within a specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="min">Lower bound of the range (inclusive).</param>
  /// <param name="max">Upper bound of the range (inclusive).</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="OutOfRange{T}(IAssertion, T, T, T, string)"/>
  public static IAssertion InRange<T>(this IAssertion assertion, T value, T min, T max, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0, error);

  /// <summary>
  ///   <para>Asserts that a given comparable element lies out of a specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="min">Lower bound of the range (inclusive).</param>
  /// <param name="max">Upper bound of the range (inclusive).</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="InRange{T}(IAssertion, T, T, T, string)"/>
  public static IAssertion OutOfRange<T>(this IAssertion assertion, T value, T min, T max, string error = null) where T : struct, IComparable<T> => assertion.True(value.CompareTo(min) < 0 || value.CompareTo(max) > 0, error);
}