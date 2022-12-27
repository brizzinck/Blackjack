using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _scoreTXT;
    [SerializeField] private Transform _deckPostion;
    private Vector3 _cardPosition;
    private int _currentScore = 0;

    public Transform DeckPostion { get => _deckPostion; }

    private void Awake()
    {
        _cardPosition = _deckPostion.position;
    }
    public void AddCard(GameCard card)
    {
        card.transform.position = _cardPosition;
        _cardPosition += new Vector3(0.25f, 0.25f, 0);
    }
    public void AddScore(int score)
    {
        _currentScore += score;
        _scoreTXT.text = _currentScore.ToString();
        if (_currentScore > 21)
        {
            Dealer.GameOver();
        }
    }
}
