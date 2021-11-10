﻿(function () {
    function formulateConfigurationEditorDirective($compile) {
        var directive = {
            templateUrl: "/app_plugins/formulatebackoffice/directives/editors/configuration.editor.html",
            replace: true,
            scope: {
                directive: "=",
                config: "="
            },
            link: function(scope, element) {
                if (typeof (scope.directive) === "undefined" || scope.directive.length === 0) {
                    console.error("No directive provided.");
                    return;
                }

                if (scope.directive === "formulate-configuration-editor") {
                    console.error("Operation would cause an infinite loop.");
                    return;
                }

                // Create directive.
                var markup = "<" + scope.directive + " data=\"config\"></" + scope.directive + ">";
                var directive = $compile(markup)(scope);
                element.replaceWith(directive);
            }
        };

        return directive;
    }

    angular.module("umbraco.directives").directive("formulateConfigurationEditor", formulateConfigurationEditorDirective);
})();