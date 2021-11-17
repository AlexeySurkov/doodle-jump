using System;
using System.Collections.Generic;

namespace Model
{
    public class ModelMainMenu
    {
        private int _selectedItem;
        private List<ModelMenuItem> _menuItemsList;

        public List<ModelMenuItem> MenuItemsList { get { return _menuItemsList; } set { _menuItemsList = value; } }

        public int SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (value >= 0 && ((int) value) < MenuItemsList.Count)
                {
                    _selectedItem = value;
                }
                else
                {
                    if (value < 0)
                    {
                        _selectedItem = MenuItemsList.Count - 1;
                    }
                    else
                    {
                        _selectedItem = 0;
                    }
                }
            }
        }

        public ModelMainMenu(List<ModelMenuItem> parMenuItemsList)
        {
            _menuItemsList = parMenuItemsList;
        }

        public void DoActualAction()
        {
            MenuItemsList[SelectedItem].Action();
        }
    }
}