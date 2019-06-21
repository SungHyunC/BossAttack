using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    [SerializeField] public GameObject otherObject;

    Animator anim;
    AudioSource audioSource;
    public Button PowerButton;

    public bool isPower = false;
    float Delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        PowerButton.onClick.AddListener(TaskOnClick);
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        anim = otherObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPower == true)
        {
            PowerButton.interactable = false;
            Delay = 0;
        }
        if (isPower == false)
        {
            Delay += Time.deltaTime;
            if (Delay > 0.7f)
            {
                PowerButton.interactable = true;
            }

        }
    }
    void TaskOnClick()
    {
        isPower = true;
        audioSource.Play();
        anim.SetBool("isPower", true);
        StartCoroutine("PowerCoroutine");
    }
    IEnumerator PowerCoroutine()
    {
        yield return new WaitForSeconds(1.1f);
        anim.SetBool("isPower", false);
        isPower = false;
    }
}
