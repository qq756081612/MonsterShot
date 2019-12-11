using UnityEditor;
using UnityEngine;
using System;
using System.IO;

namespace SakiFramework
{
    public class PackageFramework
    {
        [MenuItem("SakiFramework/打开项目文件夹 %e", false,1)]
        private static void PackageSakiFramework()
        {
            //string filePath = "Assets/SakiFramework";
            //string fileName = string.Format("SakiFramework_{0}.unitypacakge", DateTime.Now.ToString("yyyy_MM_dd_hh_mm"));

            //PackageAssetsOpenFilePath(filePath, fileName);

            //EditorUtility.DisplayDialog("操作成功", "一键打包框架完成","确定");

            Application.OpenURL("file:///" + Application.dataPath + "\\../");
        }

        public static void PackageAssetsOpenFilePath(string filePath, string fileName)
        {
            AssetDatabase.ExportPackage(filePath, fileName, ExportPackageOptions.Recurse);
            Application.OpenURL("file:///" + Application.dataPath + "\\../");
        }

        [MenuItem("SakiFramework/临时测试方法 %t", false, 999)]
        private static void TempTestFunc()
        {           

        }
    }
}


