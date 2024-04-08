using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var barrier = Instantiate(particlePrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
            ParticleSystem ps = barrier.GetComponent<ParticleSystem>();
            var main = ps.main;
            GameManager.Instance.EndGame();
        }
    }
}
