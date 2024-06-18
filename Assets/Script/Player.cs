using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;

    void Update()
    {
        //Aが押されたら弾を生成
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
    }
}
