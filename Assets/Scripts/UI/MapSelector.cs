using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour
{
    public GridLayoutGroup selectorGrid;
    // 地图序号预制体
    public GameObject cellPrefab;

    [Space]
    public Sprite[] mapImageList;
    public Vector2Int[] gridSizeList;

    [Space]
    public MapEditor mapEditor;

    void Start()
    {
        CreateCell(Mathf.Min(mapImageList.Length, gridSizeList.Length));
    }

    /*
	 * 创建地图序号列表
	 * @param mapCount 地图总数
	 */
    public void CreateCell(int mapCount)
    {
        CommonUtils.destroyAllChildren(selectorGrid.gameObject);

        for (int i = 0; i < mapCount; i++)
        {
            GameObject mapIndexObj = Instantiate(cellPrefab, selectorGrid.transform);
            MapIndexClick mapIndexClick = mapIndexObj.GetComponent<MapIndexClick>();
            mapIndexClick.SetMapSelector(this);
            mapIndexClick.SetIndex(i);
        }
    }

    public void ChooseMap(int index)
    {
        if (index < mapImageList.Length && index < gridSizeList.Length && index >= 0)
        {
            mapEditor.SetMapImage(mapImageList[index]);
            mapEditor.CreateCell(gridSizeList[index].x, gridSizeList[index].y);
        }
    }
}
