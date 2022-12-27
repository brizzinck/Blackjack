using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIPlayer : BasePlayer
{
    public UnityAction HitAI;
    public UnityAction StandAI;
    public override void AIAnalysis(List<int> scores)
    {
        foreach (var score in scores)
        {
            if (score != 21 && CurrentScore < score)
            {
                HitAI?.Invoke();
            }
        }
        StandAI?.Invoke();
    }
    public override void AddCard(GameCard card)
    {
        card.transform.position = _cardPosition;
        _cardPosition += new Vector3(-0.25f, -0.25f, 0);
    }
}
