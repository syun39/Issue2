using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float _bulletSpeed = 10f; //弾のスピード

    void Update()
    {
        //右へ
        transform.Translate(Vector2.right * _bulletSpeed * Time.deltaTime);

        //画面外に出たら消す
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}