using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 1000f;
    public float timefire = 0.5f;

    private IEnumerator FireBullets()
    {
        while (true) // repeat forever
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation); // spawn want de bullet
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); // get the rigidbody component of the bullet
            bulletRigidbody.AddForce(shootingPoint.forward * bulletSpeed); // add force to the bullet in the direction of the shooting point
            yield return new WaitForSeconds(timefire); // de tijd tussen de bullet
        }
    }

    private void Start()
    {
        StartCoroutine(FireBullets()); // start the coroutine to fire bullets automatically
    }
}
