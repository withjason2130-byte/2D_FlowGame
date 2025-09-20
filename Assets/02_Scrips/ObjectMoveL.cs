using UnityEngine;

public class ObjectMoveL : MonoBehaviour
{
    public float moveSpeed = 2f;  // 이동 속도
    public float moveDistance = 2f; // 이동할 최대 거리
    private float startX; // 시작 위치 X 값 저장

    void Start()
    {
        startX = transform.position.x; // 오브젝트의 초기 X 좌표 저장
    }

    void Update()
    {
        // Mathf.PingPong을 사용해 좌우 이동 (startX ± moveDistance 사이)
        float newX = startX + Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            EffectSound.CloudCrash();
        }
    }
}


