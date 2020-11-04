using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    public float interactionRadius = 1;
    public float visibilityRadius = 3;
    public bool interactionEnabled = true;

    private GameObject indicatorFar;
    private GameObject indicatorClose;
    private GameObject player;
    private Vector3 playerPosition;
    private float distance;
    private Vector3 worldToScreenPoint;
    private Renderer render;


    void Start()
    {
        render = gameObject.GetComponentsInChildren<Renderer>().First();
        player = FindObjectOfType<PlayerController>().gameObject;
        var indidatorPrefabFar = Resources.Load("prefabs/Canvas/IndicatorFar");
        var indidatorPrefabClose = Resources.Load("prefabs/Canvas/IndicatorClose");

        indicatorFar = (GameObject)Instantiate(indidatorPrefabFar);
        indicatorFar.SetActive(false);
        indicatorFar.transform.SetParent(FindObjectOfType<Canvas>().transform, false);

        indicatorClose = (GameObject)Instantiate(indidatorPrefabClose);
        indicatorClose.SetActive(false);
        indicatorClose.transform.SetParent(FindObjectOfType<Canvas>().transform, false);
    }

    void Update()
    {
        playerPosition = player.transform.position;
        distance = Vector3.Distance(playerPosition, transform.position);

        if (distance < visibilityRadius && interactionEnabled && IsVisibleToPlayer())
        {
            worldToScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

            if (distance < interactionRadius)
            {
                indicatorClose.transform.position = worldToScreenPoint;
                indicatorClose.SetActive(true);
                indicatorFar.SetActive(false);
            } else
            {
                indicatorFar.transform.position = worldToScreenPoint;
                indicatorFar.SetActive(true);
                indicatorClose.SetActive(false);
            }
        } else
        {
            indicatorClose.SetActive(false);
            indicatorFar.SetActive(false);
        }
    }

    public void Disable()
    {
        indicatorClose.SetActive(false);
        indicatorFar.SetActive(false);
        interactionEnabled = false;
    }

    public bool CanInteract() => distance < interactionRadius && interactionEnabled && indicatorClose.activeSelf;

    // It check all cameras. Editor camera too!. So be careful while testing shit ;)
    private bool IsVisibleToPlayer() => render.isVisible;
}
