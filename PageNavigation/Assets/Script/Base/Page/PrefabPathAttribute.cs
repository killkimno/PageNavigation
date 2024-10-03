using System;

namespace Script.Base.Page
{
    public class PrefabPathAttribute : Attribute
    {
        private string _path;
        public string Path => _path;  

        public PrefabPathAttribute(string path)
        {
            _path = path;
        }      
    }
}
