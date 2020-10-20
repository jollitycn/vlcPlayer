namespace CJBasic.ObjectManagement.Trees.Binary
{
    using System;
    using System.Drawing;

    public interface IBinaryTreeDrawer<TVal> where TVal: IComparable
    {
        void DrawBinaryTree(IBinaryTree<TVal> tree, int offsetLeft, int offsetHigh);
        Size GetCanvasSize(int binaryTreeDepth, int radius);
        void Initialize(DrawerParas paras);
        void ResetGraphic(Graphics g);
        void Zoom(double coeff);

        int Radius { get; }
    }
}

