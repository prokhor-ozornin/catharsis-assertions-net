namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public interface IAssertion
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="result"></param>
  /// <returns></returns>
  bool Confirmed(bool result);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="result"></param>
  /// <returns></returns>
  bool Unconfirmed(bool result);
}