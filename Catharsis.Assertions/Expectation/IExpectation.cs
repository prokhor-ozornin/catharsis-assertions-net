namespace Catharsis.Assertions;

/// <summary>
///   <para>A custom expectation for a target subject.</para>
/// </summary>
/// <typeparam name="T">Type of subject.</typeparam>
public interface IExpectation<out T>
{
  /// <summary>
  ///   <para>Boolean result of expectation, whether is has proven to be <see langword="true"/> or <see langword="false"/>.</para>
  /// </summary>
  bool Result { get; }

  /// <summary>
  ///   <para>Negates current expectation, reversing its boolean result.</para>
  /// </summary>
  /// <returns></returns>
  IExpectation<T> Not();

  /// <summary>
  ///   <para>Expects a specified result, expressed as a predicate.</para>
  /// </summary>
  /// <param name="result">Expected result.</param>
  /// <returns>Back reference to the current expectation.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="result"/> is a <see langword="null"/> reference.</exception>
  IExpectation<T> Expect(Predicate<T> result);
}