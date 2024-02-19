using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSound : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
