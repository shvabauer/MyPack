using System.Collections.Generic;
using UnityEditor;

namespace MyPack.DuplicatesDetection
{
#if UNITY_EDITOR
    public class DuplicatesDetector : AssetModificationProcessor
    {
        public static List<string> newAssets = new List<string>();

        static void OnWillCreateAsset(string aMetaAssetPath)
        {
            string assetPath = aMetaAssetPath.Substring(0, aMetaAssetPath.Length);
            newAssets.Add(assetPath);
        }
    }

    class DetectDuplicatesPostprocessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (DuplicatesDetector.newAssets.Count == 0)
                return;

            foreach (var str in importedAssets)
            {
                if (DuplicatesDetector.newAssets.Contains(str))
                {
                    ISingle obj = AssetDatabase.LoadAssetAtPath(str, typeof(ISingle)) as ISingle;

                    if (obj == null)
                        continue;

                    obj.OnDuplicateDetected();
                }
            }

            DuplicatesDetector.newAssets.Clear();
        }
    }
#endif
}