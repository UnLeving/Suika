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
}