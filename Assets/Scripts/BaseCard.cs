using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card", order = 1)]

public class BaseCard : ScriptableObject
{
    [SerializeField] private Sprite _cardSprite;
    [SerializeField] private int[] _score;

    public int[] Score { get => _score; }
    public Sprite CardSprite { get => _cardSprite; }
}
