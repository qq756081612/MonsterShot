using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SakiFramework
{
    public class Tools
    {
        static public void  SetLocalPositionX(GameObject go, float x)
        {
            go.transform.localPosition = new Vector3(x, go.transform.localPosition.y, go.transform.localPosition.z);
        }

        static public void SetLocalPositionY(GameObject go, float y)
        {
            go.transform.localPosition = new Vector3(go.transform.localPosition.x, y, go.transform.localPosition.z);
        }

        static public void SetLocalPositionZ(GameObject go, float z)
        {
            go.transform.localPosition = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y, z);
        }
    }
}


