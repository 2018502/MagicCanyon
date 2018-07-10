using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapIndexClick : MonoBehaviour
{
    // 自身在列表中的序号
    public int selfIndex;
    public Text indexText;

    private MapSelector mapSelector;

    public void setMapSelector(MapSelector mapSelector)
    {
        this.mapSelector = mapSelector;
    }

    public void setIndex(int index)
    {
        selfIndex = index;
        indexText.text = (selfIndex + 1).ToString();
    }

    public void onClick()
    {
        mapSelector.chooseMap(selfIndex);
    }
}
