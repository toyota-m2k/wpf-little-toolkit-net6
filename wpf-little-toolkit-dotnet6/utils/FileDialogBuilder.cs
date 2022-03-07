using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace io.github.toyota32k.dotnet6.toolkit.utils {
    public abstract class FileDialogBuilder<TBuilderClass> where TBuilderClass : class {
        protected CommonFileDialog BuildingDialog;
        protected FileDialogBuilder(CommonFileDialog dlg) {
            BuildingDialog = dlg;
        }
        public TBuilderClass title(string title) {
            BuildingDialog.Title = title;
            return (this as TBuilderClass)!;
        }
        /**
         * "txt" など（.なし）
         */
        public TBuilderClass defaultExtension(string ext) {
            BuildingDialog.DefaultExtension = ext;
            return (this as TBuilderClass)!;
        }
        public TBuilderClass defaultFilename(string ext) {
            BuildingDialog.DefaultFileName = ext;
            return (this as TBuilderClass)!;
        }
        public TBuilderClass initialDirectory(string path) {
            BuildingDialog.InitialDirectory = path;
            return (this as TBuilderClass)!;
        }
        public TBuilderClass addFileType(string label, string wildcards) {
            BuildingDialog.Filters.Add(new CommonFileDialogFilter(label, wildcards));
            return (this as TBuilderClass)!;
        }
        public TBuilderClass addFileTypes(IEnumerable<(string label, string wildcards)> types) {
            foreach (var type in types) {
                BuildingDialog.Filters.Add(new CommonFileDialogFilter(type.label, type.wildcards));
            }
            return (this as TBuilderClass)!;
        }
        public TBuilderClass ensureFileExists(bool exists = true) {
            BuildingDialog.EnsureFileExists = exists;
            return (this as TBuilderClass)!;
        }

        public string? GetFilePath(Window owner) {
            using (BuildingDialog) {
                var r = BuildingDialog.ShowDialog(owner);
                if (r == CommonFileDialogResult.Ok) {
                    return BuildingDialog.FileName;
                }
                return null;
            }
        }
    }
    
    public class OpenFileDialogBuilder : FileDialogBuilder<OpenFileDialogBuilder> {
        private CommonOpenFileDialog Dialog => (BuildingDialog as CommonOpenFileDialog)!;

        public OpenFileDialogBuilder() : base(new CommonOpenFileDialog()) {
            Dialog.Multiselect = false;
            Dialog.RestoreDirectory = true;
        }
        public OpenFileDialogBuilder multiSelection(bool multi = true) {
            Dialog.Multiselect = multi;
            return this;
        }
        public OpenFileDialogBuilder directorySelection(bool dir = true) {
            Dialog.IsFolderPicker = dir;
            return this;
        }

        public OpenFileDialogBuilder customize(Action<CommonOpenFileDialog> custom) {
            custom(Dialog);
            return this;
        }

        public IEnumerable<string>? GetFilePaths(Window owner) {
            using (Dialog) {
                Dialog.Multiselect = true;
                var r = Dialog.ShowDialog(owner);
                if (r == CommonFileDialogResult.Ok) {
                    return Dialog.FileNames;
                }
                return null;
            }
        }
        public static OpenFileDialogBuilder Create() {
            return new OpenFileDialogBuilder();
        }
    }

    public class FolderDialogBuilder : FileDialogBuilder<FolderDialogBuilder> {
        private CommonOpenFileDialog Dialog => (BuildingDialog as CommonOpenFileDialog)!;
        public FolderDialogBuilder() : base(new CommonOpenFileDialog()) {
            Dialog.Multiselect = false;
            Dialog.RestoreDirectory = true;
            Dialog.IsFolderPicker = true;
        }
        public FolderDialogBuilder customize(Action<CommonOpenFileDialog> custom) {
            custom(Dialog);
            return this;
        }
        public static FolderDialogBuilder Create() {
            return new FolderDialogBuilder();
        }
    }

    public class SaveFileDialogBuilder : FileDialogBuilder<SaveFileDialogBuilder> {
        private CommonSaveFileDialog Dialog => (BuildingDialog as CommonSaveFileDialog)!;
        public SaveFileDialogBuilder() : base(new CommonSaveFileDialog()) {
        }

        public SaveFileDialogBuilder overwritePrompt(bool prompt=true) {
            Dialog.OverwritePrompt = prompt;
            return this;
        }
        public SaveFileDialogBuilder createPrompt(bool prompt = true) {
            Dialog.CreatePrompt = prompt;
            return this;
        }
        public SaveFileDialogBuilder showFolders(bool expandMode = true) {
            Dialog.IsExpandedMode = expandMode;
            return this;
        }
        public SaveFileDialogBuilder customize(Action<CommonSaveFileDialog> custom) {
            custom(Dialog);
            return this;
        }

        public static SaveFileDialogBuilder Create() {
            return new SaveFileDialogBuilder();
        }
    }
}
