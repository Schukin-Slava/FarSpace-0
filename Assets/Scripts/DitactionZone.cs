using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DitactionZone : MonoBehaviour
{
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    Collider2D col;
    // Start is called before the first frame update
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColliders.Add(collision);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        detectedColliders.Remove(collision);
    }

}
