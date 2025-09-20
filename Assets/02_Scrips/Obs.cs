using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            EffectSound.Meteor();
            animator.SetTrigger("Destroy");
            Destroy(gameObject, 1);
        }
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
