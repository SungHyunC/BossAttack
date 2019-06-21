using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] public GameObject otherObject;
    private BossHp pInfo; // 플레이어의 스크립트가 저장될 변수.
    public BoxCollider weapon;
    private AttackButton btn;
    private Animator anim;

    private void Awake()
    {
        weapon = GetComponent<BoxCollider>();
        anim = otherObject.GetComponent<Animator>();
    }

    void Update()
    {
        
    }


    IEnumerator StartDamage()
    {
        while (true)
        {
            // 플레이어가 가지고 있는 UIUpdate호출.
            pInfo.UIUpdate("Damage", "HP", 0.1f);
            yield return null;
        }
    }

    // 충돌 했을 때.
    void OnTriggerEnter(Collider _Col)
    {
        if (_Col.transform.CompareTag("Boss"))
        {
            // 플레이어의 스크립트 컴포넌트를 가져온다.
            pInfo = _Col.GetComponent<BossHp>();
            StartCoroutine("StartDamage");
        }
    }

    // 충돌이 끝났을 때.
    void OnTriggerExit(Collider _Col)
    {
        if (_Col.transform.CompareTag("Boss"))
        {
            // 코루틴을 멈춘다.
            StopCoroutine("StartDamage");

            // 충돌이 끝난 후 정보를 플레이어의 정보를 게속 가지고 있을 필요가
            // 없기 때문에 null로 초기화 해준다.
            pInfo = null;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
}
