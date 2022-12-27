using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewDeck", menuName = "Deck", order = 1)]
public class BaseDeck : ScriptableObject
{
    [SerializeField] private BaseCard[] _cards;

    public BaseCard[] Cards { get => _cards; }
}
