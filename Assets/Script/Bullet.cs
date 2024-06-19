using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f; //弾のスピード

    void Update()
    {
        //右へ移動
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        //画面外に出たら消す
        /*if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }*/
    }
}