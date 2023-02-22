namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="Stream"/> type.</para>
/// </summary>
/// <seealso cref="Stream"/>
public static class StreamExpectations
{
  /// <summary>
  ///   <para>Expects that a given stream has a specified length in bytes.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="length">Stream length.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> Length(this IExpectation<Stream> expectation, long length) => expectation.HaveSubject().And().Expected(stream => stream.Length == length);

  /// <summary>
  ///   <para>Expects that a given stream is empty (zero-length).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> Empty(this IExpectation<Stream> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para>Expects that a given stream is at specified position/offset.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="position">Position within the stream.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> Position(this IExpectation<Stream> expectation, long position) => expectation.HaveSubject().And().Expected(stream => stream.Position == position);

  /// <summary>
  ///   <para>Expects that a given stream is positioned at the end of it.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> End(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expected(stream => stream.Position == stream.Length);

  /// <summary>
  ///   <para>Expects that a given stream supports reading operations.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> Readable(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expected(stream => stream.CanRead);

  /// <summary>
  ///   <para>Expects that a given stream supports writing operations.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> Writable(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expected(stream => stream.CanWrite);

  /// <summary>
  ///   <para>Expects that a given stream supports seeking operations.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> Seekable(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expected(stream => stream.CanSeek);

  /// <summary>
  ///   <para>Expects that a given stream is read-only (does not support writing operations).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> ReadOnly(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expected(stream => stream.CanRead && !stream.CanWrite);

  /// <summary>
  ///   <para>Expects that a given stream is write-only (does not support reading operations).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Stream> WriteOnly(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expected(stream => stream.CanWrite && !stream.CanRead);
}