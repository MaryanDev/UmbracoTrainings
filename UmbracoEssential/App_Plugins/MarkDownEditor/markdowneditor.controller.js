angular.module("umbraco")
    .controller("My.MarkdownEditorController",
        function ($scope, assetsService, $timeout, editorService) {
            if ($scope.model.value === null || $scope.model.value === "") {
                $scope.model.value = $scope.model.config.defaultValue;
            }

            assetsService.load([
                "~/App_Plugins/MarkDownEditor/lib/Markdown.Converter.js",
                "~/App_Plugins/MarkDownEditor/lib/Markdown.Sanitizer.js",
                "~/App_Plugins/MarkDownEditor/lib/Markdown.Editor.js"
            ]).then(function () {
                // this function will execute when all dependencies have loaded
                $timeout(function () {
                    var converter2 = new Markdown.Converter();
                    var editor2 = new Markdown.Editor(converter2, "-" + $scope.model.alias);
                    editor2.run();

                    editor2.hooks.set("insertImageDialog", function (callback) {
                        // here we can intercept our own dialog handling
                        var mediaPicker = {
                            disableFolderSelect: true,
                            submit: function (model) {
                                var selectedImagePath = model.selection[0].image;
                                callback(selectedImagePath);
                                editorService.close();
                            },
                            close: function () {
                                editorService.close();
                            }
                        };
                        editorService.mediaPicker(mediaPicker);
                        console.log("editorService ", editorService);

                        return true; // tell the editor that we'll take care of getting the image url
                    });
                });
            });

            assetsService.loadCss("~/App_Plugins/MarkDownEditor/lib/Markdown.Editor.less");
        });

