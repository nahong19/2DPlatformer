using UnityEngine;

public class Melon : MonoBehaviour
{
    public float timeAdd = 7;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.AddTime(timeAdd);
            GetComponent<Animator>().SetTrigger("Eaten");
            Invoke("DestroyThis", 0.3f);
        }
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

}
