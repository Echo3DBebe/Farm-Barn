using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Controller : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI bananaScoreText;
    [SerializeField]
    public TextMeshProUGUI CookieScoreText;

    GameObject Player_GO;
    Player_Movement player;
    int Banana_Score = 0, Cookie_Score = 0;
    [SerializeField]
    int Banana_total, Cookie_total;

    private void Awake()
    {
        bananaScoreText.text = "  /" + Banana_total;
        CookieScoreText.text = "  /" + Cookie_total;
        Player_GO = GameObject.Find("Player");
    }

    private void Start()
    {
        player = Player_GO.GetComponent<Player_Movement>();
        RefreshUI();
    }

    void CheckCollectablesTotal()
    {
        if(Cookie_Score == Cookie_total && Banana_Score == Banana_total)
        {
            player.LevelComplete();
        }
    }

    public void UpdateBananaScore()
    {
        Banana_Score++;
        RefreshUI();
        CheckCollectablesTotal();
    }

    public void UpdateCookieScore()
    {
        Cookie_Score++;
        RefreshUI();
        CheckCollectablesTotal();
    }

    private void RefreshUI()
    {
        bananaScoreText.text = Banana_Score + "/" + Banana_total;
        CookieScoreText.text = Cookie_Score + "/" + Cookie_total;
    }
}
