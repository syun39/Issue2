using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f; //弾のスピード
    [SerializeField] private float _width = 0.6f; //幅
    [SerializeField] private float _height = 0.3f; //高さ

    //弾の中心
    private Vector2 _enemyBulletCenter;

    void Update()
    {
        //左へ
        transform.Translate(_bulletSpeed * Time.deltaTime * Vector2.left);

        //画面外に出たら消す
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

        // 中心を更新
        _enemyBulletCenter = new Vector2(transform.position.x, transform.position.y);

        var player = FindObjectOfType<PlayerController>();

        if (CheckCollision(player) == true) //衝突したら
        {
            //Debug.Log("Player Hit");
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
        Vector2 playerCenter = new(player.transform.position.x, player.transform.position.y);

        //x軸の距離がx軸の幅の半分の和よりも小さいか
        //y軸の距離がy軸の高さの半分の和よりも小さいか
        if (Mathf.Abs(_enemyBulletCenter.x - playerCenter.x) < (_width + playerWidth) / 2 &&
            Mathf.Abs(_enemyBulletCenter.y - playerCenter.y) < (_height + playerHeight) / 2)
        {
            return true; //衝突
        }
        return false; //衝突してない
    }
}
