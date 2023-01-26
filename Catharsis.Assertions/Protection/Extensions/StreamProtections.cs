namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Stream"/>
public static class StreamProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="TStream"></typeparam>
  /// <param name="protection"></param>
  /// <param name="stream"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static TStream Empty<TStream>(this IProtection protection, TStream stream, string message = null) where TStream : Stream
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (stream is null) throw new ArgumentNullException(message);

    if (stream.Length == 0)
    {
      throw new ArgumentException(message);
    }

    return stream;
  }
}