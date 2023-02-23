namespace Catharsis.Assertions;

/// <summary>
///   <para>A custom boolean assertion that can either be valid or invalid.</para>
/// </summary>
public interface IAssertion
{
  /// <summary>
  ///   <para>Expects a specified assertion result.</para>
  /// </summary>
  /// <param name="result">Expected assertion result.</param>
  /// <returns>Returns <see langword="true"/> if current assertion evaluates to a specified boolean result and <see langword="false"/> if it does not.</returns>
  bool Valid(bool result);

  /// <summary>
  ///   <para>Expects a specified assertion result.</para>
  /// </summary>
  /// <param name="result">Expected assertion result.</param>
  /// <returns>Returns <see langword="false"/> if current assertion evaluates to a specified boolean result and <see langword="true"/> if it does not.</returns>
  bool Invalid(bool result);
}