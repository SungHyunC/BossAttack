using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    public BossHp bosshp;
    public PlayerHp playerhp;
    public Image Lose;
    public Image Win;
    public TextMeshProUGUI timeText;
    private float time;

    private void Start()
    {
        
    }

    private void Awake()
    {
        time = 100f;
    }

    private void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        timeText.text = Mathf.Ceil(time).ToString();
        if(time < 0)
        {
            Lose.gameObject.SetActive(true);
        }
        if (bosshp.Img[0].fillAmount == 0 && bosshp.p_HP < 0)
        {
            Win.gameObject.SetActive(true);
        }
        if (playerhp.p_HP == 0)
        {
            Lose.gameObject.SetActive(true);
        }
    }
}
