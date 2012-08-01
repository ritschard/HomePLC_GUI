using System;
using System.Collections.Generic;
using System.Text;

namespace HomePLC.Forms
{
    static class UICheckDispatcher
    {
        static private List<IUICheckable> fieldCheckableList = new List<IUICheckable>();

        static public void RegisterUICheckable(IUICheckable checkable)
        {
            fieldCheckableList.Add(checkable);
        }

        static public void TriggerCheckUI()
        {
            foreach (IUICheckable checkable in fieldCheckableList)
                checkable.FireCheckUI();
        }

        static public void UnregisterUICheckable(IUICheckable checkable)
        {
            fieldCheckableList.Remove(checkable);
        }

    }
}
