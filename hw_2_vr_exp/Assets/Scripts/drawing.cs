using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using VRTK;

public class drawing : MonoBehaviour
{

    public VRTK_ControllerEvents vrtkController;
    public VRTK_InteractableObject interactableChalk;
    public LineRenderer lineRenderer;
    public GameObject chalk;
    bool isDrawing = false;
    bool isGrabbed = false;
   

    // Start is called before the first frame update
    void Start()
    {
        vrtkController.TriggerPressed += _TriggerPressed;
        vrtkController.TriggerReleased += _TriggerReleased;
        interactableChalk.InteractableObjectGrabbed += _InteractableObjectGrabbed;
        interactableChalk.InteractableObjectUngrabbed += _InteractableObjectUngrabbed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed && isDrawing)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, chalk.transform.position);
        }
    }

    void _TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        isDrawing = true;
    }

    void _TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        isDrawing = false;
    }

    void _InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = true;
    }
    void _InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = false;
    }
}
