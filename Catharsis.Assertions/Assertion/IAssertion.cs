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
  bool Valid(bool result);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="result"></param>
  /// <returns></returns>
  bool Invalid(bool result);
}