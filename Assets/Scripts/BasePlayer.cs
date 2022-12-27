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
    public virtual void AddScore(BaseCard baseCard)
    {
        if (baseCard.Score.Length == 0)
            currentScore += baseCard.Score[0];
        else if (baseCard.Score.Length > 0)
            currentScore = BestScore(baseCard);           
        _scoreTXT.text = currentScore.ToString();
    }
    private void Awake()
    {
        _cardPosition = _deckPostion.position;
    }
    private int BestScore(BaseCard baseCard)
    {
        int dataScore = currentScore;
        List<int> checkScore = new List<int>();
        for (int i = 0; i < baseCard.Score.Length; i++)
        {
            checkScore.Add(currentScore + baseCard.Score[i]);
        }
        int bestScore = checkScore[0];
        for (int i = 0; i < checkScore.Count; i++)
        {
            if (checkScore[i] > bestScore && checkScore[i] <= 21)
            {
                bestScore = checkScore[i];
            }
        }
        return bestScore;
    }
}
