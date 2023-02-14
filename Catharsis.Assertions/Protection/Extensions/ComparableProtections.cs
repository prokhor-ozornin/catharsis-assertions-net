namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class ComparableProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Negative{T}(IProtection, T, string)"/>
  public static T Positive<T>(this IProtection protection, T value, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(value.CompareTo(default) > 0, error);

    return value;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Positive{T}(IProtection, T, string)"/>
  public static T Negative<T>(this IProtection protection, T value, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    
    protection.Truth(value.CompareTo(default) < 0, error);

    return value;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static T Zero<T>(this IProtection protection, T value, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(value.CompareTo(default) == 0, error);

    return value;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value"></param>
  /// <param name="min"></param>
  /// <param name="max"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
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
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value"></param>
  /// <param name="range"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  /// <seealso cref="OutOfRange{T}(IProtection, T, T, T, string)"/>
  public static int OutOfRange(this IProtection protection, int value, Range range, string error = null) => protection.OutOfRange(value, range.Start.Value, range.End.Value, error);
}