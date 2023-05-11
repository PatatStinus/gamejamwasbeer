using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public TMP_Text Punten;
    Collider[] colliders;
    Cannon cannon;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            print("hit");
            Destroy(collision.gameObject);
            score++;
        }
    }

    public void Update()
    {
        Punten.SetText(score.ToString());
    }
}
