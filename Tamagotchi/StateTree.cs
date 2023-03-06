using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tamagotchi
{
    internal class StateTree
    {
        public StateNode root { get; set; }
    }

    internal class StateNode
    {
        public StateNode AButton { get; set; }
        public StateNode BButton { get; set; }
        public StateNode CButton { get; set; }
        public StateNode parentNode { get; set; }
        public string name { get; set; }
        public List<Action> initialFunctionList = new List<Action>();

        public List<Action> AButtonFunctionList = new List<Action>();
        public List<Action> BButtonFunctionList = new List<Action>();
        public List<Action> CButtonFunctionList = new List<Action>();
    }
}
