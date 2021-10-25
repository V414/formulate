﻿using System;

namespace Formulate.Core.Layouts.Basic
{
    /// <summary>
    /// A layout type for creating <see cref="BasicLayout"/>.
    /// </summary>
    public sealed class BasicLayoutType : ILayoutType
    {
        /// <summary>
        /// Constants related to <see cref="BasicLayoutType"/>.
        /// </summary>
        public static class Constants
        {
            /// <summary>
            /// The type ID.
            /// </summary>
            public const string TypeId = "B03310E9320744DCBE96BE0CF4F26C59";

            /// <summary>
            /// The type label.
            /// </summary>
            public const string TypeLabel = "Basic Layout";

            /// <summary>
            /// The Angular JS directive.
            /// </summary>
            public const string Directive = "formulate-layout-basic";
        }

        /// <inheritdoc />
        public Guid TypeId => Guid.Parse(Constants.TypeId);

        /// <inheritdoc />
        public string TypeLabel => Constants.TypeLabel;

        /// <inheritdoc />
        public string Directive => Constants.Directive;

        /// <inheritdoc />
        public ILayout CreateLayout(ILayoutSettings settings)
        {
            var config = new BasicLayoutConfiguration();

            return new BasicLayout(settings, config);
        }
    }
}
