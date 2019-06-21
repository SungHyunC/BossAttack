using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    public Timer time;
    public GameObject[] Effect;
    public Image[] Img;          // HP,MP이미지.

    public float MAX_HP;         // HP 최대치.
    public float p_HP;           // 현재 HP.
    public bool ishp = false;
    public void UIUpdate(string _Type, string _InfoType, float _Value)
    {
        float Type = 0;   // HP또는 MP의 현재 수치.
        float MAXType = 0;   // HP또는 MP의 최대치.
        int Index = 0;   // HP또는 MP의 이미지 인덱스.

        switch (_InfoType)
        {
            case "HP":
                {
                    Index = 0;
                    Type = p_HP;
                    MAXType = MAX_HP;

                    // 리커버리면 회복
                    if (_Type == "Recover")
                        p_HP += _Value;
                    // 리커버리가 아니면 데미지.
                    else
                        p_HP -= _Value;

                    break;
                }
        }
        Img[Index].fillAmount = Type / MAXType;
    }
}
