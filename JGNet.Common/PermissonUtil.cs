using JGNet.Common;
using JGNet.Common.Components;
using JGNet.Common.Core;
using JGNet.Common.Core.Util;
using JGNet.Core.Const;
using JGNet.Core.InteractEntity;
using JGNet.Core.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JGNet.Common
{
    public class PermissonUtil
    {
        private static void CheckDataGridViewReadonlyPermissons(Control control)
        {
            try
            {
                List<DataGridView> buttons = CommonGlobalUtil.GetControls<DataGridView>(control);
                List<RolePermissionEnum> permissons = EnumHelper.GetEnumList<RolePermissionEnum>();
                if (permissons != null)
                {
                    foreach (RolePermissionEnum p in permissons)
                    {
                        foreach (DataGridView item in buttons)
                        {
                            foreach (DataGridViewColumn column in item.Columns)
                            {
                                if (p == RolePermissionEnum.编辑)
                                {
                                    if (!(column is DataGridViewLinkColumn))
                                    {
                                        if (!HasPermission(control, p))
                                        {
                                            column.ReadOnly = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private static void CheckDataGridViewVisiblePermissons(Control control)
        {
            try
            {
                List<DataGridView> buttons = CommonGlobalUtil.GetControls<DataGridView>(control);
                List<RolePermissionEnum> permissons = EnumHelper.GetEnumList<RolePermissionEnum>();
                if (permissons != null)
                {
                    foreach (RolePermissionEnum p in permissons)
                    {
                        String desc = EnumHelper.GetDescription(p);
                        foreach (DataGridView item in buttons)
                        {
                            foreach (DataGridViewColumn column in item.Columns)
                            {
                                String headerText = column.HeaderText;
                                if (headerText == "总成本")
                                {
                                  

                                        headerText = EnumHelper.GetDescription(RolePermissionEnum.查看_成本价);
                                    //}
                                }
                                //else if (headerText == "禁用" || headerText == "启用")
                                //{
                                //    headerText = EnumHelper.GetDescription(RolePermissionEnum.编辑);
                                //}

                                if (headerText == desc)
                                {
                                    if (!(column is DataGridViewLinkColumn))
                                    {
                                        if (((int)p).ToString().StartsWith(((int)RolePermissionEnum.查看).ToString()))
                                        {
                                            if (!HasPermission(control, p))
                                            {
                                                if (item.Tag == null)
                                                {
                                                    column.Visible = false;
                                                }
                                                else if (item.Tag is DataGridViewPagingSumCtrl)
                                                {
                                                    ((DataGridViewPagingSumCtrl)(item.Tag)).AppendNotShowInColumnSettings(column);

                                                }
                                            }
                                            else
                                            {
                                                if (item.Tag != null && ((DataGridViewPagingSumCtrl)(item.Tag)).IsPageSet == true && ((DataGridViewPagingSumCtrl)(item.Tag)).DataGridView.Columns[column.Name].Visible == false)
                                                {
                                                    //((DataGridViewPagingSumCtrl)(item.Tag)).DataGridView.Columns[column.Name].Visible=false 
                                                    //column.Name==
                                                }
                                                else
                                                {
                                                    column.Visible = true;
                                                }
                                            }
                                        }
                                        if (HasPermission(control, RolePermissionEnum.查看_只看本店) && column.HeaderText == "店铺")
                                        {
                                            if (item.Tag == null)
                                            {
                                                column.Visible = false;
                                            }
                                            else if (item.Tag is DataGridViewPagingSumCtrl)
                                            {
                                                ((DataGridViewPagingSumCtrl)(item.Tag)).AppendNotShowInColumnSettings(column);
                                            }
                                            else
                                            {
                                                column.Visible = true;
                                            }
                                        }


                                       /*if (HasPermission(control, RolePermissionEnum.查看_毛利) && column.HeaderText == "毛利")
                                        {
                                            if (item.Tag == null)
                                            {
                                                column.Visible = false;
                                            }
                                            else if (item.Tag is DataGridViewPagingSumCtrl)
                                            {
                                                foreach (DataGridViewColumn MLcolumn in item.Columns)
                                                {
                                                    if (MLcolumn.HeaderText == "毛利率")
                                                    {
                                                        ((DataGridViewPagingSumCtrl)(item.Tag)).AppendNotShowInColumnSettings(column);
                                                    }
                                                }
                                                   
                                            }
                                            else
                                            {
                                                column.Visible = true;
                                            }
                                        }*/

                                    }
                                }
                                else
                                {
                                    //被禁用字段

                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private static void CheckShopComboBoxPermissons(Control control)
        {
            try
            {
                List<ShopComboBox> items = CommonGlobalUtil.GetControls<ShopComboBox>(control);
                List<RolePermissionEnum> permissons = EnumHelper.GetEnumList<RolePermissionEnum>();
                if (permissons != null)
                {
                    foreach (ShopComboBox item in items)
                    {
                        if (HasPermission(control, RolePermissionEnum.查看_只看本店))
                        {
                            if (item.Tag != null && item.Tag is RolePermissionMenuEnum && (((RolePermissionMenuEnum)item.Tag) == RolePermissionMenuEnum.不限))
                            {
                            }
                            else
                            {
                                //if(control.MenuPermission = 调拨单查询)
                                /*  BaseUserControl form = control as BaseUserControl;
                                  if (form.MenuPermission == RolePermissionMenuEnum.调拨单查询)
                                  {

                                  }
                                  else
                                  {*/
                                item.Enabled = false;
                                item.SelectedValue = CommonGlobalCache.CurrentShopID;
                                //  }
                            }
                        }
                        else
                        {
                            BaseUserControl form = control as BaseUserControl;
                            if (form.MenuPermission == RolePermissionMenuEnum.调拨单查询)
                            {

                            }
                        }

                    }
                }
            }
            catch { }
        }
        private static void CheckBrandComboBoxPermissons(Control control)
        {
            try
            {
                List<BrandComboBox> items = CommonGlobalUtil.GetControls<BrandComboBox>(control);
                List<RolePermissionEnum> permissons = EnumHelper.GetEnumList<RolePermissionEnum>();
                if (permissons != null)
                {
                    foreach (BrandComboBox item in items)
                    {
                        if (!HasPermission(control, RolePermissionEnum.查看_品牌))
                        {
                            if (item.Tag != null && item.Tag is RolePermissionMenuEnum && (((RolePermissionMenuEnum)item.Tag) == RolePermissionMenuEnum.不限))
                            {
                            }
                            else
                            {
                                item.Enabled = false; 
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private static void CheckBoxPermissons(Control control)
        {
            try
            {
                List<CheckBox> buttons = CommonGlobalUtil.GetControls<CheckBox>(control);
                List<RolePermissionEnum> permissons = EnumHelper.GetEnumList<RolePermissionEnum>();
                if (permissons != null)
                {
                    foreach (CheckBox item in buttons)
                    {
                        foreach (RolePermissionEnum p in permissons)
                        {
                            if (item.Text.Equals( EnumHelper.GetDescription(p)))
                            {
                                item.Tag = p;

                                item.Enabled = HasPermission(control, p);

                            }

                            if (p == RolePermissionEnum.打印)
                            {
                                if (item.Text.Equals( "打印小票") || item.Text.Equals( "打印条码"))
                                {
                                    item.Tag = p;
                                    item.Enabled = HasPermission(control, p);
                                }
                            }
                            else if (p == RolePermissionEnum.查看_成本价)
                            {
                                if (item.Text.Equals("显示成本"))
                                {
                                    item.Tag = p;
                                      
                                    item.Enabled = HasPermission(control, p);
                                }

                            }
                        }
                    }
                }
            }
            catch { }
        }
        public static void CheckPermissons(Control baseUserControl)
        {
            CheckButtonPermissons(baseUserControl);
            CheckShopComboBoxPermissons(baseUserControl);
            CheckBrandComboBoxPermissons(baseUserControl);
            CheckDataGridViewVisiblePermissons(baseUserControl);
            CheckContextMenuStripPermissons(baseUserControl);
            
            CheckDataGridViewReadonlyPermissons(baseUserControl);
            CheckBoxPermissons(baseUserControl);
        }
        
        private static void CheckContextMenuStripPermissons(Control control)
        {
            try
            {
                List<ContextMenuStrip> buttons = CommonGlobalUtil.GetContextMenuStrips(control);
                List<RolePermissionEnum> permissons = EnumHelper.GetEnumList<RolePermissionEnum>();
                if (permissons != null)
                {
                 
                        foreach (ContextMenuStrip strip in buttons)
                    {
                        foreach (ToolStripItem item in strip.Items)
                        {
                            foreach (RolePermissionEnum p in permissons)
                            {
                                String desc = EnumHelper.GetDescription(p);
                                if (item.Text.Equals(desc)  && p != RolePermissionEnum.取消)
                                {
                                    item.Tag = p;
                                    item.Enabled = HasPermission(control, p);
                                }

                                if (p == RolePermissionEnum.编辑)
                                {
                                    if (item.Text.Equals("新增子类"))
                                    {
                                        item.Tag = p;
                                        item.Enabled = HasPermission(control, p);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        private static bool IsGlobalPermisson(RolePermissionEnum p)
        {
            return (p == RolePermissionEnum.查看_品牌 || p == RolePermissionEnum.查看_成本价);
        }

        private static void CheckButtonPermissons(Control control)
        {
            try
            {
                List<BaseButton> buttons = CommonGlobalUtil.GetControls<BaseButton>(control);
                List<RolePermissionEnum> permissons = EnumHelper.GetEnumList<RolePermissionEnum>();
                if (permissons != null)
                {
                    foreach (BaseButton item in buttons)
                    {
                        foreach (RolePermissionEnum p in permissons)
                        {
                            if (item.Text.Equals( EnumHelper.GetDescription(p)) && p != RolePermissionEnum.取消)
                            {
                                item.Tag = p;
                                item.Enabled = HasPermission(control, p);
                            } 
                            else if (p == RolePermissionEnum.编辑)
                            {
                                if (item.Text.Equals( "录入完毕") || item.Text.Equals("保存" )|| item.Text.Equals("添加" )|| item.Text.Equals("设置"))
                                {
                                    item.Tag = p;
                                    item.Enabled = HasPermission(control, p);
                                }
                            }
                            else if (p == RolePermissionEnum.导入)
                            {
                                if (item.Text.Equals("下载模板"))
                                {
                                    item.Tag = p;
                                    item.Enabled = HasPermission(control, p);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonGlobalUtil.ShowError(ex);
            }
        }

        public static bool HasPermission(RolePermissionMenuEnum menu, RolePermissionEnum p)
        {
            bool result = false;
            if (menu == RolePermissionMenuEnum.不限 && !IsGlobalPermisson(p))
            {
                result = true;
            }
            else
            {
                result = HasPermissonPrivate(menu, p);
            }
            return result;
        }

        public static bool HasPermission(Control control, RolePermissionEnum p)
        {
            bool result = false;
            if (control is BaseForm)
            {
                BaseForm form = control as BaseForm;
                if (form.MenuPermission == RolePermissionMenuEnum.不限 && !IsGlobalPermisson(p))
                {
                    result = true;
                }
                else
                {
                    result = HasPermissonPrivate(form.MenuPermission, p);
                }
            }
            else if (control is BaseUserControl)
            {
                BaseUserControl form = control as BaseUserControl;
                if (form.MenuPermission == RolePermissionMenuEnum.不限 && !IsGlobalPermisson(p))
                {
                    result = true;
                }
                else
                {
                    result = HasPermissonPrivate(form.MenuPermission, p);
                }
            }

            return result;
        }

        private static bool HasPermissonPrivate(RolePermissionMenuEnum menuPermission, RolePermissionEnum permiss)
        {
            string permisson = string.Empty + (int)menuPermission + (int)permiss;
            if (IsGlobalPermisson(permiss))
            {
                permisson = string.Empty + (int)permiss;
            }

            UserInfo user = CommonGlobalCache.CurrentUser;
            bool hasPermisson = false;
            List<TreeNode> treeNodes = WinformUIUtil.GetAllTreeNodes(PermissonUtil.GetTreeNodes());
            TreeNode node = GetTreeNode(treeNodes, menuPermission);
            if (node != null)
            {
                if (!HasPermissonInNodes(node, permiss))
                {
                    if (permiss == RolePermissionEnum.查看_只看本店)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            List<int> permissons = user.RolePermissions;

            if (permissons == null)
            {
                if (permiss == RolePermissionEnum.查看_只看本店)
                {
                    hasPermisson = false;
                }
                else if (permiss != RolePermissionEnum.查看
                    && ((int)permiss).ToString().StartsWith(((int)RolePermissionEnum.查看).ToString()))
                {
                    if (IsGlobalPermisson(permiss) || (menuPermission == RolePermissionMenuEnum.畅滞排行榜 && permiss == RolePermissionEnum.查看_备注)|| (menuPermission == RolePermissionMenuEnum.销售分析 && permiss == RolePermissionEnum.查看_毛利) || (menuPermission == RolePermissionMenuEnum.商品档案 && permiss == RolePermissionEnum.查看_备注))
                    {
                        hasPermisson = true;
                    }
                    else
                    {
                        hasPermisson = false;
                    }
                }
                else
                {
                    hasPermisson = true;
                }
                //没有权限
            }
            else if (permissons.Count == 0)
            {
            }
            else
            {
                //销售退货单查询
                if (permissons.Contains(int.Parse(permisson)))
                {
                    hasPermisson = true;
                }
            }

            return hasPermisson;
        }
        private static bool HasPermissonInNodes(TreeNode node, RolePermissionEnum permiss)
        {
            bool has = false;

            if (IsGlobalPermisson(permiss))
            {
                return true;
            }
            TreeNode temp = node;

            if (temp != null)
            {
                if (temp.Tag is RolePermissionEnum)
                {
                    if ((RolePermissionEnum)temp.Tag == permiss)
                    {
                        has = true;
                    }
                    else
                    {
                        if (temp.Nodes != null && temp.Nodes.Count > 0)
                        {
                            foreach (TreeNode item in temp.Nodes)
                            {
                                has = HasPermissonInNodes(item, permiss);
                                if (has)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (temp.Nodes != null && temp.Nodes.Count > 0)
                    {
                        foreach (TreeNode item in temp.Nodes)
                        {
                            has = HasPermissonInNodes(item, permiss);
                            if (has)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            //while ()
            //{
            //    if (temp != null && temp.Nodes != null && temp.Nodes.Count > 0)
            //    {
            //        foreach (TreeNode item in temp.Nodes)
            //        {
            //            temp = item;
            //            if (temp.Tag is RolePermissionEnum)
            //            {
            //                if (permiss == (RolePermissionEnum)temp.Tag)
            //                {
            //                    has = HasPermissonInNodes(temp, permiss);
            //                    if (has) { return has; }
            //                    break;
            //                }
            //            }
            //        }
            //    } 
            //}
            return has;
        }
        private static TreeNode GetTreeNode(List<TreeNode> treeNodes, RolePermissionMenuEnum menuPermission)
        {
            return treeNodes.Find(t => t.Tag != null && t.Tag is RolePermissionMenuEnum && (RolePermissionMenuEnum)t.Tag == menuPermission);
        }
        public static Boolean HasMenuPermisson(UserInfo user, object tabTag)
        {
            RolePermissionMenuEnum value = RolePermissionMenuEnum.无;
            if (tabTag != null)
            {
                if (tabTag is RolePermissionMenuEnum)
                {
                    value = (RolePermissionMenuEnum)tabTag;
                }
                else
                {
                    value = GetMenuPermisson(tabTag.ToString());
                }
            }
            if (value == RolePermissionMenuEnum.工作台 || value == RolePermissionMenuEnum.退出)
            {
                return true;
            }

            if (value == RolePermissionMenuEnum.无)
            {
                return false;
            }



            List<TreeNode> permissonNodes = CommonGlobalCache.Permissons;
            if (permissonNodes.Find(t => t.Tag != null && (RolePermissionMenuEnum)t.Tag == value) == null)
            {
                //管理员
                if (value == RolePermissionMenuEnum.管理员 && user.ID != SystemDefault.DefaultAdmin)
                {
                    return false;
                }

                return true;
            }



            bool hasPermisson = false;
            List<int> permissons = user.RolePermissions;
            if (permissons == null)
            {
                hasPermisson = true;
            }
            else if (permissons.Count == 0)
            {

            }
            else
            {
                int i = 0;
                int.TryParse(String.Empty + (int)value + (int)RolePermissionEnum.查看, out i);
                // int v = (int)value;
                //是否有查看权限，但是他可能只是简单菜单，这个时候也是返回false，
                //false  没有权限或者是普通菜单，但是普通菜单不需要作这个判断
                // bool canSee = permissons.Contains(i);
                bool isMenu = permissons.Contains(i);
                if (isMenu)
                {
                    hasPermisson = true;
                }
            }

            return hasPermisson;
        }

        private static RolePermissionMenuEnum GetMenuPermisson(string name)
        {
            RolePermissionMenuEnum value = RolePermissionMenuEnum.无;
            List<RolePermissionMenuEnum> enums = EnumHelper.GetEnumList<RolePermissionMenuEnum>();
            foreach (RolePermissionMenuEnum item in enums)
            {
                if (EnumHelper.GetDescription(item) == name)
                {
                    value = item;
                    break;
                }

            }
            return value;
        }


        public static TreeNode NewTreeNode(RolePermissionEnum menu)
        {
            TreeNode node = new TreeNode(EnumHelper.GetDescription(menu));
            node.Tag = menu;
            return node;
        }

        public static TreeNode NewTreeNode(RolePermissionMenuEnum menu)
        {
            TreeNode node = new TreeNode(EnumHelper.GetDescription(menu));
            node.Tag = menu;
            return node;
        }

        private static TreeNode NewTreeNode(RolePermissionMenuEnum menu, params TreeNode[] treeNode)
        {
            TreeNode node = new TreeNode(EnumHelper.GetDescription(menu), treeNode);
            node.Tag = menu;
            return node;
        }

        private static TreeNode NewTreeNode(RolePermissionEnum menu, params TreeNode[] treeNode)
        {
            TreeNode node = new TreeNode(EnumHelper.GetDescription(menu), treeNode);
            node.Tag = menu;
            return node;
        }

        public static List<TreeNode> GetTreeNodes()
        {
            List<TreeNode> nodes = new List<TreeNode>();

            #region 设置
            TreeNode treeNode1RuleSetting = NewTreeNode(RolePermissionMenuEnum.规则设置, new TreeNode[] {
            NewTreeNode(RolePermissionMenuEnum.优惠券设置,new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
                NewTreeNode(RolePermissionEnum.编辑),
                NewTreeNode(RolePermissionEnum.删除)
            }),
            NewTreeNode(RolePermissionMenuEnum.促销规则 ,new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
                NewTreeNode(RolePermissionEnum.编辑),
                NewTreeNode(RolePermissionEnum.删除) }),
            NewTreeNode(RolePermissionMenuEnum.充值规则,new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
                NewTreeNode(RolePermissionEnum.编辑),
                NewTreeNode(RolePermissionEnum.删除) })
            });
            TreeNode treeNodeSystemSetting = NewTreeNode(RolePermissionMenuEnum.系统设置, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
                NewTreeNode(RolePermissionEnum.编辑)
            });
            TreeNode treeNodePrintSetting = NewTreeNode(RolePermissionMenuEnum.打印设置, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                //,
                //NewTreeNode(RolePermissionEnum.编辑)
            });

            TreeNode treeNodeRole = NewTreeNode(RolePermissionMenuEnum.角色管理, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
                NewTreeNode(RolePermissionEnum.编辑),
                NewTreeNode(RolePermissionEnum.删除) });
            TreeNode treeNodeManage = NewTreeNode(RolePermissionMenuEnum.管理员, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
                NewTreeNode(RolePermissionEnum.编辑),
                NewTreeNode(RolePermissionEnum.删除) });
            TreeNode treeNodeGuide = NewTreeNode(RolePermissionMenuEnum.导购员, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
                NewTreeNode(RolePermissionEnum.编辑)  });
            TreeNode treeNodeGuideSign = NewTreeNode(RolePermissionMenuEnum.导购签到记录, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看,  new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店)}) }
                );

            TreeNode treeNodeInitialBalance = NewTreeNode(RolePermissionMenuEnum.期初建账);

            treeNodeInitialBalance.Nodes.Add(NewTreeNode(RolePermissionMenuEnum.期初库存录入, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,NewTreeNode(RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出)
            }));

            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                treeNodeInitialBalance.Nodes.Add(NewTreeNode(RolePermissionMenuEnum.期初往来账录入, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
            }));
            }

            TreeNode treeNodeSetting = NewTreeNode(RolePermissionMenuEnum.设置);
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                treeNodeSetting.Nodes.Add(treeNode1RuleSetting);
                treeNodeSetting.Nodes.Add(treeNodeSystemSetting);
            }
            treeNodeSetting.Nodes.Add(treeNodePrintSetting);
            treeNodeSetting.Nodes.Add(treeNodeRole);
            treeNodeSetting.Nodes.Add(treeNodeManage);
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                treeNodeSetting.Nodes.Add(treeNodeGuide);
                treeNodeSetting.Nodes.Add(treeNodeGuideSign);
            }
            treeNodeSetting.Nodes.Add(treeNodeInitialBalance);
            nodes.Add(treeNodeSetting);
            #endregion

            #region 采购
            //查看           （成本价、品牌）	挂单	提单	打印	导入
            TreeNode treeNode40 = NewTreeNode(RolePermissionMenuEnum.采购进货, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看 )   
                ,NewTreeNode(RolePermissionEnum.挂单)
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.打印)
                ,NewTreeNode(RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出),
            NewTreeNode( RolePermissionEnum.单据时间)
            });
            TreeNode treeNode41 = NewTreeNode(RolePermissionMenuEnum.采购退货, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.挂单),
                    NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.打印),
            NewTreeNode( RolePermissionEnum.单据时间)
            });
            TreeNode treeNode43 = NewTreeNode(RolePermissionMenuEnum.采购汇总, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
            });
            //查看           （成本价、品牌）	冲单	重做              （单据时间）	提单	打印
            TreeNode treeNode60 = NewTreeNode(RolePermissionMenuEnum.采购进货退货单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.冲单)
                ,NewTreeNode(RolePermissionEnum.重做, new TreeNode[] { NewTreeNode(RolePermissionEnum.重做_单据时间) })
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.导出)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNodeSupplier = NewTreeNode(RolePermissionMenuEnum.供应商, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,NewTreeNode(RolePermissionEnum.删除)
                ,NewTreeNode(RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodePurcharge = NewTreeNode(RolePermissionMenuEnum.采购, new TreeNode[] {
            treeNode40,
            treeNode41,
            treeNode43,
            treeNode60,
            treeNodeSupplier
            //,
           // treeNode44
            });
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                nodes.Add(treeNodePurcharge);
            }
            #endregion

            #region 零售
            //查看           （品牌）	挂单	提单	抹零	打印
            TreeNode treeNodeCashier = NewTreeNode(RolePermissionMenuEnum.收银, new TreeNode[] {
                  NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店)  })
                ,NewTreeNode(RolePermissionEnum.挂单)
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.抹零)
                ,NewTreeNode(RolePermissionEnum.打印),
            NewTreeNode( RolePermissionEnum.单据时间)
            });
            // 查看 打印
            TreeNode treeNodeRefund = NewTreeNode(RolePermissionMenuEnum.退货, new TreeNode[] {
                 NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店)  })
                ,NewTreeNode(RolePermissionEnum.打印),
            NewTreeNode( RolePermissionEnum.单据时间)
            });


            TreeNode treeNode54 = NewTreeNode(RolePermissionMenuEnum.销售退货单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店)  })
                ,NewTreeNode(RolePermissionEnum.冲单)
                ,NewTreeNode(RolePermissionEnum.重做, new TreeNode[] { NewTreeNode(RolePermissionEnum.重做_单据时间) })
                ,NewTreeNode(RolePermissionEnum.导出)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNode24 = NewTreeNode(RolePermissionMenuEnum.店铺档案, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,NewTreeNode(RolePermissionEnum.启用)
                ,NewTreeNode(RolePermissionEnum.禁用)
                ,NewTreeNode(RolePermissionEnum.删除)
            });
            TreeNode treeNode25 = NewTreeNode(RolePermissionMenuEnum.销售目标, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                ,NewTreeNode(RolePermissionEnum.编辑)
            });
            TreeNode treeNode27 = NewTreeNode(RolePermissionMenuEnum.价格管理, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑 )
            });
            TreeNode treeNodeReplish = NewTreeNode(RolePermissionMenuEnum.店铺补货申请, new TreeNode[] {
                 NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                ,NewTreeNode(RolePermissionEnum.挂单)
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNodeReplishSearch = NewTreeNode(RolePermissionMenuEnum.店铺补货单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.发货)
                ,NewTreeNode(RolePermissionEnum.取消)
                ,NewTreeNode(RolePermissionEnum.拒绝)
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.导出)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNodeDayReport = NewTreeNode(RolePermissionMenuEnum.当日结存, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNodeDayReportSearch = NewTreeNode(RolePermissionMenuEnum.日结存查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNodeAttendance = NewTreeNode(RolePermissionMenuEnum.考勤签到, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
            });
            TreeNode treeNodeRetail = NewTreeNode(RolePermissionMenuEnum.零售);
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                treeNodeRetail.Nodes.Add(treeNodeCashier);
                treeNodeRetail.Nodes.Add(treeNodeRefund);
                treeNodeRetail.Nodes.Add(treeNode54);
            }
            treeNodeRetail.Nodes.Add(treeNode24);
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                treeNodeRetail.Nodes.Add(treeNode25);
                treeNodeRetail.Nodes.Add(treeNode27);
                treeNodeRetail.Nodes.Add(treeNodeReplish);
                treeNodeRetail.Nodes.Add(treeNodeReplishSearch);
                treeNodeRetail.Nodes.Add(treeNodeDayReport);
                treeNodeRetail.Nodes.Add(treeNodeDayReportSearch);
                treeNodeRetail.Nodes.Add(treeNodeAttendance);
            }
            nodes.Add(treeNodeRetail);
            #endregion

            #region 批发
            TreeNode treeNode30 = NewTreeNode(RolePermissionMenuEnum.批发发货, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.挂单)
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.打印),
            NewTreeNode( RolePermissionEnum.单据时间)
            });
            TreeNode treeNode31 = NewTreeNode(RolePermissionMenuEnum.批发退货, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.挂单)
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.打印),
            NewTreeNode( RolePermissionEnum.单据时间)
            });
            TreeNode treeNode35 = NewTreeNode(RolePermissionMenuEnum.批发发货退货单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.冲单)
                ,NewTreeNode(RolePermissionEnum.重做, new TreeNode[] { NewTreeNode(RolePermissionEnum.重做_单据时间) })
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.导出)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNode29 = NewTreeNode(RolePermissionMenuEnum.客户管理, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,NewTreeNode(RolePermissionEnum.删除)
                ,NewTreeNode(RolePermissionEnum.充值)
                ,NewTreeNode(RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出)
            });
        /*   TreeNode treeNode32 = NewTreeNode(RolePermissionMenuEnum.客户库存, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
            });*/
            TreeNode treeNode33 = NewTreeNode(RolePermissionMenuEnum.录入客户销售, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.单据时间)
            });
            TreeNode treeNode34 = NewTreeNode(RolePermissionMenuEnum.客户销售单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,NewTreeNode(RolePermissionEnum.删除)
            });
            TreeNode treeNode36 = NewTreeNode(RolePermissionMenuEnum.客户期初库存录入, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,NewTreeNode(RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNode37 = NewTreeNode(RolePermissionMenuEnum.客户期初往来账录入, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
            });
            TreeNode treeNode38 = NewTreeNode(RolePermissionMenuEnum.客户期初管理, new TreeNode[] {
            treeNode36,
            treeNode37});
            //判断账套是否开通
            TreeNode treeNodeWholesale = NewTreeNode(RolePermissionMenuEnum.批发);
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
             
                treeNodeWholesale.Nodes.Add(treeNode30);
                treeNodeWholesale.Nodes.Add(treeNode31);
                treeNodeWholesale.Nodes.Add(treeNode35);
              //  treeNodeWholesale.Nodes.Add(treeNode32);
                treeNodeWholesale.Nodes.Add(treeNode33);
                treeNodeWholesale.Nodes.Add(treeNode34);
                treeNodeWholesale.Nodes.Add(treeNode38);
            }   treeNodeWholesale.Nodes.Add(treeNode29);

            /* TreeNode treeNodeStore = NewTreeNode(RolePermissionMenuEnum.库存);
            treeNodeStore.Nodes.Add(treeNode46);
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                treeNodeStore.Nodes.Add(treeNode47);
                treeNodeStore.Nodes.Add(treeNode48);
                treeNodeStore.Nodes.Add(treeNode55);
                treeNodeStore.Nodes.Add(treeNode58);
                treeNodeStore.Nodes.Add(treeNode49);
                treeNodeStore.Nodes.Add(treeNodeSubCheckStore);
                treeNodeStore.Nodes.Add(treeNode57);
                treeNodeStore.Nodes.Add(treeNode50);
                treeNodeStore.Nodes.Add(treeNode51);
                treeNodeStore.Nodes.Add(treeNode52);
                treeNodeStore.Nodes.Add(treeNodeScrap);
                treeNodeStore.Nodes.Add(treeNode59);
            }
             */
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {

            }

                nodes.Add(treeNodeWholesale);
           
            //if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            //{
            //    nodes.Add(treeNodeWholesale);
            //}

                #endregion
                #region 库存
                TreeNode treeNode46 = NewTreeNode(RolePermissionMenuEnum.库存查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看 , new TreeNode[] {NewTreeNode(RolePermissionEnum.查看_只看本店) })
                ,NewTreeNode(RolePermissionEnum.导出)
            });

            TreeNode treeNodeShopDistribute = NewTreeNode(RolePermissionMenuEnum.商品分布, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
            });

            TreeNode treeNode47 = NewTreeNode(RolePermissionMenuEnum.库存变化查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看 , new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
            });
            TreeNode treeNode48 = NewTreeNode(RolePermissionMenuEnum.调拨, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                ,NewTreeNode(RolePermissionEnum.挂单)
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.打印),
            NewTreeNode( RolePermissionEnum.单据时间)
            });
            TreeNode treeNode55 = NewTreeNode(RolePermissionMenuEnum.调拨单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                ,NewTreeNode(RolePermissionEnum.导出)
                ,NewTreeNode(RolePermissionEnum.收货)
                ,NewTreeNode(RolePermissionEnum.冲单)
                ,NewTreeNode(RolePermissionEnum.重做, new TreeNode[] { NewTreeNode(RolePermissionEnum.重做_单据时间) })
                ,NewTreeNode(RolePermissionEnum.提单)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNode58 = NewTreeNode(RolePermissionMenuEnum.差异单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNode49 = NewTreeNode(RolePermissionMenuEnum.盘点录入, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                ,NewTreeNode(RolePermissionEnum.挂单)
                ,NewTreeNode(RolePermissionEnum.导入)
                ,NewTreeNode(RolePermissionEnum.打印),
            NewTreeNode( RolePermissionEnum.导出),
            NewTreeNode( RolePermissionEnum.单据时间)
            });


            TreeNode treeNodeSubCheckStore = NewTreeNode(RolePermissionMenuEnum.添加子盘点单, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,//NewTreeNode(RolePermissionEnum.删除),
            NewTreeNode( RolePermissionEnum.单据时间)
            });
            TreeNode treeNode57 = NewTreeNode(RolePermissionMenuEnum.盘点单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.审核)
                ,NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                ,NewTreeNode(RolePermissionEnum.冲单)
                ,NewTreeNode(RolePermissionEnum.编辑)
                ,NewTreeNode(RolePermissionEnum.删除)
                ,NewTreeNode(RolePermissionEnum.重做, new TreeNode[] { NewTreeNode(RolePermissionEnum.重做_单据时间) })
                ,NewTreeNode(RolePermissionEnum.导出)
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNode50 = NewTreeNode(RolePermissionMenuEnum.盘点汇总, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] {  NewTreeNode(RolePermissionEnum.查看_只看本店) })
            });
            TreeNode treeNode51 = NewTreeNode(RolePermissionMenuEnum.串码调整, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                ,NewTreeNode(RolePermissionEnum.编辑)
            });
            TreeNode treeNode52 = NewTreeNode(RolePermissionMenuEnum.串码调整查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                  ,NewTreeNode(RolePermissionEnum.编辑)
            });
            TreeNode treeNodeScrap = NewTreeNode(RolePermissionMenuEnum.报损, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看) 
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNode59 = NewTreeNode(RolePermissionMenuEnum.报损单查询, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                ,NewTreeNode(RolePermissionEnum.冲单)
                ,NewTreeNode(RolePermissionEnum.重做, new TreeNode[] { NewTreeNode(RolePermissionEnum.重做_单据时间) })
                ,NewTreeNode(RolePermissionEnum.打印)
            });
            TreeNode treeNodeStore = NewTreeNode(RolePermissionMenuEnum.库存);
            treeNodeStore.Nodes.Add(treeNode46);
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                treeNodeStore.Nodes.Add(treeNodeShopDistribute); 
                treeNodeStore.Nodes.Add(treeNode47);
                treeNodeStore.Nodes.Add(treeNode48);
                treeNodeStore.Nodes.Add(treeNode55);
                treeNodeStore.Nodes.Add(treeNode58);
                treeNodeStore.Nodes.Add(treeNode49);
                treeNodeStore.Nodes.Add(treeNodeSubCheckStore);
                treeNodeStore.Nodes.Add(treeNode57);
                treeNodeStore.Nodes.Add(treeNode50);
                treeNodeStore.Nodes.Add(treeNode51);
                treeNodeStore.Nodes.Add(treeNode52);
                treeNodeStore.Nodes.Add(treeNodeScrap);
                treeNodeStore.Nodes.Add(treeNode59);
            }
            nodes.Add(treeNodeStore);
            #endregion 

            #region 报表
            TreeNode treeNode63 = NewTreeNode(RolePermissionMenuEnum.店铺营业报表, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_销售成本) ,NewTreeNode(RolePermissionEnum.查看_毛利),NewTreeNode(RolePermissionEnum.查看_只看本店)}
                ),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNode64 = NewTreeNode(RolePermissionMenuEnum.畅滞排行榜, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] {   NewTreeNode(RolePermissionEnum.查看_备注),NewTreeNode(RolePermissionEnum.查看_只看本店)})
            ,
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNode65 = NewTreeNode(RolePermissionMenuEnum.销售分析, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_毛利) })
              // ,NewTreeNode(RolePermissionEnum.查看_毛利)
               ,NewTreeNode(RolePermissionEnum.导出)
            });
            TreeNode treeNode66 = NewTreeNode(RolePermissionMenuEnum.库存分析, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.导出)
            });

            TreeNode treeNodeCustome = NewTreeNode(RolePermissionMenuEnum.商品进销存, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodeCustomer = NewTreeNode(RolePermissionMenuEnum.客户进销存, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNode68 = NewTreeNode(RolePermissionMenuEnum.商品价格区间简报, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNode69 = NewTreeNode(RolePermissionMenuEnum.导购业绩, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店)})
                ,
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodeReport = NewTreeNode(RolePermissionMenuEnum.报表, new TreeNode[] {
            treeNode63,
            treeNode64,
            treeNode65,
            treeNode66,
            //treeNodeShopDistribute,
            treeNodeCustome,
            treeNodeCustomer,
            treeNode68,
            treeNode69});
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                nodes.Add(treeNodeReport);
            }
            #endregion

            #region 财务
            TreeNode treeNode71 = NewTreeNode(RolePermissionMenuEnum.店铺现金管理, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })
                 ,NewTreeNode(RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodeFeeType = NewTreeNode(RolePermissionMenuEnum.费用类型, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                 ,NewTreeNode(RolePermissionEnum.编辑)
                 ,NewTreeNode(RolePermissionEnum.删除)
            });
            TreeNode treeNode72 = NewTreeNode(RolePermissionMenuEnum.店铺收款汇总, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodeSuper = NewTreeNode(RolePermissionMenuEnum.供应商往来账汇总, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodeSuperTable = NewTreeNode(RolePermissionMenuEnum.供应商往来账对账表, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
               ,NewTreeNode(RolePermissionEnum.导出)
            });
            TreeNode treeNodePurchase = NewTreeNode(RolePermissionMenuEnum.采购付款管理, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                 ,NewTreeNode(RolePermissionEnum.编辑)
                 ,NewTreeNode(RolePermissionEnum.删除),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodeSearch = NewTreeNode(RolePermissionMenuEnum.客户往来账汇总, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodeDui = NewTreeNode(RolePermissionMenuEnum.客户往来账对账表, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
               ,NewTreeNode(RolePermissionEnum.导出)
            });
            TreeNode treeNodeSalManage = NewTreeNode(RolePermissionMenuEnum.销售收款管理, new TreeNode[] {
                NewTreeNode(RolePermissionEnum.查看)
                 ,NewTreeNode(RolePermissionEnum.编辑)
                 ,NewTreeNode(RolePermissionEnum.删除),
            NewTreeNode( RolePermissionEnum.导出)
            });
            TreeNode treeNodeFinance = NewTreeNode(RolePermissionMenuEnum.财务);
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                treeNodeFinance.Nodes.Add(treeNode71);
                treeNodeFinance.Nodes.Add(treeNodeFeeType);
                treeNodeFinance.Nodes.Add(treeNode72);
                treeNodeFinance.Nodes.Add(treeNodeSuper);
                treeNodeFinance.Nodes.Add(treeNodeSuperTable);
                treeNodeFinance.Nodes.Add(treeNodePurchase);
                treeNodeFinance.Nodes.Add(treeNodeSearch);
                treeNodeFinance.Nodes.Add(treeNodeDui);
            }
            treeNodeFinance.Nodes.Add(treeNodeSalManage);
            nodes.Add(treeNodeFinance);
            #endregion


            #region 商品
            TreeNode treeNode44 = NewTreeNode(RolePermissionMenuEnum.商品档案, new TreeNode[] {
            NewTreeNode(RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_备注)  }),
            NewTreeNode( RolePermissionEnum.编辑),
            //NewTreeNode( RolePermissionEnum.启用),
            //NewTreeNode( RolePermissionEnum.禁用),
            NewTreeNode( RolePermissionEnum.删除),
            NewTreeNode( RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出),
            NewTreeNode( RolePermissionEnum.打印)
         });
            TreeNode treeNode10 = NewTreeNode(RolePermissionMenuEnum.基础资料, new TreeNode[] {
            NewTreeNode( RolePermissionMenuEnum.品牌, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.删除),
            NewTreeNode( RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出)
         }),
            NewTreeNode( RolePermissionMenuEnum.类别, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.删除),
            NewTreeNode( RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出)
         }),
            NewTreeNode( RolePermissionMenuEnum.颜色, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.删除),
            NewTreeNode( RolePermissionEnum.导入),
            NewTreeNode( RolePermissionEnum.导出)
         }),
            NewTreeNode( RolePermissionMenuEnum.尺码, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.删除)
         }),
            NewTreeNode( RolePermissionMenuEnum.季节, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.删除)
         }),
         });
            TreeNode treeNodeCostume = NewTreeNode(RolePermissionMenuEnum.商品);
            treeNodeCostume.Nodes.Add(treeNode44);
            treeNodeCostume.Nodes.Add(treeNode10);
            nodes.Add(treeNodeCostume);
            #endregion
            #region 会员
            TreeNode treeNode21 = NewTreeNode(RolePermissionMenuEnum.会员管理, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看, new TreeNode[] { NewTreeNode( RolePermissionEnum.查看_只看本店)  })
             ,NewTreeNode( RolePermissionEnum.编辑)
              ,NewTreeNode(RolePermissionEnum.开卡)
               ,NewTreeNode( RolePermissionEnum.充值)
                ,NewTreeNode( RolePermissionEnum.发放优惠券)
                 ,NewTreeNode( RolePermissionEnum.导入)
                 ,NewTreeNode( RolePermissionEnum.导出)

        });
            TreeNode treeNodeMemCost = NewTreeNode(RolePermissionMenuEnum.会员消费汇总, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看)
         });
            TreeNode treeNodeMemYuE = NewTreeNode(RolePermissionMenuEnum.会员余额变化, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看)
         });
            TreeNode treeNode22 = NewTreeNode(RolePermissionMenuEnum.优惠券管理, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看)
           ,NewTreeNode( RolePermissionEnum.发放优惠券)
         });
            TreeNode treeNodeMember = NewTreeNode(RolePermissionMenuEnum.会员, new TreeNode[] {
            treeNode21,
            treeNodeMemCost,
            treeNodeMemYuE,
            treeNode22});
            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                nodes.Add(treeNodeMember);
            }
            #endregion

            #region 线上商城

            TreeNode treeNode76 = NewTreeNode(RolePermissionMenuEnum.店铺信息, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑)
            });
            TreeNode treeNode77 = NewTreeNode(RolePermissionMenuEnum.商品管理, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.下架),
            NewTreeNode( RolePermissionEnum.上架)
            });
            TreeNode treeNode80 = NewTreeNode(RolePermissionMenuEnum.订单管理, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.操作)
            });
            TreeNode treeNodeWholeSaleCenter = NewTreeNode(RolePermissionMenuEnum.分销中心, new TreeNode[] {

                 NewTreeNode( RolePermissionMenuEnum.分销设置, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑)
            }),

            NewTreeNode( RolePermissionMenuEnum.层级收益, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑)
            }),

            NewTreeNode( RolePermissionMenuEnum.分销人员管理, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.编辑),
            NewTreeNode( RolePermissionEnum.新增下线)
            }),
            //  NewTreeNode( RolePermissionMenuEnum.录入回款金额),
            //查看	  编辑  	付款	取消

            NewTreeNode( RolePermissionMenuEnum.提现管理, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看),
            NewTreeNode( RolePermissionEnum.付款),
            NewTreeNode( RolePermissionEnum.取消) }),


            NewTreeNode( RolePermissionMenuEnum.佣金查询, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看)
                 ,NewTreeNode( RolePermissionEnum.导出)  }),

                    NewTreeNode( RolePermissionMenuEnum.打款管理, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看)
                 ,NewTreeNode( RolePermissionEnum.编辑)})



         });
         //   TreeNode treeNodePaymentNode = NewTreeNode(RolePermissionMenuEnum.打款管理, new TreeNode[] {
         //   NewTreeNode( RolePermissionEnum.查看)
         //   ,NewTreeNode( RolePermissionEnum.编辑)
         //});



            TreeNode treeNode78 = NewTreeNode(RolePermissionMenuEnum.物流管理, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看)
            ,NewTreeNode( RolePermissionEnum.编辑)
         });
            TreeNode treeNode79 = NewTreeNode(RolePermissionMenuEnum.运费模板, new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看)
            , NewTreeNode( RolePermissionEnum.编辑)
            , NewTreeNode( RolePermissionEnum.删除)
         });

        

            TreeNode treeNodeOnline = NewTreeNode(RolePermissionMenuEnum.线上商城, new TreeNode[] {
            treeNode76,
            treeNode77,
            treeNode80,
            treeNodeWholeSaleCenter,
            treeNode78,
            treeNode79,
          //  treeNodePaymentNode
         });
            if (CommonGlobalCache.BusinessAccount.OnlineEnabled)
            {
                nodes.Add(treeNodeOnline);
            }

            #endregion

            if (CommonGlobalCache.BusinessAccount.ERPEnabled)
            {
                TreeNode treeNode88 = NewTreeNode(RolePermissionMenuEnum.重结,
                    new TreeNode[] {
            NewTreeNode( RolePermissionEnum.查看, new TreeNode[] { NewTreeNode( RolePermissionEnum.查看_只看本店)  })
         });
                nodes.Add(treeNode88);
            }

            nodes.Add(NewTreeNode(RolePermissionEnum.查看_品牌));
            nodes.Add(NewTreeNode(RolePermissionEnum.查看_成本价));

            TreeNode treeNodeMobile= NewTreeNode(RolePermissionMenuEnum.手机端,
                new TreeNode[] {
            NewTreeNode(RolePermissionMenuEnum.手机端回访),
            NewTreeNode(RolePermissionMenuEnum.手机端进销存,new TreeNode[] { NewTreeNode( RolePermissionEnum.查看, new TreeNode[] { NewTreeNode(RolePermissionEnum.查看_只看本店) })  }),
             NewTreeNode(RolePermissionMenuEnum.商品库存价格),
              NewTreeNode(RolePermissionMenuEnum.时间查询上限到上月),

                }
         );
            nodes.Add(treeNodeMobile); 
            return nodes;
        }
    }
}
