using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;

    void Update()
    {
        //A‚ª‰Ÿ‚³‚ê‚½‚ç’e‚ğ¶¬
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
    }
}
