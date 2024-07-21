namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="IComparable{T}"/> types.</para>
/// </summary>
/// <seealso cref="IComparable{T}"/>
public static class IComparableProtections
{
  /// <summary>
  ///   <para>This function protects the given <see cref="IComparable"/> element from being "positive", ensuring that it's less than the default value of its type.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="comparable">Element to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Negative{T}(IProtection, T, string)"/>
  public static T Positive<T>(this IProtection protection, T comparable, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(comparable.CompareTo(default) > 0, error);

    return comparable;
  }

  /// <summary>
  ///   <para>This function protects the given comparable element from being "negative", ensuring that it's higher than the default value of its type.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="comparable">Element to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  /// <seealso cref="Positive{T}(IProtection, T, string)"/>
  public static T Negative<T>(this IProtection protection, T comparable, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    
    protection.Truth(comparable.CompareTo(default) < 0, error);

    return comparable;
  }

  /// <summary>
  ///   <para>This function protects the given comparable element from being "zero", ensuring that it's equal to the default value of its type.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="comparable">Element to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static T Zero<T>(this IProtection protection, T comparable, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    protection.Truth(comparable.CompareTo(default) == 0, error);

    return comparable;
  }

  /// <summary>
  ///   <para>This function protects given comparable element from being outside a specified range of values, ensuring that it remains within a particular margins.</para>
  /// </summary>
  /// <typeparam name="T">Type of element.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="comparable">Element to inspect.</param>
  /// <param name="min">Range lower bound, inclusive.</param>
  /// <param name="max">Range upper bound, inclusive.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  /// <seealso cref="OutOfRange(IProtection, int, Range, string)"/>
  public static T OutOfRange<T>(this IProtection protection, T comparable, T min, T max, string error = null) where T : struct, IComparable<T>
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));

    if (comparable.CompareTo(min) < 0 || comparable.CompareTo(max) > 0)
    {
      throw new ArgumentOutOfRangeException(error);
    }

    return comparable;
  }

  /// <summary>
  ///   <para>This function protects given comparable element from being outside a specified range of values, ensuring that it remains within a particular margins.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="value">Element to inspect.</param>
  /// <param name="range">Range of possible values.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="protection"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  /// <seealso cref="OutOfRange{T}(IProtection, T, T, T, string)"/>
  public static int OutOfRange(this IProtection protection, int value, Range range, string error = null) => protection.OutOfRange(value, range.Start.Value, range.End.Value, error);
}