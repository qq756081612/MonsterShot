using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetPostprocessorTool : AssetPostprocessor
{
    TextureImporter textureImporter;
    private void OnPostprocessTexture()
    {
        textureImporter = (TextureImporter)assetImporter;

        textureImporter.textureType = TextureImporterType.Sprite;
        textureImporter.isReadable = false;
        textureImporter.mipmapEnabled = false;
    }
}
