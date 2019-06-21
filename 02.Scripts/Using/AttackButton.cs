using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{

    [SerializeField] public GameObject otherObject;

    Animator anim;
    AudioSource audioSource;
    public Button Attack;

    public bool isAttack = false;
    float Delay = 0;

    void Start()
    {
        Attack.onClick.AddListener(TaskOnClick);
        audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        anim = otherObject.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if(isAttack == true)
        {
            Attack.interactable = false;
            Delay = 0;
        }
        if(isAttack == false)
        {
            Delay += Time.deltaTime;
            if(Delay > 0.7f)
            {
                Attack.interactable = true;
            }
            
        }
    }
    void TaskOnClick()
    {
        isAttack = true;
        audioSource.Play();
        anim.SetBool("isAttacking", true);
        StartCoroutine("AttackCoroutine");
    }
    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(1.1f);
        anim.SetBool("isAttacking", false);
        isAttack = false;
    }



}
