﻿namespace Formulate.Core.FormHandlers
{
    // Namespaces.
    using System;

    /// <summary>
    /// The base class for all form handler definitions.
    /// </summary>
    /// <remarks>
    /// Do not implement this definition directly.
    /// Instead implement <see cref="FormHandlerDefinition"/> or
    /// <see cref="AsyncFormHandlerDefinition"/>.
    /// </remarks>
    public abstract class FormHandlerDefinitionBase : IFormHandlerDefinition
    {
        /// <inheritdoc />
        public abstract Guid KindId { get; }

        /// <inheritdoc />
        public abstract string DefinitionLabel { get; }

        /// <inheritdoc />
        public abstract string Directive { get; }

        /// <inheritdoc />
        public abstract string Icon { get; }
    }
}