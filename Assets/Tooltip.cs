using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour {

    [Tooltip("This is the parent obejct to turn on and off")]
    public GameObject tooltipObject;
    [Tooltip("The text to change")]
    public Text toolTipText;
    public ITooltip current;
    RectTransform toolTipTransform;

	// Use this for initialization
	void Start () {
        toolTipTransform = tooltipObject.GetComponent<RectTransform>();
        tooltipObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        // look under the mouse for a tooltip source
        current = null;
        Vector2 pos = Input.mousePosition;
        GameObject go = GetObjectUnderPos(pos);
        if (go)
        {
            // found an object...
            current = go.GetComponent<ITooltip>();
            if (current != null)
            {
                tooltipObject.SetActive(true);

                // we need this to force a recalculation of the text size to propagate up to the parent frame
                toolTipText.text = "";
                // set the text to the tooltip one
                toolTipText.text = current.GetTip();
                // poisiton at the mouse
                toolTipTransform.position = go.transform.position;
                // make it point inwards to the centre of the screen
                toolTipTransform.pivot = new Vector2(pos.x > Screen.width / 2 ? 1 : 0, 
                    pos.y > Screen.height / 2 ? 1 : 0);
            }
        }
            

        // turn the tooltip on or off based on whether we have a thing under the mouse
        tooltipObject.SetActive(current != null);
	}

    // helper function for getting the UI pbject at a point
    List<RaycastResult> hitObjects = new List<RaycastResult>();
    GameObject GetObjectUnderPos(Vector3 position)
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = position;
        EventSystem.current.RaycastAll(pointer, hitObjects);
        return (hitObjects.Count <= 0) ? null : hitObjects[0].gameObject;
    }
}
