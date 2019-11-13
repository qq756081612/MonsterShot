using UnityEditor;
using UnityEngine;
using System;
using System.IO;

namespace SakiFramework
{
    public class PackageFramework
    {
        [MenuItem("SakiFramework/一键打包框架")]
        private static void PackageSakiFramework()
        {
            string filePath = "Assets/SakiFramework";
            string fileName = string.Format("SakiFramework_{0}.unitypacakge", DateTime.Now.ToString("yyyy_MM_dd"));

            AssetDatabase.ExportPackage(filePath,fileName,ExportPackageOptions.Recurse);

            // \../ 获取上级目录 要加转义字符
            Application.OpenURL("file:///" + Application.dataPath + "\\../");

            //还可以写成这样 注意这两种写法的区别 用API会自动添加'\'且无需转义
            //Application.OpenURL("file:///" + Path.Combine(Application.dataPath, "../"));

            //拷贝到剪切板
            //GUIUtility.systemCopyBuffer = fileName;

            //执行路径中的MenuItem方法
            //EditorApplication.ExecuteMenuItem("")
        }
    }
}


