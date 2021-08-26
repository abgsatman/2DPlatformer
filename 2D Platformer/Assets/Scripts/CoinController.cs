using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(RandomizeCoin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RandomizeCoin()
    {
        float randomTimeSecond = Random.Range(0.01f, 0.5f);
        yield return new WaitForSeconds(randomTimeSecond);
        animator.enabled = true;
    }
}
