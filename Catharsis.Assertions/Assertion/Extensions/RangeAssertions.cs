namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class RangeAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="range"></param>
  /// <param name="index"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion StartIndex(this IAssertion assertion, Range range, int index, string message = null) => assertion.True(range.Start.Value == index, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="range"></param>
  /// <param name="index"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion EndIndex(this IAssertion assertion, Range range, int index, string message = null) => assertion.True(range.End.Value == index, message);
}