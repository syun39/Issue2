using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("「Bullet」という名前のプレハブをアタッチして下さい")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _speed = 1f; //移動の速さ
    [SerializeField] private float _jumpPower = 1f; //ジャンプ力
    [SerializeField] private float _gravity = 9.8f; // 重力

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
            if (transform.position.y <= -4)
            {
                _isJumping = false;
                _jumpSpeed = 0;
            }
        }
    }
}
