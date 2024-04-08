using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{

    public Action OnCoinCollect;
    [SerializeField] private GameObject particlePrefab;


    private void Start()
    {
        OnCoinCollect += CollectCoin;

    }

    private void OnDestroy()
    {
        OnCoinCollect -= CollectCoin;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCoinCollect?.Invoke();
            var coin = Instantiate(particlePrefab, other.gameObject.transform.position, other.gameObject.transform.rotation);
            ParticleSystem ps = coin.GetComponent<ParticleSystem>();
            var main = ps.main;


        }
    }

    
    public void CollectCoin()
    {
        GameManager.Instance.score++;
        Destroy(gameObject);
    }
}
