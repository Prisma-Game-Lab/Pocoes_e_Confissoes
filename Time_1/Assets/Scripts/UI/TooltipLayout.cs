using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class TooltipLayout : MonoBehaviour
{
    public Text header;
    public Text content;
    public LayoutElement layout;
    public int charLim;

    public RectTransform rectTransform;

    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string Content, string Header = "")
    {
        if (string.IsNullOrEmpty(Header))
        {
            header.gameObject.SetActive(false);
        } else
        {
            header.gameObject.SetActive(true);
            header.text = Header;
        }

        content.text = Content;

        int headerLen = header.text.Length;
        int contentLen = content.text.Length;

        layout.enabled = (headerLen > charLim || contentLen > charLim) ? true : false;
    }

    // Update is called once per frame
    private void Update()
    {
        //float offset = 0;
        Vector2 position = Input.mousePosition;

        //if 

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        //rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = new Vector2(position.x - 10f, position.y + 10f);
        //Debug.Log(position.x);
    }
}
