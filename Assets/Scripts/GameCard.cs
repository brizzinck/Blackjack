using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    public void SetImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;  
    }
}
