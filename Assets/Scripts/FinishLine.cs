using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null) {

            var finishLine = Instantiate(particlePrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
            ParticleSystem ps = finishLine.GetComponent<ParticleSystem>();
            var main = ps.main;

        }
    }
}
