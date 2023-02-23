namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="IEnumerable{T}"/> types.</para>
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class IEnumerableProtections
{
  /// <summary>
  ///   <para>Protects given sequence from being empty (containing no elements).</para>
  /// </summary>
  /// <typeparam name="T">Type of elements in the sequence.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="sequence">Protected sequence of elements.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="sequence"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static IEnumerable<T> Empty<T>(this IProtection protection, IEnumerable<T> sequence, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (sequence is null) throw new ArgumentNullException(nameof(sequence));

    protection.Truth(!sequence.Any(), error);

    return sequence;
  }
}