using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CardToSelectionPanel : MonoBehaviour
{
    public GameObject parent;
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //parent = this.GameObject().transform.parent.GameObject();
        //parent = this.gameObject.transform.parent.transform.gameObject;
        //parent = this.GameObject();
        //parent = GameObject.Find("CardSelectionPage(Clone)");
        //cardPrefab.transform.SetParent(parent.transform);
        cardPrefab.transform.localScale = Vector3.one;
        cardPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        cardPrefab.transform.eulerAngles = new Vector3(25, 0, 0);
        //parent.name = "Page";

    }
}
