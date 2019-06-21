using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashButton : MonoBehaviour
{
    [SerializeField] public GameObject otherObject;
    Animator anim;
    AudioSource audioSource;
    Rigidbody rb;

    public Button Dash;
    public bool isDash = false;
    public float dashSpeed = 5f;


    float Delay = 0;

    void Start()
    {
        Dash.onClick.AddListener(TaskOnClick);
        audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        rb = otherObject.GetComponent<Rigidbody>();
        anim = otherObject.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (isDash == true)
        {
            otherObject.transform.Translate(new Vector3(0f, 0f, dashSpeed * Time.deltaTime));
            Dash.interactable = false;
            Delay = 0;

        }
        if (isDash == false)
        {
            Delay += Time.deltaTime;
            if (Delay > 0.5f)
            {
                Dash.interactable = true;
            }

        }
    }
    void TaskOnClick()
    {
        isDash = true;
        audioSource.Play();
        anim.SetBool("isDashing", true);
        StartCoroutine("DashCoroutine");
    }
    IEnumerator DashCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("isDashing", false);
        isDash = false;
    }

}
