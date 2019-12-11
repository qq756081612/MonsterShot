###1.获取文件夹上层目录
// \../ 获取上级目录 要加转义字符
Application.OpenURL("file:///" + Application.dataPath + "\\../");

//还可以写成这样 注意这两种写法的区别 用API会自动添加'\'且无需转义
//Application.OpenURL("file:///" + Path.Combine(Application.dataPath, "../"));

###2.弃用属性
[Obsolete("⽅法以过时，请使⽤ EditorUtil.ExportPackage(assetPathName, fileName);"]

###3.partial关键字
允许一个类在多个地方被实现

###4.运行Unity
UnityEditor.EditorApplication.isPlaying = true;

###5.执行路径中的MenuItem方法
EditorApplication.ExecuteMenuItem("")

###6.拷贝到剪切板
GUIUtility.systemCopyBuffer = fileName;

###7. PureMVC官网文档地址
http://puremvc.org/docs/PureMVC_IIBP_Chinese.pdf

###8.List的使用
list扩容默认是翻倍扩容的，容易造成内存不必要的开销，故已经list长度的时候可以使用构造函数传入list的长度，或者使用Capacity属性指定。