using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cock : MonoBehaviour
{
    public bool On;
    public AudioSource Audio;

    public void OnTriggerEnter(Collider other) {
        if (On) {
            Audio.Play();
        } else {
            Audio.Stop();
        }
    }
}
