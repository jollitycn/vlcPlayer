using JGNet.Core.InteractEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JGNet.Common
{
    class CostumeClassUtil
    {
        public static List<TreeNode> GetTreeNodes()
        {

            List<TreeNode> nodes = new List<TreeNode>();
            try
            {
                List<CostumeClassInfo> infos = CommonGlobalCache.ServerProxy.GetCostumeClassList();
                TreeNode rootNode = new TreeNode("所有商品");
                rootNode.ImageIndex = 0;
                rootNode.Expand();
                foreach (CostumeClassInfo item in infos)
                {
                    TreeNode level1 = new TreeNode(item.BigClass);
                    level1.ImageIndex = 1;
                    level1.Tag = item;
                    if (item.SmallClass != null)
                    {
                        foreach (SmallClass smallClass in item.SmallClass)
                        {
                            TreeNode level2 = new TreeNode(smallClass.SmallClassStr);
                            level2.ImageIndex = 2;
                            level2.Tag = smallClass;
                            foreach (SubSmallClass subSmallClass in smallClass.SubSmallClass)
                            {
                                TreeNode level3 = new TreeNode(subSmallClass.SubSmallClassStr);
                                level3.ImageIndex = 3;
                                level3.Tag = subSmallClass;
                                level2.Nodes.Add(level3);
                            }
                            level1.Nodes.Add(level2);
                        }
                    }
                    rootNode.Nodes.Add(level1);
                }
                nodes.Add(rootNode);
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
            return nodes;
        }
    }
}

