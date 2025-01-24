using UnityEngine;

public class Capture : MonoBehaviour
{
    private string tag;
    private string checkTag;
    void Start()
    {

        tag = gameObject.tag;
    }

    void OnTriggerEnter(Collider other)
    {
        checkTag = other.tag;
        if(tag != checkTag)
        {
            Destroy(other.gameObject);
        }
        Debug.Log("hit");
    }
}