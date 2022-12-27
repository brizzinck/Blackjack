using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _scoreTXT;
    [SerializeField] private Transform _deckPostion;
    [SerializeField] private string _name;
    protected Vector3 _cardPosition;
    private int currentScore = 0;

    public Transform DeckPostion { get => _deckPostion; }
    public int CurrentScore { get => currentScore; }
    public virtual void AIAnalysis(List<int> scores)
    {
    }
    public virtual void AddCard(GameCard card)
    {
        card.transform.position = _cardPosition;
        _cardPosition += new Vector3(0.25f, 0.25f, 0);
    }
    public virtual void AddScore(int score)
    {
        currentScore += score;
        _scoreTXT.text = currentScore.ToString();
    }
    private void Awake()
    {
        _cardPosition = _deckPostion.position;
    }
}
