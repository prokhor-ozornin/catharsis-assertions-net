namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of extension methods for <see cref="IAssertion"/> interface.</para>
/// </summary>
/// <seealso cref="IAssertion"/>
public static class IAssertionExtensions
{
  /// <summary>
  ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
  /// </summary>
  /// <param name="assertion">Assertion object.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  public static IAssertion And(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
  /// </summary>
  /// <param name="assertion">Assertion object.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  public static IAssertion Be(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
  /// </summary>
  /// <param name="assertion">Assertion object.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  public static IAssertion Having(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
  /// </summary>
  /// <param name="assertion">Assertion object.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  public static IAssertion With(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
  /// </summary>
  /// <param name="assertion">Assertion object.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  public static IAssertion Of(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
  /// </summary>
  /// <param name="assertion">Assertion object.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  public static IAssertion At(this IAssertion assertion) => assertion;

  /// <summary>
  ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
  /// </summary>
  /// <param name="assertion">Assertion object.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  public static IAssertion On(this IAssertion assertion) => assertion;
}