using System;

namespace Script.Base.Page
{
    public class PageTransparentAttribute : Attribute
    {
        public bool IsTransparent { get; }

        public PageTransparentAttribute(bool isTransparent)
        {
            IsTransparent = isTransparent;
        }
    }
}