using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceableSelector : MonoBehaviour
{
    // 可放置物体选择器网格
    private GridLayoutGroup selectorGrid;
    // 可放置物体图标预制体
    public GameObject cellPrefab;
    // 可放置物体图标的宽高
    public Vector2 cellSize = new Vector2(100, 200);
    [Space]
    // 可放置物体图标列表
    public Sprite[] iconList;

    private float selectorWidth;
    private float selectorHeight;

    // 当前选中可放置物体的序号
    private int selPlaceableIndex = -1;

    // Use this for initialization
    void Start()
    {
        selectorGrid = GetComponent<GridLayoutGroup>();
        RectTransform selectorTrans = GetComponent<RectTransform>();
        selectorWidth = selectorTrans.rect.width;
        selectorHeight = selectorTrans.rect.height;

        CreateCell(new int[] { 0, 1, 2 });
    }

    /*
	 * 设置可放置选择网格
	 * @param selPlaceableIndexList 可选择的可放置物体序号列表
	 */
    public void CreateCell(int[] selectablePlaceableIndexList)
    {
        CommonUtils.destroyAllChildren(gameObject);

        int listSize = selectablePlaceableIndexList.Length;
        float spacing = (selectorWidth - listSize * cellSize.x) / listSize;
        int horPadding = (int)(spacing / 2);
        int verPadding = (int)((selectorHeight - cellSize.y) / 2);

        selectorGrid.padding = new RectOffset(horPadding, horPadding, verPadding, verPadding);
        selectorGrid.cellSize = new Vector2(cellSize.x, cellSize.y);
        selectorGrid.spacing = new Vector2(spacing, 0);

        for (int i = 0; i < listSize; i++)
        {
            GameObject cellObj = Instantiate(cellPrefab, selectorGrid.transform);
        }
    }

    /*
     * 选择可放置物体
     * @param selIndex 选择的可放置物体的序号
     */
    public void ChoosePlaceable(int selIndex)
    {
        this.selPlaceableIndex = selIndex;
    }

    /*
     * 获取选择的可放置物体
     * @return 已选择的序号，如果没选则返回-1
     */
    public int GetSelPlaceableIndex()
    {
        return this.selPlaceableIndex;
    }
}
