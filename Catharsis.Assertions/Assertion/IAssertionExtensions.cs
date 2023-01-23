namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class IAssertionExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <returns></returns>
  public static IAssertion And(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <returns></returns>
  public static IAssertion Be(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <returns></returns>
  public static IAssertion Having(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <returns></returns>
  public static IAssertion With(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <returns></returns>
  public static IAssertion Of(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <returns></returns>
  public static IAssertion At(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <returns></returns>
  public static IAssertion On(this IAssertion assertion) => assertion;
}