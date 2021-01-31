
using UnityEngine;

public class boss : MonoBehaviour
{
    [Header("魔王血條")]
    public GameObject objhp;
    [Header("魔王")]
    public GameObject objboss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "企鵝")
        {
            objhp.SetActive(true);
            objboss.SetActive(true);

        }
    }
}
