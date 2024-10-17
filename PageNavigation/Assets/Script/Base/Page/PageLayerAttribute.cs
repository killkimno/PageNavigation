using System;

namespace Script.Base.Page
{
    public class PageLayerAttribute : Attribute
    {
        public PageLayerType Layer { get; }

        public PageLayerAttribute(PageLayerType layer)
        {
            Layer = layer;
        }
    }
}
