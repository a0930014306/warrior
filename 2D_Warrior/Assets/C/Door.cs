using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("鑰匙")]
    public GameObject key;
    [Header("開門音效")]
    public AudioClip dooropen;

    private Animator ani;
    public AudioSource aud;

    private void Start()
    {
        ani = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "企鵝" && key == null) 
        {
            ani.SetTrigger("開門");
            aud.PlayOneShot(dooropen, Random.Range(1.2f, 1.5f));
        }
    }
}
