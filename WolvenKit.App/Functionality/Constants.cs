using System.Collections.Immutable;
using System.Windows.Input;

namespace WolvenKit.Functionality.WKitGlobal
{
    public static class AppCommands
    {
        #region Classes

        public static class Application
        {
            #region Fields

            public const string About = "Application.About";
            public const string BackupMod = "Application.BackupMod";
            public const string BugReport = "Application.BugReport";
            public const string CreateNewProject = "Application.CreateNewProject";
            public const string DelProject = "Application.DeleteProject";
            public const string Exit = "Application.Exit";
            public const string NewFile = "Application.NewFile";
            public const string NewProject = "Application.NewProject";
            public const string PublishProject = "Application.PublishProject";
            public const string OpenFile = "Application.OpenFile";
            public const string OpenLink = "Application.OpenLink";
            public const string OpenProject = "Application.OpenProject";
            public const string Options = "Application.Options";
            public const string PackMod = "Application.PackMod";
            public const string PublishMod = "Application.PublishMod";
            public const string SaveAsProject = "Application.SaveAsProject";
            public const string SaveProject = "Application.SaveProject";
            public const string SaveFile = "Application.SaveFile";
            public const string SaveAll = "Application.SaveAll";

            public const string ShowAbout = "Application.ShowAbout";
            public const string ShowAnimationTool = "Application.ShowAnimationTool";
            public const string ShowAssetBrowser = "Application.ShowAssetBrowser";
            public const string ShowAudioTool = "Application.ShowAudioTool";
            public const string ShowVideoTool = "Application.ShowVideoTool";
            public const string ShowBulkEditor = "Application.ShowBulkEditor";
            public const string ShowCodeEditor = "Application.ShowCodeEditor";
            public const string ShowCR2WEditor = "Application.ShowCR2WEditor";
            public const string ShowCR2WToTextTool = "Application.ShowCR2WToTextTool";
            public const string ShowCsvEditor = "Application.ShowCsvEditor";
            public const string ShowFeedback = "Application.ShowFeedback";
            public const string ShowGameDebuggerTool = "Application.ShowGameDebuggerTool";
            public const string ShowHexEditor = "Application.ShowHexEditor";
            public const string ShowImporterTool = "Application.ShowImporterTool";
            public const string ShowImportUtility = "Application.ShowImportUtility";
            public const string ShowJournalEditor = "Application.ShowJournalEditor";
            public const string ShowLog = "Application.ShowLog";
            public const string ShowMenuCreatorTool = "Application.ShowMenuCreatorTool";
            public const string ShowMimicsTool = "Application.ShowMimicsTool";
            public const string ShowModSettings = "Application.ShowModSettings";
            public const string ShowPackageInstaller = "Application.ShowPackageInstaller";
            public const string ShowPluginManager = "Application.ShowPluginManager";
            public const string ShowProjectExplorer = "Application.ShowProjectExplorer";
            public const string ShowProperties = "Application.ShowProperties";
            public const string ShowRadishTool = "Application.ShowRadishTool";
            public const string ShowSettings = "Application.ShowSettings";
            public const string ShowVisualEditor = "Application.ShowVisualEditor";
            public const string ShowWccTool = "Application.ShowWccTool";


            public const string ViewSelected = "Application.ViewSelected";

            #endregion Fields
        }

        public static class ProjectExplorer
        {
            #region Fields

            public const string Refresh = "ProjectExplorer.Refresh";

            #endregion Fields
        }

        public static class Settings
        {
            #region Fields

            public const string General = "Settings.General";

            #endregion Fields
        }

        #endregion Classes
    }

    public static class Settings
    {
        #region Classes

        public static class Application
        {
            #region Classes

            public static class AutomaticUpdates
            {
                #region Fields

                public const bool CheckForUpdatesDefaultValue = true;

                

                #endregion Fields
            }

            public static class General
            {
                #region Fields

                public const string SomeSetting = "General.SomeSetting";
                public const bool SomeSettingDefaultValue = true;

                #endregion Fields
            }

            #endregion Classes
        }

        #endregion Classes
    }
}
