namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of protections for <see cref="Stream"/> type.</para>
/// </summary>
/// <seealso cref="Stream"/>
public static class StreamProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TStream"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="stream"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static TStream Empty<TStream>(this IProtection protection, TStream stream, string error = null) where TStream : Stream
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (stream is null) throw new ArgumentNullException(nameof(stream));

    protection.Truth(stream.Length == 0, error);

    return stream;
  }
}