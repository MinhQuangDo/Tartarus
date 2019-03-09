using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Display the items in a series of boxes
    [SerializeField] private List<GameObject> Items = new List<GameObject>();
    [SerializeField] private GameObject itemBox;

    public Transform firstItemBoxLocation;
    public float offsetX = 250f;

    public GameObject AddItem(SpriteRenderer itemSprite)
    {
        GameObject invObject;
        invObject = Instantiate(itemBox, new Vector3(firstItemBoxLocation.position.x + (Items.Count * offsetX), 
        firstItemBoxLocation.position.y, firstItemBoxLocation.position.z), this.transform.rotation, this.transform);
        invObject.SetActive(true);
        invObject.GetComponent<itemBox>().ChangeItemBox( itemSprite );
        Items.Add(invObject);
        return (invObject);
    }

    public void removeItem(GameObject toDelete)
    {

        if(toDelete == null)
        {
            return;
        }
        Items.Remove(toDelete);
        //Destroy(toDelete, 0.1f);
        toDelete.SetActive(false);
    }

    public void clearItems()
    {
        foreach( GameObject obj in Items)
        {
            obj.SetActive(false);
            
        }
        Items.Clear();
        Debug.Log("Clearing Items");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
