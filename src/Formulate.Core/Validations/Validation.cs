﻿using System;

namespace Formulate.Core.Validations
{
    /// <summary>
    /// The extended base class for validations with a configuration.
    /// </summary>
    /// <typeparam name="TConfig">The type of the validation configuration.</typeparam>
    public abstract class Validation<TConfig> : Validation
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public TConfig Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Validation"/> class.
        /// </summary>
        /// <param name="settings">The validation settings.</param>
        /// <param name="configuration">The validation configuration.</param>
        /// <exception cref="ArgumentNullException">The settings parameter is null.</exception>
        protected Validation(IValidationSettings settings, TConfig configuration) : base(settings)
        {
            Configuration = configuration;
        }
    }

    /// <summary>
    /// The base class for all validations.
    /// </summary>
    public abstract class Validation : IValidation
    {
        /// <inheritdoc />
        public Guid Id { get; }

        /// <inheritdoc />
        public Guid TypeId { get; }

        /// <summary>
        /// The raw configuration.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is for reference only.
        /// </para>
        /// <para>
        /// Deserialization should typically happen in the overridden <see cref="IValidationType"/> CreateValidation method.
        /// </para>
        /// </remarks>
        protected readonly string RawConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validation"/> class.
        /// </summary>
        /// <param name="settings">The validation settings.</param>
        /// <exception cref="ArgumentNullException">The settings parameter is null.</exception>
        protected Validation(IValidationSettings settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Id = settings.Id;
            TypeId = settings.TypeId;
            RawConfiguration = settings.Configuration;
        }
    }
}
