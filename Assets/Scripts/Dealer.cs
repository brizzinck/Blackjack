using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    [SerializeField] private Button _hit;
    [SerializeField] private Button _stand;


    [SerializeField] private BaseDeck _baseDeck;
    [SerializeField] private Player _player;
    [SerializeField] private GameCard _gameCard;
    private List<BaseCard> _baseCards = new List<BaseCard>();
    private BaseCard _currentCard;
    public static void GameOver()
    {
        Debug.Log("Game Over");
    }
    private void Start()
    {
        foreach(var card in _baseDeck.Cards) 
            _baseCards.Add(card);
        EnterGame();
    }
    private void EnterGame()
    {
        AddCard();
        AddEvent();
    }
    private void AddEvent()
    {
        _hit.onClick.AddListener(AddCard);
    }
    private void AddCard()
    {
        if (_baseCards.Count <= 0) return;
        _currentCard = _baseCards[Random.Range(0, _baseCards.Count)];
        _player.AddCard(SpawnCard(_player));
        _player.AddScore(_currentCard.Score);
        _baseCards.Remove(_currentCard);
    }
    private GameCard SpawnCard(Player player)
    {
        GameCard gameCard = Instantiate(_gameCard, player.DeckPostion);
        gameCard.SetImage(_currentCard.CardSprite);
        return gameCard;
    }
    private void NextMove()
    {

    }
}
