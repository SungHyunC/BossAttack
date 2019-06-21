using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class Camera : MonoBehaviour
{
    public float distance = 10;
    public Vector2 sensitiveity = new Vector2(5, 3);

    private Transform pivot;
    public GameObject player;
    private bool[] touchUI = new bool[10];
    private Vector2[] beginPos = new Vector2[10];
    Vector3 originPos;
    private void Start()
    {
        
        originPos = transform.localPosition;
        
    }
    private void Awake()
    {
        pivot = transform.parent.transform;

        transform.localEulerAngles = new Vector3(90, 0, 0);
    }
    private void Update()
    {
    }
    private void LateUpdate()
    {

        transform.localPosition = new Vector3(0, distance, 0);

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {


                }
            }

            else if (touch.phase == TouchPhase.Moved && !touchUI[touch.fingerId])
            {
                Vector2 movePos = touch.position - beginPos[touch.fingerId];
                movePos = movePos.normalized * sensitiveity;

                

                Vector3 pivotRotation = pivot.localEulerAngles;
                pivotRotation.x += movePos.y * -1;
                pivotRotation.y += movePos.x;

                if (pivotRotation.x < 270 && pivotRotation.x > 135)
                    pivotRotation.x = 270;
                else if (pivotRotation.x > 0 && pivotRotation.x <= 135)
                    pivotRotation.x = 0;

                pivot.localEulerAngles = pivotRotation;




            }

            else if (touch.phase == TouchPhase.Ended)
            {
                if (touchUI[touch.fingerId])
                    touchUI[touch.fingerId] = false;
            }

            beginPos[touch.fingerId] = touch.position;
        }
    }
    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;

    }
}