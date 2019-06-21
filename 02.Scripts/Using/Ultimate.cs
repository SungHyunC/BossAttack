using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate : MonoBehaviour
{
    [SerializeField] public GameObject otherObject;
    Animator anim;
    AudioSource audioSource;
    public Button UltimateButton;

    public bool isUltimating = false;
    float Delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        UltimateButton.onClick.AddListener(TaskOnClick);
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        anim = otherObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isUltimating == true)
        {
            UltimateButton.interactable = false;
            Delay = 0;
        }
        if (isUltimating == false)
        {
            Delay += Time.deltaTime;
            if (Delay > 4f)
            {
                UltimateButton.interactable = true;
            }
            
        }
    }
    void TaskOnClick()
    {
        isUltimating = true;
        audioSource.Play();
        anim.SetBool("isUltimating", true);
        StartCoroutine("UltimateCoroutine");
    }
    IEnumerator UltimateCoroutine()
    {
        yield return new WaitForSeconds(1.1f);
        anim.SetBool("isUltimating", false);
        isUltimating = false;
    }
}
