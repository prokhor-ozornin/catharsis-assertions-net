namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IExpectation<out T>
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  bool Result { get; }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <returns></returns>
  IExpectation<T> Not();

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="predicate"></param>
  /// <returns></returns>
  IExpectation<T> Expect(Predicate<T> predicate);
}