using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    Rigidbody rb;
    Animator anim;
    AudioSource audioSource;

    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_JoyStick;
    [SerializeField] private GameObject otherObject;
    [SerializeField] private float MoveSpeed;

    private float radius;
    private bool isTouch = false;
    private Vector3 movePosition;
    public Vector3 lookDirection;
    public float h, v;

    void Start()
    { 
        radius = rect_Background.rect.width * 0.5f;
        audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        rb = otherObject.GetComponent<Rigidbody>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1280, 720, true);
        anim = otherObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    { 
        if (isTouch)
        {
            otherObject.transform.position += movePosition;

            anim.SetBool("isRunning", true);
            
        }
        else
        {
            audioSource.Play();
            anim.SetBool("isRunning", false);
        }
         
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Background.position;  
        value = Vector2.ClampMagnitude(value, radius);
        rect_JoyStick.localPosition = value;
        h = value.x;
        v = value.y;
        value = value.normalized;
        movePosition = new Vector3(value.x * MoveSpeed * Time.deltaTime , 0f , value.y * MoveSpeed  * Time.deltaTime);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_JoyStick.localPosition = Vector3.zero;
    }
}
