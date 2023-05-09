using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public List<GameObject> bulletPrefabs;
    public Transform shootingPoint;
    public float bulletSpeed = 1000f;
    public float timefire = 0.5f;

    //player damage
    public GameObject player;

    private IEnumerator FireBullets()
    {
        while (true) // repeat forever
        {
            int randomBulletIndex = Random.Range(0, bulletPrefabs.Count); // choose a random bullet prefab from the list
            GameObject bullet = Instantiate(bulletPrefabs[randomBulletIndex], shootingPoint.position, bulletPrefabs[randomBulletIndex].transform.rotation); // spawn the selected bullet
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>(); // get the rigidbody component of the bullet
            bulletRigidbody.AddForce(shootingPoint.forward * bulletSpeed); // add force to the bullet in the direction of the shooting point
            yield return new WaitForSeconds(timefire); // wait for the specified time before firing the next bullet
        }
    }

    private void Start()
    {
        StartCoroutine(FireBullets()); // start the coroutine to fire bullets automatically
    }


}
