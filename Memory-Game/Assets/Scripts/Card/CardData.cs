using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class CardData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _frontSprite;
    [SerializeField] private Sprite _backSprite;

    public int Id { get { return _id; } }
    public Sprite FrontSprite { get { return _frontSprite; } }
    public Sprite BackSprite { get { return _backSprite; } }
}
