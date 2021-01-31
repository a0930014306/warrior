
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    [Header("第二關傳送門")]
    public Transform teleport;
    

    private bool isplayer;
    private Transform player;

    private void Entermethod()
    {
        if (isplayer && Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.position = teleport.position + Vector3.up * 3.5f;
        }

    }

    private void Awake()
    {
        player = GameObject.Find("企鵝").transform;
    }

    private void Update()
    {
        Entermethod();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "企鵝") isplayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "企鵝") isplayer = false;
    }
}
