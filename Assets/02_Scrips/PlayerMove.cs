using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    bool IsDown = false;
    bool BeUsed = false;

    Rigidbody2D rb;

    Vector2 PrevPos = Vector2.zero;
    Vector2 InputPos = Vector2.zero;

    static public int count;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if(rb == null)
        {
            Debug.Log("Rigidbody is NULL");
            return;
        }

        //count = 10;
    }

    void Update()
    {
        if(BeUsed == false && Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(pos, Vector2.zero);

            if(hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                IsDown = true;
                rb.velocity = Vector2.zero;
                PrevPos = pos;
                Debug.Log(hit);

                InvokeRepeating("PrevCachingPos", 0f, 0.1f);
            }
        }

        if(IsDown == true)
        {
            InputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = InputPos;
        }
    }
    
    void PrevCachingPos()
    {
        PrevPos = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsDown == true && collision.gameObject.name.Equals("StartTrigger"))
        {
            BeUsed = true;
            IsDown = false;
            Vector2 dir = (InputPos - PrevPos);
            rb.AddForce(dir.normalized * Vector2.Distance(InputPos, PrevPos) * 200f);

            PrevPos = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //count--;

        GameManager.instance.count--;

        if(GameManager.instance.count <= 0)
        {
            Destroy(this.gameObject);
            //Debug.Log("GameOver");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
