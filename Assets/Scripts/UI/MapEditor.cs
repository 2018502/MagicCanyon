using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEditor : MonoBehaviour
{
    // 地图
    public Image mapImage;
    // 可放置网格
    public GridLayoutGroup mapGrid;
    // 可放置格子预制体
    public GameObject cellPrefab;

    private float mapWidth, mapHeight;

    void Start()
    {
        RectTransform mapImageTrans = mapImage.GetComponent<RectTransform>();
        mapWidth = mapImageTrans.rect.width;
        mapHeight = mapImageTrans.rect.height;
    }

    /*
	 * 给虚拟地图设置图片
	 */
    public void SetMapImage(Sprite mapSprite)
    {
        mapImage.sprite = mapSprite;
    }

    /*
	 * 给虚拟地图设置网格
	 */
    public void CreateCell(int rawCount, int columnCount)
    {
        CommonUtils.destroyAllChildren(mapGrid.gameObject);

        // 计算每格宽高
        float cellWidth = (mapWidth - mapGrid.spacing.x * (columnCount - 1)) / columnCount;
        float cellHeight = (mapHeight - mapGrid.spacing.y * (rawCount - 1)) / rawCount;

        mapGrid.cellSize = new Vector2(cellWidth, cellHeight);

        for (int i = 0; i < rawCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                // 生成可放置格子
                GameObject cellObj = Instantiate(cellPrefab, mapGrid.transform);
            }
        }
    }
}
