using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Songs : MonoBehaviour
{
    public AudioClip clip;
    [Range(0f, 4f)]
    public float volume;
    public bool loop;
    [HideInInspector]
    public AudioSource Source;
    
     
 
}
