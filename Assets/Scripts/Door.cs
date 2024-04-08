using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Xml.Linq;
using Unity.VisualScripting;
using TMPro;
using JetBrains.Annotations;

public class Door : MonoBehaviour
{
    public Action ThroughDoor;
    public GameObject doorObject;
    [SerializeField] private GameObject particlePrefab;
    public Animator animator;


    public enum operators {add, subs, mult, div};

    public operators op;
    public int num;

    public TMP_Text doorText;
    public Material red, orange, yellow, green;
    private MeshRenderer doorMesh;

    private void Start()
    {
        ThroughDoor += DoorWarning;            
        doorMesh = doorObject.GetComponent<MeshRenderer>();

        if (op == operators.add)
        {
            doorMesh.material = yellow;
            doorText.text = "+" + num;
        }
        else if (op == operators.subs)
        {
            doorMesh.material = orange;
            doorText.text = "-" + num;

        }
        else if (op == operators.mult)
        {
            doorMesh.material = green;
            doorText.text = "x" + num;

        }
        else
        {
            doorMesh.material = red;
            doorText.text = "/" + num;
        }
    }

    private void OnDestroy()
    {
        ThroughDoor -= DoorWarning;
    }

    public void DoorWarning()
    {
        Debug.Log("PLAYER WENT THROUGH THE DOOR");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (op == operators.add)
        {
            GameManager.Instance.score += num;
        }
        else if (op == operators.subs)
        {
            GameManager.Instance.score -= num;
        }
        else if (op == operators.mult)
        {
            GameManager.Instance.score *= num;
        }
        else
        {
            GameManager.Instance.score /= num;
        }
        var door = Instantiate(particlePrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
        ParticleSystem ps = door.GetComponent<ParticleSystem>();
        var main = ps.main;


        Destroy(doorObject);
        Destroy(doorText);
        ThroughDoor?.Invoke();

    }
}
