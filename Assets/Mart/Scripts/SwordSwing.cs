using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    Animator sAnimator;
    // Start is called before the first frame update
    void Start()
    {
        sAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                sAnimator.SetTrigger("TrSwordSwing");
            }
        }
    }
}
