using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("「EBullet」という名前のプレハブをアタッチして下さい")]
    [SerializeField] GameObject _enemyBulletPrefab;
    [SerializeField] float _shootDistance = 5f; //この距離以下で撃てる
    [SerializeField] int _Interval = 1; //発射間隔
    [Tooltip("「Player」をアタッチして下さい")]
    [SerializeField] Transform _player; //プレイヤーの座標
    

    private float _currentTime; //経過した秒数
    private bool _isShoot = false; //発射済みかどうか

    void Update()
    {
        //プレイヤーと敵の距離
        float distance = Vector2.Distance(transform.position, _player.position);

        if (distance < _shootDistance)
        {
            if (_isShoot == false)
            {
                Instantiate(_enemyBulletPrefab, transform.position, Quaternion.identity);
                _isShoot = true;
                _currentTime = 0; //経過した時間を0に戻す
            }

            else
            {
                //_currentTime += Time.time; ←だと一度に多くの弾が生成されて長い棒のようになるのはなぜか？
                _currentTime += Time.deltaTime;

                if (_Interval < _currentTime)
                {
                    Instantiate(_enemyBulletPrefab, transform.position, Quaternion.identity);
                    _currentTime = 0; //経過した時間を0に戻す
                }
            }
        }
    }
}
