using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatMouse : MonoBehaviour
{
    public Transform m_Transform;
    public Transform crosshair;
    public bool minus;
    void Start()
    {
        GameObject  target= GameObject.FindGameObjectWithTag("Crosshair");
        crosshair = target.gameObject.GetComponent<Transform>();
        m_Transform = this.transform;
    }

    public void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_Transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (crosshair.position.y >= 0 && crosshair.position.x >= 0)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle + crosshair.position.y, Vector3.forward);
            m_Transform.rotation = rotation;
        }
        else if (crosshair.position.y <= 0 && crosshair.position.x <= 0)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle + crosshair.position.y, Vector3.forward);
            m_Transform.rotation = rotation;
        }
        else if (crosshair.position.y <= 0 && crosshair.position.x >= 0)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle - crosshair.position.y, Vector3.forward);
            m_Transform.rotation = rotation;
        }
        else if (crosshair.position.y >= 0 && crosshair.position.x <= 0)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle - crosshair.position.y, Vector3.forward);
            m_Transform.rotation = rotation;
        }
    }
    // Update is called once per frame
    void Update()
    {
        LAMouse();
    }
}
