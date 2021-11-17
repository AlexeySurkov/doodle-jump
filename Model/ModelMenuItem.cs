using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelMenuItem
    {
        public delegate void DoAction();
        public DoAction Action;
        private string _content;

        public string Content { get { return _content; } set { _content = value; } }

        public ModelMenuItem(string parContent, DoAction parDoAction)
        {
            Content = parContent;
            Action = parDoAction;
        }
    }
}
