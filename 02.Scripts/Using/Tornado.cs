using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tornado : MonoBehaviour
{
    [SerializeField] public GameObject otherObject;

    AudioSource audioSource;

    Animator anim;
    public Button TornadoButton;

    public bool isTornado = false;
    float Delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        TornadoButton.onClick.AddListener(TaskOnClick);
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        anim = otherObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isTornado == true)
        {
            
            TornadoButton.interactable = false;
            Delay = 0;
        }
        if (isTornado == false)
        {
            Delay += Time.deltaTime;
            if (Delay > 0.7f)
            {
                TornadoButton.interactable = true;
            }

        }
    }
    void TaskOnClick()
    {
        isTornado = true;
        audioSource.Play();
        anim.SetBool("isTornado", true);
        StartCoroutine("TornadoCoroutine");
    }
    IEnumerator TornadoCoroutine()
    {
        yield return new WaitForSeconds(1.1f);
        anim.SetBool("isTornado", false);
        isTornado = false;
    }
}
