namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="Type"/> type.</para>
/// </summary>
/// <seealso cref="Type"/>
public static class TypeAssertions
{
  /// <param name="assertion">Assertion to validate.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="Type"/> is declared as <see langword="abstract"/>.</para>
    /// </summary>
    /// <param name="type">Type to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Abstract(Type type, string error = null) => type is not null ? assertion.True(type.IsAbstract && !type.IsSealed, error) : throw new ArgumentNullException(nameof(type));

    /// <summary>
    ///   <para>Asserts that the given <see cref="Type"/> is declared as <see langword="sealed"/>.</para>
    /// </summary>
    /// <param name="type">Type to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Sealed(Type type, string error = null) => type is not null ? assertion.True(type.IsSealed && !type.IsAbstract, error) : throw new ArgumentNullException(nameof(type));

    /// <summary>
    ///   <para>Asserts that the given <see cref="Type"/> is declared as <see langword="static"/>.</para>
    /// </summary>
    /// <param name="type">Type to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Static(Type type, string error = null) => type is not null ? assertion.True(type.IsAbstract && type.IsSealed, error) : throw new ArgumentNullException(nameof(type));

    /// <summary>
    ///   <para>Asserts that the given <see cref="Type"/> is of <see langword="public"/> visibility.</para>
    /// </summary>
    /// <param name="type">Type to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Public(Type type, string error = null) => type is not null ? assertion.True(type.IsPublic && type.IsVisible, error) : throw new ArgumentNullException(nameof(type));

    /// <summary>
    ///   <para>Asserts that the given <see cref="Type"/> is of <see langword="internal"/> visibility.</para>
    /// </summary>
    /// <param name="type">Type to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Internal(Type type, string error = null) => type is not null ? assertion.True(type.IsNotPublic && !type.IsVisible, error) : throw new ArgumentNullException(nameof(type));

    /// <summary>
    ///   <para>Asserts that the given <see cref="Type"/> is derived from a specified <see cref="Type"/>.</para>
    /// </summary>
    /// <param name="subclass">Asserted subclass type.</param>
    /// <param name="superclass">Asserted superclass type.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="subclass"/>, or <paramref name="superclass"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Subclass(Type subclass, Type superclass, string error = null)
    {
      if (assertion is null) throw new ArgumentNullException(nameof(assertion));
      if (subclass is null) throw new ArgumentNullException(nameof(subclass));
      if (superclass is null) throw new ArgumentNullException(nameof(superclass));

      return assertion.True(subclass.IsSubclassOf(superclass), error);
    }

    /// <summary>
    ///   <para>Asserts that the given <see cref="Type"/> is derived from a specified <see cref="Type"/>.</para>
    /// </summary>
    /// <typeparam name="T">Asserted superclass type.</typeparam>
    /// <param name="subclass">Asserted subclass type.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="subclass"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Subclass<T>(Type subclass, string error = null) => assertion.Subclass(subclass, typeof(T), error);

    /// <summary>
    ///   <para>Asserts that an instance of a given <see cref="Type"/> is assignable from an instance of another specified <see cref="Type"/>.</para>
    /// </summary>
    /// <param name="to">Asserted target type.</param>
    /// <param name="from">Asserted source type.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="to"/>, or <paramref name="from"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    /// <seealso cref="AssignableFrom{T}(IAssertion, Type, string)"/>
    public IAssertion AssignableFrom(Type to, Type from, string error = null)
    {
      if (assertion is null) throw new ArgumentNullException(nameof(assertion));
      if (to is null) throw new ArgumentNullException(nameof(to));
      if (from is null) throw new ArgumentNullException(nameof(from));
    
      return assertion.True(to.IsAssignableFrom(from), error);
    }

    /// <summary>
    ///   <para>Asserts that an instance of a given <see cref="Type"/> is assignable from an instance of another specified <see cref="Type"/>.</para>
    /// </summary>
    /// <typeparam name="T">Asserted target type.</typeparam>
    /// <param name="from">Asserted source type.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="from"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    /// <seealso cref="AssignableFrom(IAssertion, Type, Type, string)"/>
    public IAssertion AssignableFrom<T>(Type from, string error = null) => assertion.AssignableFrom(from, typeof(T), error);

    #if NET10_0_OR_GREATER
    /// <summary>
    ///   <para>Asserts that an instance of a given <see cref="Type"/> is assignable to an instance of the specified <see cref="Type"/>.</para>
    /// </summary>
    /// <param name="from">Asserted source type.</param>
    /// <param name="to">Asserted target type.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="from"/>, or <paramref name="to"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    /// <seealso cref="AssignableTo{T}(IAssertion, Type, string)"/>
    public IAssertion AssignableTo(Type from, Type to, string error = null)
    {
      if (assertion is null) throw new ArgumentNullException(nameof(assertion));
      if (from is null) throw new ArgumentNullException(nameof(from));
      if (to is null) throw new ArgumentNullException(nameof(to));

      return assertion.True(from.IsAssignableTo(to), error);
    }

    /// <summary>
    ///   <para>Asserts that an instance of a given <see cref="Type"/> is assignable to an instance of the specified <see cref="Type"/>.</para>
    /// </summary>
    /// <typeparam name="T">Asserted target type.</typeparam>
    /// <param name="from">Asserted source type.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="from"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    /// <seealso cref="AssignableTo(IAssertion, Type, Type, string)"/>
    public IAssertion AssignableTo<T>(Type from, string error = null) => assertion.AssignableTo(from, typeof(T), error);
    #endif
  }
}