using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamgae : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }
    }
    private PlayerHp pInfo; // 플레이어의 스크립트가 저장될 변수.

    // 지속적으로 플레이어의 HP 감소.
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
        if (_Col.transform.CompareTag("Player"))
        {
            // 플레이어의 스크립트 컴포넌트를 가져온다.
            pInfo = _Col.GetComponent<PlayerHp>();
            StartCoroutine("StartDamage");
        }
    }

    // 충돌이 끝났을 때.
    void OnTriggerExit(Collider _Col)
    {
        if (_Col.transform.CompareTag("Player"))
        {
            // 코루틴을 멈춘다.
            StopCoroutine("StartDamage");

            // 충돌이 끝난 후 정보를 플레이어의 정보를 게속 가지고 있을 필요가
            // 없기 때문에 null로 초기화 해준다.
            pInfo = null;
        }
    }
}
