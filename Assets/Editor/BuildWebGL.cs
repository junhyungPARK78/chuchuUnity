using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

/// <summary>
/// 배치모드 WebGL 빌드용 스크립트.
/// 사용 예:
///   Unity -batchmode -quit -projectPath <path> -executeMethod BuildWebGL.Build
/// 이슈 #19(빌드 자동화)의 토대이기도 하다.
/// </summary>
public static class BuildWebGL
{
    public static void Build()
    {
        var options = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Scenes/Game.unity" },
            locationPathName = "Build/chuchuGame_web",
            target = BuildTarget.WebGL,
            options = BuildOptions.None,
        };

        BuildReport report = BuildPipeline.BuildPlayer(options);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"[BuildWebGL] 빌드 성공: {summary.totalSize / (1024 * 1024)} MB, {summary.totalTime}");
            EditorApplication.Exit(0);
        }
        else
        {
            Debug.LogError($"[BuildWebGL] 빌드 실패: {summary.result}, 에러 {summary.totalErrors}건");
            EditorApplication.Exit(1);
        }
    }
}
