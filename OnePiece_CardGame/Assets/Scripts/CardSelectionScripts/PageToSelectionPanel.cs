using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageToSelectionPanel : MonoBehaviour
{
    private GameObject parent;
    public GameObject pagePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*parent = GameObject.Find("CardSelectionPanel");
        pagePrefab.transform.SetParent(parent.transform);
        pagePrefab.SetActive(true);
        pagePrefab.transform.localScale = Vector2.one;
        pagePrefab.transform.position = new Vector2(transform.position.x, transform.position.y);
        pagePrefab.transform.eulerAngles = new Vector2(25, 0);*/
    }
}
