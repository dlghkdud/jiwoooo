using UnityEngine;
public interface IObjectItem
{
    Item ClickItem();
}

public class ObjectItem : MonoBehaviour, IObjectItem
{

    [Header("������")]
    public Item item;
    [Header("������ �̹���")]
    public SpriteRenderer itemImage;

    void Start()
    {
        itemImage.sprite = item.itemImage;
    }
    public Item ClickItem()
    {
        return this.item;
    }
}