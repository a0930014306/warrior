
using UnityEngine;

public class enemymodetwo : MonoBehaviour
{
    [Header("第二階段攻擊力")]
    public float attack = 50;

    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<player>())
        {
            other.GetComponent<player>().Hurt(attack);

        }
    }
}
