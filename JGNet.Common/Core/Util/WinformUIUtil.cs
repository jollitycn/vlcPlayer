using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JGNet.Common.Core.Util
{
    public class WinformUIUtil
    {
        private static List<TreeNode> trees;
        public static List<TreeNode> GetAllTreeNodes(List<TreeNode> sourceNodes)
        {
            if (trees == null)
            {
                List<TreeNode> nodes = new List<TreeNode>();
                if (sourceNodes != null)
                {
                    foreach (TreeNode node in sourceNodes)
                    {
                        nodes.Add(node);
                        if (node.Nodes != null && node.Nodes.Count > 0)
                        {
                            nodes.AddRange(GetAllTreeNodes(node.Nodes));
                        }
                    }
                }
                trees = nodes;
            }

            return trees;
        }

        public static List<TreeNode> GetAllTreeNodes(TreeNodeCollection sourceNodes)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            if (sourceNodes != null)
            {
                foreach (TreeNode node in sourceNodes)
                { 
                    nodes.Add(node);
                    if (node.Nodes != null && node.Nodes.Count > 0)
                    {
                        nodes.AddRange(GetAllTreeNodes(node.Nodes));
                    }
                }
            }

            return nodes;
        }

        public static TreeNode[] NewTreeNodes(params String[] names)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var name in names)
            {
                nodes.Add(new TreeNode(name));
            }
            return nodes.ToArray();
        }

        public static TreeNode NewTreeNode(String headerName, params String[] names)
        {
            TreeNode node = new TreeNode(headerName, NewTreeNodes(names));
            return node;
        }

        public static TreeNode NewTreeNode(String headerName, params TreeNode[] names)
        {
            TreeNode node = new TreeNode(headerName, names);
            return node;
        }
    }
}
