using System;
using System.Collections.Generic;
using Shion.Ast;

namespace Shion
{
    public class Scope
    {
        public Scope()
        {
            Arguments = new Dictionary<string, object>();
            VarSet = new Dictionary<string, object>();
            ThisSet = new Dictionary<string, object>();
            FunctionSet = new Dictionary<string, object>();
        }

        public bool IsGlobal { get; set; }

        private Dictionary<string, object> Arguments { get; set; }
        private Dictionary<string, object> VarSet { get; set; }
        private Dictionary<string, object> ThisSet { get; set; }
        private Dictionary<string, object> FunctionSet { get; set; }

        public void SetArgument(string key, object value)
        {
            this.Arguments[key] = value;
        }

        public void SetVar(string key, object value)
        {
            if (value is Identifier)
                ((Identifier) value).IsMember = true;

            this.VarSet[key] = value;
            if (IsGlobal)
            {
                this.ThisSet[key] = value;
            }
        }

        public void SetThis(string key, object value)
        {
            if (value is Identifier)
                ((Identifier)value).IsMember = true;

            this.ThisSet[key] = value;
            if (IsGlobal)
            {
                this.VarSet[key] = value;
            }
        }

        public void SetFunction(string key, object value)
        {
            this.FunctionSet[key] = value;
        }

        public dynamic Get(string key)
        {
            return Get(key, false);
        }

        private bool GetArgument(string key, ref dynamic value, bool isMemberInvoke)
        {
            if (Arguments.ContainsKey(key) && (!isMemberInvoke || IsGlobal))
            {
                value = Arguments[key];
                return true;
            }

            return false;
        }

        private bool GetVar(string key, ref dynamic value, bool isMemberInvoke)
        {
            if (VarSet.ContainsKey(key) && (!isMemberInvoke || IsGlobal))
            {
                value = VarSet[key];
                return true;
            }

            return false;
        }

        private bool GetThis(string key, ref dynamic value, bool isMemberInvoke)
        {
            if (ThisSet.ContainsKey(key) /*&& isMemberInvoke*/)
            {
                value = ThisSet[key];
                return true;
            }

            return false;
        }

        private bool GetFunction(string key, ref dynamic value, bool isMemberInvoke)
        {
            if (FunctionSet.ContainsKey(key) /*&& isMemberInvoke*/)
            {
                value = FunctionSet[key];
                return true;
            }

            return false;
        }

        public dynamic Get(string key, bool isMemberInvoke)
        {
            dynamic val = null;

            var ok = false;

            ok = GetArgument(key, ref val, isMemberInvoke);

            if (!ok)
            {
                ok = GetVar(key, ref val, isMemberInvoke);
            }
            if (!ok)
            {
                ok = GetThis(key, ref val, isMemberInvoke);
            }
            if (!ok)
            {
                ok = GetFunction(key, ref val, isMemberInvoke);
            }

            if(!ok)
                throw new ReferenceError(key);

            return Util.GetValue(val);
        }

        public dynamic Handle(string key, dynamic value)
        {
            return Handle(key, false, value);
        }

        public dynamic Handle(string key, bool isMemberInvoke, dynamic value)
        {
            if (Arguments.ContainsKey(key) && (!isMemberInvoke || IsGlobal))
            {
                SetArgument(key, value);
                return value;
            }
            else if (VarSet.ContainsKey(key) && (!isMemberInvoke || IsGlobal))
            {
                SetVar(key, value);
                return value;
            }
            else if (ThisSet.ContainsKey(key))
            {
                SetThis(key, value);
                return value;
            }
            else if (!ThisSet.ContainsKey(key))
            {
                SetThis(key, value);
                return value;
            }
            else
                throw new ReferenceError(key);
        }

        public void CloneVarSet(Scope newScope)
        {
            foreach (var m in VarSet) { newScope.VarSet[m.Key] = m.Value; }
        }

        public void CloneThisSet(Scope newScope)
        {
            foreach (var m in ThisSet) { newScope.ThisSet[m.Key] = m.Value; }
        }

        public void CloneFunctionSet(Scope newScope)
        {
            foreach (var m in FunctionSet) { newScope.FunctionSet[m.Key] = m.Value; }
        }

        public dynamic GetThisValue(string prop)
        {
            return ThisSet.ContainsKey(prop) ? ThisSet[prop] : new Undefined();
        }
    }
}