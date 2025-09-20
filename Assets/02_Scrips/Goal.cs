using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    Transform Ball;
    CameraShake CS;
    ParticleSystem Effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            Ball = collision.transform;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            CS = GameObject.Find("BackGround").GetComponent<CameraShake>();
            CS.Shake();
            EffectSound.Goal();
            Effect = GameObject.Find("Effect").GetComponent<ParticleSystem>();
            //EffectPlay();
            Invoke("EffectPlay", 0.5f);
            Invoke("Stage", 4f);
            //GameObject.Find("Stage").GetComponent<Stage>().IsGameOver(true);
        }
    }
    void Stage()
    {
        GameObject.Find("Stage").GetComponent<Stage>().IsGameOver(true);
    }

    private void Update()
    {
        if(Ball != null)
        {
            Ball.transform.position = Vector2.Lerp(Ball.position, this.transform.position, 3f * Time.deltaTime);
        }
    }
    void EffectPlay()
    {
        Effect.transform.position = this.transform.position;
        
        //Effect.transform.position = this.transform.localScale * 0.5f;
        Effect.Play();
    }
}
