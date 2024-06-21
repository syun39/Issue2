using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("「Bullet」という名前のプレハブをアタッチして下さい")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector2 _colliderSize = new Vector2(1, 1);
    [SerializeField] private float _speed = 1f; //移動の速さ
    [SerializeField] private float _jumpPower = 1f; //ジャンプ力
    [SerializeField] private float _gravity = 9.8f; // 重力
    [SerializeField] public float _width = 1.0f; //幅
    [SerializeField] public float _height = 1.0f; //高さ
    [SerializeField] private int _life = 5; //ライフ

    private bool _isJumping = false;
    private float _jumpSpeed = 0f; //ジャンプの速さ

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //移動
        var horizontal = new Vector3(x* _speed * Time.deltaTime,0,0);
        transform.position += horizontal;

        //Wが押されたら弾を生成
        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
        {
            _isJumping = true;
            _jumpSpeed = _jumpPower;
        }

        // ジャンプ中
        if (_isJumping)
        {
            _jumpSpeed -= _gravity * Time.deltaTime; //重力を与える
            transform.Translate(new Vector2(0, _jumpSpeed) * Time.deltaTime);


            // 地面に着いたらリセット
            if (transform.position.y <= -3.4)
            {
                _isJumping = false;
                _jumpSpeed = 0;
            }
        }
    }

    /// <summary>
    /// 敵の弾に当たったらライフが減る
    /// </summary>
    public void PlayerDamage()
    {
        _life--;
        Debug.Log(_life);

        if (_life == 0) Debug.Log("GAME OVER!");
    }
}
