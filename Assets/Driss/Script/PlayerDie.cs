using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD:Assets/Driss/Script/deathPlayer.cs
public class DeathPlayer : MonoBehaviour
=======
public class PlayerDie : MonoBehaviour
>>>>>>> origin/Sjoerd:Assets/Driss/Script/PlayerDie.cs
{
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
