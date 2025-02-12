
namespace PackageExporter.Editor
{
    internal sealed class CLIBuilder
    {
        public static void Build()
        {
            var assetsFolderPath = PackageExporterSetting.Instance.FolderPath;
            var isCompletedTest = PackageExporterSetting.Instance.IsCompletedTest;
            if (!string.IsNullOrWhiteSpace(assetsFolderPath) && isCompletedTest)
            {
                Builder.BuildWithAssetsFolder(assetsFolderPath);
            }
            else
            {
                Logger.Error("Please perform a package export test in Unity first. Go to Window > Test Export Package.");
            }
        }
    }
}