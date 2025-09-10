using UnityEditor;
using System.IO;

public static class BuildScript
{
    public static void PerformWebGLBuild()
    {
        string path = "Builds/WebGL";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/SampleScene.unity" },
            path,
            BuildTarget.WebGL,
            BuildOptions.None
        );
    }
    
    public static void PerformWindowsBuild()
    {
        string path = "Builds/Windows";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        
        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/SampleScene.unity" },
            path,
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }

    public static void PerformAndroidBuildDevelopment()
    {
        string dir = "Builds/Android/Development";
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        // Build APK for development (Debug)
        EditorUserBuildSettings.buildAppBundle = false;
        EditorUserBuildSettings.androidBuildType = AndroidBuildType.Debug;

        string apkPath = Path.Combine(dir, "App-Dev.apk");

        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/SampleScene.unity" },
            apkPath,
            BuildTarget.Android,
            BuildOptions.Development | BuildOptions.AllowDebugging
        );
    }

    // todo: signing
    public static void PerformAndroidBuildRelease()
    {
        string dir = "Builds/Android/Release";
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        // Build AAB for release (Release)
        EditorUserBuildSettings.buildAppBundle = true;
        EditorUserBuildSettings.androidBuildType = AndroidBuildType.Release;

        string aabPath = Path.Combine(dir, "App-Release.aab");

        BuildPipeline.BuildPlayer(
            new[] { "Assets/Scenes/SampleScene.unity" },
            aabPath,
            BuildTarget.Android,
            BuildOptions.None
        );
    }
}