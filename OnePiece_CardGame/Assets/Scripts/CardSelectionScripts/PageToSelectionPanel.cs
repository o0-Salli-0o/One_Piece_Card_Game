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
        //parent = this.gameObject.transform.parent.gameObject;
        //parent = GetComponent<GameObject>().gameObject;
        parent = GameObject.Find("CardSelectionPanel");
        pagePrefab.transform.SetParent(parent.transform);
        pagePrefab.SetActive(true);
        pagePrefab.transform.localScale = Vector3.one;
        pagePrefab.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        pagePrefab.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
