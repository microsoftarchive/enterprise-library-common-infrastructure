// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Resources;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    /// <summary>
    /// Represents a localized <see cref="CategoryAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class ResourceCategoryAttribute : CategoryAttribute
    {
        private readonly Type resourceType;
        private static ResourceCategoryAttribute general;

        static ResourceCategoryAttribute()
        {
            general = new ResourceCategoryAttribute(typeof(ResourceCategoryAttribute), "CategoryGeneral");
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="SRCategoryAttribute"/> class with the <see cref="Type"/> containing the resources and the resource name.
        /// </summary>
        /// <param name="category">The resources string name.</param>
        /// <param name="resourceType">The <see cref="Type"/> containing the resource strings.</param>
        public ResourceCategoryAttribute(Type resourceType, string category)
            : base(category)
        {
            this.resourceType = resourceType;
        }

        /// <summary>
        /// Gets the type that contains the resources.
        /// </summary>
        /// <value>
        /// The type that contains the resources.
        /// </value>
        public Type ResourceType
        {
            get { return resourceType; }
        }

        /// <summary>
        /// Gets the localized string based on the key.
        /// </summary>
        /// <param name="value">The key to the string resources.</param>
        /// <returns>The localized string.</returns>
        protected override string GetLocalizedString(string value)
        {
            return ResourceStringLoader.LoadString(resourceType.FullName, value, resourceType.Assembly);
        }

        /// <summary>
        /// Returns a localized <see cref="ResourceCategoryAttribute"/> for the General category.
        /// </summary>
        public static ResourceCategoryAttribute General
        {
            get { return general; }
        }

    }
}
