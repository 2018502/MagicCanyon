using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEditor : MonoBehaviour
{
    // 地图
    public Image mapImage;
    // 可放置网格
    public GridLayoutGroup placeableGrid;
    // 可放置格子预制体
    public GameObject placeableCellPrefab;

    private float mapWidth, mapHeight;
    private RectTransform mapImageTrans;

    void Start()
    {
        mapImageTrans = mapImage.GetComponent<RectTransform>();
        mapWidth = mapImageTrans.rect.width;
        mapHeight = mapImageTrans.rect.height;
    }

    /*
	 * 给虚拟地图设置图片
	 */
    public void setMapImage(Sprite mapSprite)
    {
        mapImage.sprite = mapSprite;
    }

    /*
	 * 给虚拟地图设置网格
	 */
    public void setMapGrid(int rawCount, int columnCount)
    {
        CommonUtils.destroyAllChildren(placeableGrid.gameObject);

        // 计算每格宽高
        float cellWidth = (mapWidth - placeableGrid.spacing.x * (columnCount - 1)) / columnCount;
        float cellHeight = (mapHeight - placeableGrid.spacing.y * (rawCount - 1)) / rawCount;

        placeableGrid.cellSize = new Vector2(cellWidth, cellHeight);

        for (int i = 0; i < rawCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                GameObject placeableCellObj = Instantiate(placeableCellPrefab, placeableGrid.transform);
            }
        }
    }
}
