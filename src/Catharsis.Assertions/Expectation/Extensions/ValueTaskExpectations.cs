namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="ValueTask"/> type.</para>
/// </summary>
/// <seealso cref="ValueTask"/>
/// <seealso cref="ValueTask{TResult}"/>
public static class ValueTaskExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<ValueTask> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="ValueTask"/> was completed successfully.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Successful{T}(IExpectation{ValueTask{T}})"/>
    public IExpectation<ValueTask> Successful() => expectation.Expected(task => task.IsCompletedSuccessfully);

    /// <summary>
    ///   <para>Expects that the given <see cref="ValueTask"/> was completed unsuccessfully due to an unhandled exception.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Unsuccessful{T}(IExpectation{ValueTask{T}})"/>
    public IExpectation<ValueTask> Unsuccessful() => expectation.Expected(task => task.IsFaulted);

    /// <summary>
    ///   <para>Expects that the given <see cref="ValueTask"/> was completed unsuccessfully due to being cancelled.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Canceled{T}(IExpectation{ValueTask{T}})"/>
    public IExpectation<ValueTask> Canceled() => expectation.Expected(task => task.IsCanceled);

    /// <summary>
    ///   <para>Expects that the given <see cref="ValueTask"/> was completed regardless of how.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Completed{T}(IExpectation{ValueTask{T}})"/>
    public IExpectation<ValueTask> Completed() => expectation.Expected(task => task.IsCompleted);
  }

  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <typeparam name="T">Type of task result.</typeparam>
  extension<T>(IExpectation<ValueTask<T>> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="ValueTask{T}"/> was completed successfully.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Successful(IExpectation{ValueTask})"/>
    public IExpectation<ValueTask<T>> Successful() => expectation.Expected(task => task.IsCompletedSuccessfully);

    /// <summary>
    ///   <para>Expects that the given <see cref="ValueTask{T}"/> was completed unsuccessfully due to an unhandled exception.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Unsuccessful(IExpectation{ValueTask})"/>
    public IExpectation<ValueTask<T>> Unsuccessful() => expectation.Expected(task => task.IsFaulted);

    /// <summary>
    ///   <para>Expects that the given <see cref="ValueTask{T}"/> was completed unsuccessfully due to being cancelled.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Canceled(IExpectation{ValueTask})"/>
    public IExpectation<ValueTask<T>> Canceled() => expectation.Expected(task => task.IsCanceled);

    /// <summary>
    ///   <para>Expects that the given <see cref="ValueTask{T}"/> was completed regardless of how.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    /// <seealso cref="Completed(IExpectation{ValueTask})"/>
    public IExpectation<ValueTask<T>> Completed() => expectation.Expected(task => task.IsCompleted);
  }
}