﻿using Formulate.Core.Types;
using Umbraco.Cms.Core.Composing;

namespace Formulate.Core.FormHandlers
{
    /// <summary>
    /// A contract for implementing form handler type.
    /// </summary>
    /// <remarks>Do not implement this type directly. Instead implement <see cref="FormHandlerType"/> or <see cref="AsyncFormHandlerType"/>.</remarks>
    public interface IFormHandlerType : IType, IDiscoverable
    {
    }
}
