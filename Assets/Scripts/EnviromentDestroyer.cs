using UnityEngine;
using System.Collections;

public class EnviromentDestroyer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D _collider)
    {
        if(_collider.gameObject.tag == "Bullet" || _collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
