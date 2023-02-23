namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="IComparable{T}"/> types.</para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class IComparableProtections
{
  /// <summary>
  ///   <para>Protects given comparable element from being "positive" (higher than its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value">Element to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Negative{T}(IProtection, T, string)"/>
  public static T Positive<T>(this IProtection protection, T value, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(value.CompareTo(default) > 0, error);

    return value;
  }

  /// <summary>
  ///   <para>Protects given comparable element from being "negative" (lower than its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value">Element to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Positive{T}(IProtection, T, string)"/>
  public static T Negative<T>(this IProtection protection, T value, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    
    protection.Truth(value.CompareTo(default) < 0, error);

    return value;
  }

  /// <summary>
  ///   <para>Protects given comparable element from being "zero" (equal to its default value).</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value">Element to protect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static T Zero<T>(this IProtection protection, T value, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(value.CompareTo(default) == 0, error);

    return value;
  }

  /// <summary>
  ///   <para>Protects given comparable element from lying out of a specified range of values.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="min">Range lower bound (inclusive).</param>
  /// <param name="max">Range upper bound (inclusive).</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  /// <seealso cref="OutOfRange(IProtection, int, Range, string)"/>
  public static T OutOfRange<T>(this IProtection protection, T value, T min, T max, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
    {
      throw new ArgumentOutOfRangeException(error);
    }

    return value;
  }

  /// <summary>
  ///   <para>Protects given comparable element from lying out of a specified range of values.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="range">Range of possible values.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  /// <seealso cref="OutOfRange{T}(IProtection, T, T, T, string)"/>
  public static int OutOfRange(this IProtection protection, int value, Range range, string error = null) => protection.OutOfRange(value, range.Start.Value, range.End.Value, error);
}