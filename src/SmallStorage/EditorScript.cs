using UnityEditor;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class EditorScript : MonoBehaviour
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
                                        BuildAssetBundleOptions.None, 
                                        BuildTarget.StandaloneWindows);
    }

    [MenuItem("Assets/Unpack CoI Assets")]
    static void UnpackAssets()
    {
        var files = Directory.EnumerateFiles("F:\\SteamLibrary\\steamapps\\common\\Captain of Industry\\AssetBundles\\");

        foreach (var file in files)
        {
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(file);
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load: " + file);
                continue;
            }

            var assetNames = myLoadedAssetBundle.GetAllAssetNames();
            myLoadedAssetBundle.LoadAllAssets();
            foreach (var name in assetNames) {
                if (name.StartsWith("assets/base/buildings/storages/"))
                {
                    Debug.Log("Loading asset: " + name);
                    var asset = myLoadedAssetBundle.LoadAssetWithSubAssets<GameObject>(name);
                    if (asset == null)
                    {
                        Debug.Log("Asset was null");
                        continue;
                    }
                    var baseName = name.Split('/')[4];
                    var SceneObject = Instantiate(asset[0]);
                    // PrefabUtility.UnpackPrefabInstance(SceneObject, PrefabUnpackMode.Completely, InteractionMode.UserAction);
                    // PrefabUtility.SaveAsPrefabAsset(SceneObject, "Assets/ExampleMod/" + baseName);
                    // DestroyImmediate(SceneObject);
                }
            }
        }
    }

    [MenuItem("Assets/Unload All AssetBundles")]
    static void UnloadAssetBundles()
    {
        AssetBundle.UnloadAllAssetBundles(false);
    }
}