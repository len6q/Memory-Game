using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class CardData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _frontSprite;
    [SerializeField] private Sprite _backSprite;

    public int Id => _id;
    public Sprite FrontSprite => _frontSprite;
    public Sprite BackSprite => _backSprite;
}
