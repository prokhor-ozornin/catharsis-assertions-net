namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class EnumerableProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="sequence"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IEnumerable<T> Empty<T>(this IProtection protection, IEnumerable<T> sequence, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));

    protection.Truth(!sequence.Any(), error);

    return sequence;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value"></param>
  /// <param name="values"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="AnyOf{T}(IProtection, T, string, T[])"/>
  public static T AnyOf<T>(this IProtection protection, T value, IEnumerable<T> values, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (values is null) throw new ArgumentNullException(nameof(values));

    protection.Truth(values.Contains(value), error);

    return value;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <param name="values"></param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="AnyOf{T}(IProtection, T, IEnumerable{T}, string)"/>
  public static T AnyOf<T>(this IProtection protection, T value, string error = null, params T[] values) => protection.AnyOf(value, values, error);
}