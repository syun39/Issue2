using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;

    void Update()
    {
        //A�������ꂽ��e�𐶐�
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
    }
}
