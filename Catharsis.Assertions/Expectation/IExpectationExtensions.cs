namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class IExpectationExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> To<T>(this IExpectation<T> expectation) => expectation ?? throw new ArgumentNullException(nameof(expectation));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> HaveSubject<T>(this IExpectation<T> expectation)
  {
    if (expectation is null) throw new ArgumentNullException(nameof(expectation));

    return expectation.Expect(subject =>
    {
      if (subject is null)
      {
        throw new ArgumentNullException(nameof(subject));
      }

      return true;
    });
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="exception"></param>
  /// <returns></returns>
  public static IExpectation<T> ThrowIfFalse<T>(this IExpectation<T> expectation, Exception exception)
  {
    if (!expectation.Result)
    {
      throw exception;
    }

    return expectation;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IExpectation<T> ThrowIfFalse<T>(this IExpectation<T> expectation, string message = null) => expectation.ThrowIfFalse(new InvalidOperationException(message));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="instance"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<T> ThrowIfNull<T>(this IExpectation<T> expectation, object instance, string message = null)
  {
    if (expectation is null) throw new ArgumentNullException(nameof(expectation));
    if (instance is null) throw new ArgumentNullException(message ?? nameof(instance));

    return expectation;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> And<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> Be<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> Having<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> With<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> Of<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///    <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> At<T>(this IExpectation<T> expectation) => expectation;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<T> On<T>(this IExpectation<T> expectation) => expectation;
}