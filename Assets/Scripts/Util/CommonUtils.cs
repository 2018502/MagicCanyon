using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonUtils
{
    /*
	 * 杀死提供Object的所有子元素
	 */
    public static void destroyAllChildren(GameObject parent)
    {
        for (int i = 0, size = parent.transform.childCount; i < size; i++)
        {
            Object.Destroy(parent.transform.GetChild(i).gameObject);
        }
    }
}
