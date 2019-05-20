using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Premetive : MonoBehaviour
{
    public Sprite modelSprite;
    public PremetiveType modelType;
    public Transform parent;

    public Text info;

    public void OnChangePremitive(PremetiveType type)
    {
        foreach (Transform child in transform.parent)
        {
            if (child.GetComponent<Premetive>().modelType != type)
                child.gameObject.SetActive(false);

            else
                child.gameObject.SetActive(true);
        }
    }

    public void GetInfo()
    {
        Collider myCol = GetComponent<Collider>();
        info.text = string.Format("Name: {0} , Size: {1},Type: {2}" ,transform.name , myCol.bounds.ToString() ,modelType);
    }
}
