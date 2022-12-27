using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    [SerializeField] private Button _hit;
    [SerializeField] private Button _stand;
    [SerializeField] private Button _restart;
    [SerializeField] private GameObject _winnerPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _name;

    [SerializeField] private BaseDeck _baseDeck;
    [SerializeField] private List<BasePlayer> _players = new List<BasePlayer>();
    [SerializeField] private GameCard _gameCard;
    [SerializeField] private AIPlayer _aIPlayer;
    private int _indexCurrentPlayer = 0;
    private List<BaseCard> _baseCards = new List<BaseCard>();
    private BaseCard _currentCard;
    private void Start()
    {
        foreach(var card in _baseDeck.Cards) 
            _baseCards.Add(card);
        EnterGame();
    }
    private void EnterGame()
    {
        AddCard();
        NextMove();
        AddCard();
        NextMove();
        AddEvent();
    }
    private void AddEvent()
    {
        _hit.onClick.AddListener(AddCard);
        _stand.onClick.AddListener(NextMove);
        _aIPlayer.HitAI += AddCard;
        _aIPlayer.StandAI += NextMove;
        _restart.onClick.AddListener(Restart);
    }
    private void AddCard()
    {
        if (_baseCards.Count <= 0) return;
        _currentCard = _baseCards[Random.Range(0, _baseCards.Count)];
        _players[_indexCurrentPlayer].AddCard(SpawnCard(_players[_indexCurrentPlayer]));
        _players[_indexCurrentPlayer].AddScore(_currentCard);
        _baseCards.Remove(_currentCard);
        _players[_indexCurrentPlayer].AIAnalysis(Scores());
        CheckWinner();
    }
    private GameCard SpawnCard(BasePlayer player)
    {
        GameCard gameCard = Instantiate(_gameCard, player.DeckPostion);
        gameCard.SetImage(_currentCard.CardSprite);
        return gameCard;
    }
    private void NextMove()
    {
        _indexCurrentPlayer++;
        if (_indexCurrentPlayer >= _players.Count) 
            _indexCurrentPlayer = 0;
        _players[_indexCurrentPlayer].AIAnalysis(Scores());
        CheckWinner();
    }
    private List<int> Scores()
    {
        List<int> scores = new List<int>();
        foreach (BasePlayer player in _players)
        {
            if (player != _players[_indexCurrentPlayer])
            {
                scores.Add(player.CurrentScore);
            }
        }
        return scores;
    }
    private void CheckWinner()
    {
        BasePlayer winner;
        int winnerScore = 0;
        for (int i = 0; i < _players.Count; i++)
        {
            if (_players[i].CurrentScore > winnerScore && _players[i].CurrentScore < 21)
            {
                winnerScore = _players[i].CurrentScore;
                winner = _players[i];
            }
            else if (_players[i].CurrentScore > 21)
            {
                _players.Remove(_players[i]);
            }
        }
        if (_players.Count == 1)
        {
            DisplayWinner();
        }
    }
    private void DisplayWinner()
    {
        _name.text = _players[0].name;
        _winnerPanel.SetActive(true);
    }
    private void Restart()
    {
        Application.LoadLevel(0);
    }
    private void OnDestroy()
    {
        _aIPlayer.HitAI -= AddCard;
    }
}
