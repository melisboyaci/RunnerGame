using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;


public class Player : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private bool isTouchingBarrier = false; 

    private float firstTouchX;
    public float minZ = -2.1349f; 
    public float maxZ = 1.694391f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float diff = 0;

        Vector3 moveVector = new Vector3( speed * Time.deltaTime, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            firstTouchX = Input.mousePosition.x;
        }


        else if(Input.GetMouseButton(0)) 
        { 
            float lastTouchX = Input.mousePosition.x;
            diff = firstTouchX - lastTouchX;
            moveVector += new Vector3(0, 0, diff * Time.deltaTime);
            firstTouchX = lastTouchX;

        }
        Vector3 newPosition = transform.position + moveVector;
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
        transform.position = newPosition;

        if (Input.GetMouseButton(0))
        {
            GameManager.Instance.startGamePanel.SetActive(false);
            if (!isTouchingBarrier) 
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Run", true);
                speed = 5;
            }
        }
        else if(Input.GetMouseButtonUp(0)) 
        {
            if (!isTouchingBarrier) 
            {
                animator.SetBool("Run", false);
                animator.SetBool("Idle", true);
                speed = 0;
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            isTouchingBarrier = true;
            speed = 0;
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Fall Over", true);
            Debug.Log("BARRIER");

        }
        else if (other.CompareTag("Finish"))

        {
            isTouchingBarrier = true;

            Debug.Log("FINISH");
            speed = 0;
            //animator.SetBool("Run", false);
            //animator.SetBool("Turn", true);
            //Quaternion newRotation = Quaternion.Euler(0, 270, 0);
            //transform.rotation = newRotation;

            animator.SetBool("Win", true);
            GameManager.Instance.winGamePanel.SetActive(true);
        }
    }
}
