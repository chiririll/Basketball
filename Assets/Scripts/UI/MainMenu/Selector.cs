using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Selector : MonoBehaviour
{
    // Public
    // Animation
    public bool Active = true;
    public AnimationCurve Curve;
    public float Speed = 1f;
    // Colors
    public Color NormalColor = new Color(1f, 0.5f, 0.1f);
    public Color SelectedColor = new Color(1f, 0f, 0f);

    // Private
    RectTransform _rt;
    Image _img;

    float _current = 0f;
    Vector3 _target_pos;
    Vector3 _start_pos;

    public void SetTarget(GameObject obj)
    {
        SetTarget(obj.GetComponent<RectTransform>().position.y);
    }

    public void SetTarget(float pos)
    {
        _current = 0;
        _start_pos = _rt.position;
        _target_pos.y = pos;
    }

    public void Select()
    {
        _img.color = SelectedColor;
    }

    public void Deselect()
    {
        _img.color = NormalColor;
    }

    void Start()
    {
        _rt = GetComponent<RectTransform>();
        _img = GetComponent<Image>();

        _img.color = NormalColor;

        _target_pos = new Vector3(0f, _rt.position.y, _rt.position.z);
        _start_pos = _target_pos;
    }

    void Update()
    {
        if (_current != 1)
            Move();
    }

    void Move()
    {
        if (!Active)
            return;

        _current = Mathf.MoveTowards(_current, 1, Time.deltaTime * Speed);
        _rt.SetPositionAndRotation(Vector3.Lerp(_start_pos, _target_pos, Curve.Evaluate(_current)), new Quaternion());
    }
}
