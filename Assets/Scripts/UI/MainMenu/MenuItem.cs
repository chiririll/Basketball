using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    // Event
    public UnityEvent OnClick;

    // Selector
    public GameObject SelectorObj;
    Selector _sel;

    void Awake()
    {
        if (OnClick == null)
            OnClick = new UnityEvent();
    }

    void Start()
    {
        _sel = SelectorObj.GetComponent<Selector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _sel.SetTarget(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _sel.Select();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _sel.Deselect();
        if (EventSystem.current.IsPointerOverGameObject())
            OnClick.Invoke();
    }
}
