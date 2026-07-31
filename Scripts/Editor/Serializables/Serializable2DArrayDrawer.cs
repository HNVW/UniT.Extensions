#nullable enable
namespace UniT.Extensions.Editor
{
    using UnityEditor;

    [CustomPropertyDrawer(typeof(Serializable2DArray<>), useForChildren: true)]
    [CustomPropertyDrawer(typeof(SerializeReference2DArray<>), useForChildren: true)]
    internal sealed class Serializable2DArrayDrawer : NestedPropertyDrawer
    {
        protected override string PropertyName => "rows";
    }

    [CustomPropertyDrawer(typeof(Serializable2DArray<>.Row), useForChildren: true)]
    [CustomPropertyDrawer(typeof(SerializeReference2DArray<>.Row), useForChildren: true)]
    internal sealed class Serializable2DArrayRowDrawer : NestedPropertyDrawer
    {
        protected override string PropertyName => "cells";
    }
}