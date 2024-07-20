namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for <see cref="Stream"/> type.</para>
/// </summary>
/// <seealso cref="Stream"/>
public static class StreamProtections
{
  /// <summary>
  ///   <para>Protects the given <see cref="Stream"/> from being empty, ensuring that its size is not zero.</para>
  /// </summary>
  /// <typeparam name="TStream">Type of stream.</typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="stream">Stream to protect.</param>
  /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
  public static TStream Empty<TStream>(this IProtection protection, TStream stream, string error = null) where TStream : Stream
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (stream is null) throw new ArgumentNullException(nameof(stream));

    protection.Truth(stream.Length == 0, error);

    return stream;
  }
}