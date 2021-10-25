﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formulate.Core.FormFields;
using Xunit;

namespace Formulate.Core.Tests.FormFieldTests
{
    public partial class FormFieldFactoryTests
    {
        [Fact(DisplayName = "When no settings provided should throw an Argument Null Exception")]
        public void WhenNoSettingsProvidedShouldThrowArgumentNullException()
        {
            // arrange
            var factory = CreateFactory();
            TestFormFieldSettings settings = default;

            // act / asset
            Assert.Throws<ArgumentNullException>(() => factory.CreateField(settings));
        }

        [Fact(DisplayName = "When no DefinitionId matches should return Default")]
        public void WhenNoDefinitionIdMatchesShouldReturnDefault()
        {
            // arrange
            var factory = CreateFactory();
            var settings = new TestFormFieldSettings()
            {
                DefinitionId = Guid.Parse(Constants.MissingFormFieldDefinitionId)
            };

            // act
            var formField = factory.CreateField(settings);

            // assert
            Assert.Equal(default, formField);
        }

        [Fact(DisplayName = "When DefinitionId matches a Form Field Definition should return an expected Form Field")]
        public void WhenDefinitionIdMatchesAFormFieldDefinitionShouldReturnAnExpectedFormField()
        {
            // arrange
            var factory = CreateFactory();
            var settings = new TestFormFieldSettings()
            {
                DefinitionId = Guid.Parse(Constants.TestFormFieldDefinitionId)
            };

            // act
            var formField = factory.CreateField(settings);

            // assert
            Assert.IsType<TestFormField>(formField);
            Assert.NotEqual(default, formField);
        }

        private static IFormFieldFactory CreateFactory()
        {
            var items = new List<IFormFieldDefinition>()
            {
                new TestFormFieldDefinition()
            };

            var collection = new FormFieldDefinitionCollection(() => items);
            
            return new FormFieldFactory(collection);
        }
    }
}
