using System;

namespace Script.Base.Page
{
    public class PageLayerAttribute : Attribute
    {
        public int Layer { get; }

        public PageLayerAttribute(int layer)
        {
            Layer = layer;
        }
    }
}
