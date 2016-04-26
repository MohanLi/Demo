using UnityEngine;
using System.Collections;

public class PanelBase : BaseUI 
{
    protected void Close()
    {
        Destroy(this.gameObject);
    }
}
