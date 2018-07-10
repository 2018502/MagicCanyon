using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour
{
    public GridLayoutGroup mapIndexList;
    // 地图序号预制体
    public GameObject mapIndexPrefab;

    [Space]
    public Sprite[] mapImageList;
    public Vector2Int[] mapGridSizeList;

    [Space]
    public MapEditor mapEditor;

    void Start()
    {
        createMapIndexList(Mathf.Min(mapImageList.Length, mapGridSizeList.Length));
    }

    /*
	 * 创建地图序号列表
	 * @param mapCount 地图总数
	 */
    public void createMapIndexList(int mapCount)
    {
        CommonUtils.destroyAllChildren(mapIndexList.gameObject);

        for (int i = 0; i < mapCount; i++)
        {
            GameObject mapIndexObj = Instantiate(mapIndexPrefab, mapIndexList.transform);
            MapIndexClick mapIndexClick = mapIndexObj.GetComponent<MapIndexClick>();
            mapIndexClick.setMapSelector(this);
            mapIndexClick.setIndex(i);
        }
    }

    public void chooseMap(int index)
    {
        if (index < mapImageList.Length && index < mapGridSizeList.Length && index >= 0)
        {
            mapEditor.setMapImage(mapImageList[index]);
            mapEditor.setMapGrid(mapGridSizeList[index].x, mapGridSizeList[index].y);
        }
    }
}
