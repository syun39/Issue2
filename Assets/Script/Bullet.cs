using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f; //弾のスピード
    [SerializeField] float _width = 0.6f; //幅
    [SerializeField] float _height = 0.3f; //高さ

    //弾の中心
    private Vector2 _bulletCenter;

    void Update()
    {
        //右へ
        transform.Translate(_bulletSpeed * Time.deltaTime * Vector2.right);

        //画面外に出たら消す
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }

        //中心を更新
        _bulletCenter = new Vector2(transform.position.x, transform.position.y);

        //全ての敵を探す
        var enemies = FindObjectsOfType<Enemy>();

        //全ての敵と衝突判定
        foreach (var enemy in enemies)
        {
            if (CheckCollision(enemy) == true) //衝突したら
            {
                //Debug.Log("Enemy Hit!");
                enemy.EnemyDamage();
                Destroy(gameObject);
                break;
            }
        }
    }

    /// <summary>
    /// 敵との衝突判定
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    private bool CheckCollision(Enemy enemy)
    {
        float enemyWidth = enemy._width;
        float enemyHeight = enemy._height;

        //敵の中心
        Vector2 enemyCenter = new(enemy.transform.position.x, enemy.transform.position.y);

        //x軸の距離がx軸の幅の半分の和よりも小さいか
        //y軸の距離がy軸の高さの半分の和よりも小さいか
        if (Mathf.Abs(_bulletCenter.x - enemyCenter.x) < (_width + enemyWidth) / 2 &&
            Mathf.Abs(_bulletCenter.y - enemyCenter.y) < (_height + enemyHeight) / 2)
        {
            return true; //衝突
        }
        return false; //衝突してない
    }
}