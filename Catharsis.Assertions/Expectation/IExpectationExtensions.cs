namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of extension methods for <see cref="IExpectation{T}"/> interface.</para>
/// </summary>
/// <seealso cref="IExpectation{T}"/>
public static class IExpectationExtensions
{
  /// <summary>
  ///   <para>Expects a specified result, expressed as a predicate.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="result">Expected result.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> Expected<T>(this IExpectation<T> expectation, Predicate<T> result)
  {
    if (expectation is null) throw new ArgumentNullException(nameof(expectation));
    if (result is null) throw new ArgumentNullException(nameof(result));

    return expectation.Expect(result);
  }

  /// <summary>
  ///   <para>Expects that a given <paramref name="expectation"/> has a subject instance which is not a <see langword="null"/> reference.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> HaveSubject<T>(this IExpectation<T> expectation)
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
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="exception">Exception to be thrown in case of a failed expectation.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="ThrowIfFalse{T}(IExpectation{T}, string)"/>
  public static IExpectation<T> ThrowIfFalse<T>(this IExpectation<T> expectation, Exception exception)
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
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="error">Text message of a potentially thrown exception.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="ThrowIfFalse{T}(IExpectation{T}, Exception)"/>
  public static IExpectation<T> ThrowIfFalse<T>(this IExpectation<T> expectation, string error = null) => expectation.ThrowIfFalse(new InvalidOperationException(error));

  /// <summary>
  ///   <para>Checks whether a specified object is a <see langword="null"/> reference and throws <see cref="ArgumentNullException"/> if it is.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="instance">Object to check for a <see langword="null"/> value.</param>
  /// <param name="error">Text message of a potentially thrown exception.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> ThrowIfNull<T>(this IExpectation<T> expectation, object instance, string error = null)
  {
    if (expectation is null) throw new ArgumentNullException(nameof(expectation));
    if (instance is null) throw new ArgumentNullException(error ?? nameof(instance));

    return expectation;
  }

  /// <summary>
  ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  public static IExpectation<T> To<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  public static IExpectation<T> And<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  public static IExpectation<T> Be<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  public static IExpectation<T> Having<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  public static IExpectation<T> With<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  public static IExpectation<T> Of<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  public static IExpectation<T> At<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para>Helper method for building lexically diverse expectation sentences that returns a back reference to a given expectation.</para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject instance.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  public static IExpectation<T> On<T>(this IExpectation<T> expectation) => expectation;
}