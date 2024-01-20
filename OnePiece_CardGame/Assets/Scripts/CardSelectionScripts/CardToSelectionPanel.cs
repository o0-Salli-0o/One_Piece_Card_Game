using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CardToSelectionPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelCard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        panel = GameObject.Find("CardSelectionPanel");
        panelCard.transform.SetParent(panel.transform);
        panelCard.transform.localScale = Vector3.one;
        panelCard.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        panelCard.transform.eulerAngles = new Vector3(25, 0, 0);

    }
}
