﻿using Formulate.BackOffice.Attributes;
using Formulate.BackOffice.Persistence;
using Formulate.Core.ConfiguredForms;
using Formulate.Core.Folders;
using Formulate.Core.Forms;
using Formulate.Core.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Actions;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;

namespace Formulate.BackOffice.Trees
{
    /// <summary>
    /// The Formulate forms tree controller.
    /// </summary>
    [Tree(FormulateSection.Constants.Alias, "forms", TreeTitle = "Forms", SortOrder = 0)]
    [FormulateBackOfficePluginController]
    public sealed class FormulateFormsTreeController : FormulateTreeController
    {
        public static class Constants
        {
            public const string RootNodeIcon = "icon-formulate-forms";

            public const string FolderNodeIcon = "icon-formulate-form-group";

            public const string FormNodeIcon = "icon-formulate-form";

            public const string ConfiguredFormNodeIcon = "icon-formulate-conform";
        }

        /// <inheritdoc />
        protected override TreeRootTypes TreeRootType => TreeRootTypes.Forms;

        /// <inheritdoc />
        protected override string RootNodeIcon => Constants.RootNodeIcon;

        /// <inheritdoc />
        protected override string FolderNodeIcon => Constants.FolderNodeIcon;

        /// <inheritdoc />
        protected override string ItemNodeIcon => Constants.FormNodeIcon;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormulateFormsTreeController"/> class.
        /// </summary>
        /// <inheritdoc />
        public FormulateFormsTreeController(ITreeEntityRepository treeEntityRepository, IMenuItemCollectionFactory menuItemCollectionFactory, ILocalizedTextService localizedTextService, UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection, IEventAggregator eventAggregator) : base(treeEntityRepository, menuItemCollectionFactory, localizedTextService, umbracoApiControllerTypeCollection, eventAggregator)
        {
        }

        /// <inheritdoc />
        protected override string GetNodeIcon(IPersistedEntity entity)
        {
            if (entity is PersistedConfiguredForm)
            {
                return Constants.ConfiguredFormNodeIcon;
            }

            return base.GetNodeIcon(entity);
        }

        /// <inheritdoc />
        protected override ActionResult<MenuItemCollection> GetMenuForRoot(FormCollection queryStrings)
        {
            var menuItemCollection = MenuItemCollectionFactory.Create();

            //menuItemCollection.AddCreateFormMenuItem(default, LocalizedTextService);
            //menuItemCollection.AddCreateFolderMenuItem(LocalizedTextService);
            menuItemCollection.DefaultMenuAlias = ActionNew.ActionAlias;

            menuItemCollection.AddCreateDialogMenuItem(LocalizedTextService);
            menuItemCollection.AddRefreshMenuItem(LocalizedTextService);

            return menuItemCollection;
        }

        /// <inheritdoc />
        protected override ActionResult<MenuItemCollection> GetMenuForEntity(IPersistedEntity entity, FormCollection queryStrings)
        {
            var menuItemCollection = MenuItemCollectionFactory.Create();

            if (entity is PersistedConfiguredForm)
            {
                menuItemCollection.AddDeleteConfiguredFormMenuItem(LocalizedTextService);
            }
            else
            {
                menuItemCollection.DefaultMenuAlias = ActionNew.ActionAlias;

                menuItemCollection.AddCreateDialogMenuItem(LocalizedTextService);
                menuItemCollection.AddRefreshMenuItem(LocalizedTextService);
            }

            if (entity is PersistedFolder folder)
            {
                menuItemCollection.AddMoveFolderMenuItem(folder, LocalizedTextService);
                menuItemCollection.AddDeleteFolderMenuItem(LocalizedTextService);
            }

            if (entity is PersistedForm form)
            {
                menuItemCollection.AddMoveFormMenuItem(form, LocalizedTextService);
                menuItemCollection.AddDeleteFormMenuItem(LocalizedTextService);
            }

            return menuItemCollection;
        }
    }
}
