using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f; //弾のスピード
    [SerializeField] private float _width = 0.5f; //幅
    [SerializeField] private float _height = 0.5f; //高さ

    //弾の中心
    private Vector2 EnemyBulletCenter;

    void Update()
    {
        //左へ
        transform.Translate(Vector2.left * _bulletSpeed * Time.deltaTime);

        //画面外に出たら消す
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

        // 弾の中心を更新
        EnemyBulletCenter = new Vector2(transform.position.x, transform.position.y);

        var player = FindObjectOfType<PlayerController>();

        if (CheckCollision(player) == true) //衝突したら
        {
            //Debug.Log("Player hit");
            player.PlayerDamage();
            Destroy(gameObject); // 弾を消す
        }
    }

    /// <summary>
    ///プレイヤーとの衝突判定
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    private bool CheckCollision(PlayerController player)
    {
        float playerWidth = player._width;
        float playerHeight = player._height;
        //プレイヤーの中心
        Vector2 playerCenter = new Vector2(player.transform.position.x, player.transform.position.y);

        //弾とプレイヤーの中心のx座標の差が両方の幅の半分の合計より小さいか
        //弾とプレイヤーの中心のy座標の差が両方の高さの半分の合計より小さいか
        if (Mathf.Abs(EnemyBulletCenter.x - playerCenter.x) < (_width + playerWidth) / 2 && 
            Mathf.Abs(EnemyBulletCenter.y - playerCenter.y) < (_height + playerHeight) / 2)
        {
            return true; //衝突している
        }
        return false; //衝突していない
    }
}
