namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of extension methods for <see cref="IExpectation{T}"/> interface.</para>
/// </summary>
/// <seealso cref="IExpectation{T}"/>
public static class IExpectationExtensions
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  extension<T>(IExpectation<T> expectation)
  {
    /// <summary>
    ///   <para>Expects a specified result, expressed as a predicate.</para>
    /// </summary>
    /// <param name="result">Expected result.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="expectation"/> or <paramref name="result"/> is <see langword="null"/>.</exception>
    public IExpectation<T> Expected(Predicate<T> result)
    {
      if (expectation is null) throw new ArgumentNullException(nameof(expectation));
      if (result is null) throw new ArgumentNullException(nameof(result));

      return expectation.Expect(result);
    }

    /// <summary>
    ///   <para>Expects that a given <paramref name="expectation"/> has a subject instance which is not a <see langword="null"/>.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="expectation"/> is <see langword="null"/>.</exception>
    public IExpectation<T> HaveSubject()
    {
      if (expectation is null) throw new ArgumentNullException(nameof(expectation));

      return expectation.Expected(subject =>
      {
        if (subject is null)
        {
          throw new ArgumentNullException(nameof(subject));
        }

        return true;
      });
    }

    /// <summary>
    ///   <para>Checks whether a specified <paramref name="expectation"/> is proven to be <see langword="false"/> and throws a specified <paramref name="exception"/> if it is.</para>
    /// </summary>
    /// <param name="exception">Exception to be thrown in case of a failed expectation.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="expectation"/> or <paramref name="exception"/> is <see langword="null"/>.</exception>
    /// <seealso cref="ThrowIfFalse{T}(IExpectation{T}, string)"/>
    public IExpectation<T> ThrowIfFalse(Exception exception)
    {
      if (expectation is null) throw new ArgumentNullException(nameof(expectation));
      if (exception is null) throw new ArgumentNullException(nameof(exception));

      if (!expectation.Result)
      {
        throw exception;
      }

      return expectation;
    }

    /// <summary>
    ///   <para>Checks whether a specified <paramref name="expectation"/> is proven to be <see langword="false"/> and throws <see cref="InvalidOperationException"/> if it is.</para>
    /// </summary>
    /// <param name="error">Text message of a potentially thrown exception.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="ThrowIfFalse{T}(IExpectation{T}, Exception)"/>
    public IExpectation<T> ThrowIfFalse(string error = null) => expectation.ThrowIfFalse(new InvalidOperationException(error));

    /// <summary>
    ///   <para>Checks whether a specified object is a <see langword="null"/> and throws <see cref="ArgumentNullException"/> if it is.</para>
    /// </summary>
    /// <param name="instance">Object to check for a <see langword="null"/> value.</param>
    /// <param name="error">Text message of a potentially thrown exception.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="expectation"/> or <paramref name="instance"/> is <see langword="null"/>.</exception>
    public IExpectation<T> ThrowIfNull(object instance, string error = null)
    {
      if (expectation is null) throw new ArgumentNullException(nameof(expectation));
      if (instance is null) throw new ArgumentNullException(error ?? nameof(instance));

      return expectation;
    }

    /// <summary>
    ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    public IExpectation<T> To() => expectation;

    /// <summary>
    ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    public IExpectation<T> And() => expectation;

    /// <summary>
    ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    public IExpectation<T> Be() => expectation;

    /// <summary>
    ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    public IExpectation<T> Having() => expectation;

    /// <summary>
    ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    public IExpectation<T> With() => expectation;

    /// <summary>
    ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    public IExpectation<T> Of() => expectation;

    /// <summary>
    ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    public IExpectation<T> At() => expectation;

    /// <summary>
    ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    public IExpectation<T> On() => expectation;
  }
}