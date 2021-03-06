﻿namespace DEA.Common.Extensions
{
    public static class ObjectExtension
    {
        public static string Boldify(this object obj)
        {
            return $"**{obj.ToString().Replace("*", string.Empty).Replace("_", " ").Replace("~", string.Empty).Replace("`", string.Empty)}**";
        }
    }
}
