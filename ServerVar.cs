using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tremulous_Server_Search
{
    public class ServerVar
    {
        public static List<Server> MasterList = new List<Server>();
        public string Name { get; private set; }
        public string Value { get; private set; }

        public ServerVar()
        {
            Name = "";
            Value = "";
        }

        public ServerVar(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public bool Empty()
        {
            return Name == "" && Value == "";
        }

        public override bool Equals(object obj)
        {
            if(!(obj is ServerVar))
                return false;
            ServerVar var = (ServerVar)obj;
            return var.Name == Name && var.Value == Value;
        }

        public static void Reset()
        {
            MasterList.Clear();
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
