using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, items.Length);
        Instantiate(items[random], transform.position, Quaternion.identity);
    }
}
