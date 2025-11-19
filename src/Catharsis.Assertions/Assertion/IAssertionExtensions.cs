namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of extension methods for <see cref="IAssertion"/> interface.</para>
/// </summary>
/// <seealso cref="IAssertion"/>
public static class IAssertionExtensions
{
  /// <param name="assertion">Assertion object.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    public IAssertion And() => assertion;

    /// <summary>
    ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    public IAssertion Be() => assertion;

    /// <summary>
    ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    public IAssertion Having() => assertion;

    /// <summary>
    ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    public IAssertion With() => assertion;

    /// <summary>
    ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    public IAssertion Of() => assertion;

    /// <summary>
    ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    public IAssertion At() => assertion;

    /// <summary>
    ///   <para>Helper method for building lexically diverse assertion sentences that returns a back reference to a given assertion.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    public IAssertion On() => assertion;
  }
}