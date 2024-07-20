namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="IEnumerable{T}"/> types.</para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class IEnumerableProtections
{
  /// <summary>
  ///   <para>Protects the given <see cref="IEnumerable{T}"/> from being empty, ensuring that it contains at least one element.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the enumerable sequence.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="enumerable">Protected sequence of elements.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="enumerable"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static IEnumerable<T> Empty<T>(this IProtection protection, IEnumerable<T> enumerable, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));

    protection.Truth(!enumerable.Any(), error);

    return enumerable;
  }
}