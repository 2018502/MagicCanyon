using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    // 地图
    public Image mapImage;
    // 可放置网格
    public GridLayoutGroup placeableGrid;
	// 可放置格子预制体
	public GameObject placeableCellPrefab;
    [Space]
    // 可放置行列数
    public int rawCount = 3;
    public int columnCount = 5;

    private float mapWidth, mapHeight;
    private RectTransform mapImageTrans;

    void Start()
    {
        mapImageTrans = mapImage.GetComponent<RectTransform>();
        mapWidth = mapImageTrans.rect.width;
        mapHeight = mapImageTrans.rect.height;

        createMap();
    }

    /**
	 * 生成虚拟地图
	 */
    public void createMap()
    {
		Debug.Log("width = " + mapWidth + " height = " + mapHeight + " xSpace = " + placeableGrid.spacing.x + " ySpace = " + placeableGrid.spacing.y);
        // 计算每格宽高
        float cellWidth = (mapWidth - placeableGrid.spacing.x * (columnCount - 1)) / columnCount;
        float cellHeight = (mapHeight - placeableGrid.spacing.y * (rawCount - 1)) / rawCount;

        placeableGrid.cellSize = new Vector2(cellWidth, cellHeight);

		for(int i = 0;i < rawCount; i++){
			for (int j = 0; j < columnCount; j++)
			{
				GameObject placeableCellObj = Instantiate(placeableCellPrefab, placeableGrid.transform);
			}
		}
    }
}
