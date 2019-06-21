using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{

    public float runSpeed;

    GameObject player;
    NavMeshAgent nav;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");

        nav = GetComponent<NavMeshAgent>();
        nav.speed = runSpeed;
    }

    void Update()
    {
        nav.SetDestination(player.transform.position);
    }
}
