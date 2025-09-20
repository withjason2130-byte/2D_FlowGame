using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    GameObject Origin = null;
    PlayerMove PlayBall = null;
    Goal GoalObj = null;

    private void Start()
    {
        Origin = Resources.Load("Prefabs/Player") as GameObject;
        Debug.Log(Origin);

        if(Origin == null)
        {
            Debug.Log("리소스 폴더를 확인하세요");
            return;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReCreate();
        }
    }

    void ReCreate()
    {
        if(PlayBall != null)
        {
            Destroy(PlayBall.gameObject);
        }
        //GameObject temp = Instantiate(Origin, this.transform);
        //temp.transform.position = new Vector2(0, -4);
        //PlayBall = temp.GetComponent<PlayerMove>();
        if(SceneManager.GetActiveScene().name == "Stage1")
        {
            GameObject temp = Instantiate(Origin, this.transform);
            temp.transform.position = new Vector2(0, -4);
            GameManager.instance.count = 10;
            Debug.Log("Stage1 목숨 :" + GameManager.instance.count);
            PlayBall = temp.GetComponent<PlayerMove>();
        }

        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            Debug.Log("stage2목숨 불러오기");

            GameObject temp = Instantiate(Origin, this.transform);
            temp.transform.position = new Vector2(0, -4);
            GameManager.instance.count = 10;
            Debug.Log("Stage2 목숨 :" + GameManager.instance.count);
            PlayBall = temp.GetComponent<PlayerMove>();
        }
    }
    public void IsGameOver(bool isSuccess = false)
    {
        if(isSuccess == true)
        {
            Debug.Log("성공 !~!");
            string currentSceneName = SceneManager.GetActiveScene().name;

            if(currentSceneName == "Stage1")
            {
                SceneManager.LoadScene("Stage2");
            }
            if (currentSceneName == "Stage2")
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        else
        {
            Destroy(PlayBall.gameObject);
            Debug.Log("Fail");
        }
    }
}
