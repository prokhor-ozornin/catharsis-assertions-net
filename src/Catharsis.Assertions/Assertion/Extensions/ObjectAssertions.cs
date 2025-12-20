namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="object"/> type.</para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectAssertions
{
  /// <param name="assertion">Assertion to validate.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="object"/> of a specific type is the same as the specified object.</para>
    /// </summary>
    /// <typeparam name="T">The type of object.</typeparam>
    /// <param name="instance">Object to inspect.</param>
    /// <param name="other">Asserted object for reference equality comparison.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Same<T>(T instance, object other, string error = null) => assertion.True(ReferenceEquals(instance, other), error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="object"/> is considered equal to the specified object.</para>
    /// </summary>
    /// <typeparam name="T">The type of object.</typeparam>
    /// <param name="instance">Object to inspect.</param>
    /// <param name="other">Asserted object for equality comparison.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Equal<T>(T instance, object other, string error = null) => assertion.True(Equals(instance, other), error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="object"/> is equal to the default value for its <see cref="Type"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of object.</typeparam>
    /// <param name="instance">Object to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Default<T>(T instance, string error = null) => assertion.Equal(instance, default(T), error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="object"/> is of the specified <see cref="Type"/>.</para>
    /// </summary>
    /// <param name="instance">Object to inspect.</param>
    /// <param name="type">Asserted object type.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="instance"/>, or <paramref name="type"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion OfType(object instance, Type type, string error = null)
    {
      if (assertion is null) throw new ArgumentNullException(nameof(assertion));
      if (instance is null) throw new ArgumentNullException(nameof(instance));
      if (type is null) throw new ArgumentNullException(nameof(type));

      return assertion.True(instance.GetType() == type, error);
    }

    /// <summary>
    ///   <para>Asserts that the given <see cref="object"/> is of the specified <see cref="Type"/>.</para>
    /// </summary>
    /// <typeparam name="T">Asserted type of object.</typeparam>
    /// <param name="instance">Object to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="instance"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion OfType<T>(object instance, string error = null) => assertion.OfType(instance, typeof(T), error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="object"/> is <see langword="null"/>.</para>
    /// </summary>
    /// <typeparam name="T">The type of object.</typeparam>
    /// <param name="instance">Object to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Null<T>(T instance, string error = null) => assertion.True(instance is null, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="object"/> is equal to at least one element in the specified sequence.</para>
    /// </summary>
    /// <typeparam name="T">The type of object.</typeparam>
    /// <param name="value">Object to inspect.</param>
    /// <param name="sequence">Asserted sequence of possible values for an object.</param>
    /// <param name="comparer">Comparer for equality.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="sequence"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion OneOf<T>(T value, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null, string error = null) => assertion.Contain(sequence, value, comparer, error);
  }
}