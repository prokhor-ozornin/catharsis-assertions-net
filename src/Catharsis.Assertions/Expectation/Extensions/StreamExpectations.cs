namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="Stream"/> type.</para>
/// </summary>
/// <seealso cref="Stream"/>
public static class StreamExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<Stream> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> has the specified length.</para>
    /// </summary>
    /// <param name="length">Expected stream length.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> Length(long length) => expectation.HaveSubject().And().Expected(stream => stream.Length == length);

    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> is empty, meaning its length is zero.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> Empty() => expectation.Length(0);

    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> is at the specified position within the stream.</para>
    /// </summary>
    /// <param name="position">Expected position.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> Position(long position) => expectation.HaveSubject().And().Expected(stream => stream.Position == position);

    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> is positioned at the end.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> End() => expectation.HaveSubject().And().Expected(stream => stream.Position == stream.Length);

    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> is able to perform reading operations.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> Readable() => expectation.HaveSubject().And().Expected(stream => stream.CanRead);

    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> is able to perform writing operations.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> Writable() => expectation.HaveSubject().And().Expected(stream => stream.CanWrite);

    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> is able to perform seeking operations.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> Seekable() => expectation.HaveSubject().And().Expected(stream => stream.CanSeek);

    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> is read-only, which means it's able to perform read operations, but not write operations.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> ReadOnly() => expectation.HaveSubject().And().Expected(stream => stream.CanRead && !stream.CanWrite);

    /// <summary>
    ///   <para>Expects that the given <see cref="Stream"/> is read-only, which means it's able to perform write operations, but not read operations.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Stream> WriteOnly() => expectation.HaveSubject().And().Expected(stream => stream.CanWrite && !stream.CanRead);
  }
}