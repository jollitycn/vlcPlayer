﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JGNet.Common.Core
{

    public enum RolePermissionMenuEnum
    {
        [Description("无")] 无 =-1,
        [Description("不限")] 不限 = 0,
        [Description("工作台")] 工作台 = 10,
        [Description("设置")] 设置 = 11,
        [Description("规则设置")] 规则设置 = 1101,
        [Description("优惠券设置")] 优惠券设置 = 110101,
        [Description("促销规则")] 促销规则 = 110102,
        [Description("充值规则")] 充值规则 = 110103,
        [Description("系统设置")] 系统设置 = 1102,
        [Description("系统折扣设定")] 系统折扣设定 = 110201,
        [Description("参数设置")] 参数设置 = 110202,
        [Description("条码设置")] 条码设置 = 110203,
        [Description("修改密码")] 修改密码 = 110204,
        [Description("角色管理")] 角色管理 = 1103,
        [Description("管理员")] 管理员 = 1104,
        [Description("导购员")] 导购员 = 1105,
        [Description("导购签到记录")] 导购签到记录 = 1106,
        [Description("期初建账")] 期初建账 = 1107,
        [Description("期初库存录入")] 期初库存录入 = 1108,
        [Description("期初往来账录入")] 期初往来账录入 = 1109,
        [Description("打印设置")] 打印设置 = 1110,
        [Description("采购")] 采购 = 12,
        [Description("采购进货")] 采购进货 = 1201,
        [Description("采购退货")] 采购退货 = 1202,
        [Description("采购汇总")] 采购汇总 = 1203,
        [Description("采购进货/退货单查询")] 采购进货退货单查询 = 1204,
        [Description("供应商")] 供应商 = 1205,
        [Description("零售")] 零售 = 13,
        [Description("收银")] 收银 = 1301,
        [Description("退货")] 退货 = 1302,
        [Description("销售/退货单查询")] 销售退货单查询 = 1303,
        [Description("店铺档案")] 店铺档案 = 1304,
        [Description("销售目标")] 销售目标 = 1305,
        [Description("价格管理")] 价格管理 = 1306,
        [Description("店铺补货申请")] 店铺补货申请 = 1307,
        [Description("店铺补货单查询")] 店铺补货单查询 = 1308,
        [Description("当日结存")] 当日结存 = 1309,
        [Description("日结存查询")] 日结存查询 = 1310,
        [Description("考勤签到")] 考勤签到 = 1311,
        [Description("批发")] 批发 = 14,
        [Description("批发发货")] 批发发货 = 1401,
        [Description("批发退货")] 批发退货 = 1402,
        [Description("批发发货/退货单查询")] 批发发货退货单查询 = 1403,
        [Description("客户管理")] 客户管理 = 1404,
        [Description("客户库存")] 客户库存 = 1405,
        [Description("录入客户销售")] 录入客户销售 = 1406,
        [Description("客户销售单查询")] 客户销售单查询 = 1407,
        [Description("客户期初管理")] 客户期初管理 = 1408,
        [Description("客户期初库存录入")] 客户期初库存录入 = 140801,
        [Description("客户期初往来账录入")] 客户期初往来账录入 = 140802,
        [Description("库存")] 库存 = 15,
        [Description("库存查询")] 库存查询 = 1501,
        [Description("库存变化查询")] 库存变化查询 = 1502,
        [Description("调拨")] 调拨 = 1503,
        [Description("调拨单查询")] 调拨单查询 = 1504,
        [Description("差异单查询")] 差异单查询 = 1505,
        [Description("盘点录入")] 盘点录入 = 1506,
        [Description("盘点单查询")] 盘点单查询 = 1507,
        [Description("盘点汇总")] 盘点汇总 = 1508,
        [Description("串码调整")] 串码调整 = 1509,
        [Description("串码调整查询")] 串码调整查询 = 1510,
        [Description("报损")] 报损 = 1511,
        [Description("报损单查询")] 报损单查询 = 1512,
        [Description("添加子盘点单")] 添加子盘点单 = 1513,
        [Description("报表")] 报表 = 16,
        [Description("店铺营业报表")] 店铺营业报表 = 1601,
        [Description("畅滞排行榜")] 畅滞排行榜 = 1602,
        [Description("销售分析")] 销售分析 = 1603,
        [Description("库存分析")] 库存分析 = 1604,
        [Description("商品进销存")] 商品进销存 = 1605,
        [Description("客户进销存")] 客户进销存 = 1606,
        [Description("商品价格区间简报")] 商品价格区间简报 = 1607,
        [Description("导购业绩")] 导购业绩 = 1608,
        [Description("商品分布")] 商品分布 = 1609,
        [Description("财务")] 财务 = 17,
        [Description("店铺现金管理")] 店铺现金管理 = 1701,
        [Description("费用类型")] 费用类型 = 1702,
        [Description("店铺收款汇总")] 店铺收款汇总 = 1703,
        [Description("供应商往来账汇总")] 供应商往来账汇总 = 1704,
        [Description("供应商往来账对账表")] 供应商往来账对账表 = 1705,
        [Description("采购付款管理")] 采购付款管理 = 1706,
        [Description("客户往来账汇总")] 客户往来账汇总 = 1707,
        [Description("客户往来账对账表")] 客户往来账对账表 = 1708,
        [Description("销售收款管理")] 销售收款管理 = 1709,
        [Description("商品")] 商品 = 18,
        [Description("商品档案")] 商品档案 = 1801,
        [Description("基础资料")] 基础资料 = 1802,
        [Description("品牌")] 品牌 = 180201,
        [Description("类别")] 类别 = 180202,
        [Description("颜色")] 颜色 = 180203,
        [Description("尺码")] 尺码 = 180204,
        [Description("季节")] 季节 = 180205,
        [Description("会员")] 会员 = 19,
        [Description("会员管理")] 会员管理 = 1901,
        //[Description("开卡")] 开卡 = 190181,
        [Description("会员消费汇总")] 会员消费汇总 = 1902,
        [Description("会员余额变化")] 会员余额变化 = 1903,
        [Description("优惠券管理")] 优惠券管理 = 1904,
        [Description("线上商城")] 线上商城 = 20,
        [Description("店铺信息")] 店铺信息 = 2001,
        [Description("商品管理")] 商品管理 = 2002,
        [Description("订单管理")] 订单管理 = 2003,
        [Description("分销中心")] 分销中心 = 2004,
        [Description("层级收益")] 层级收益 = 200401,
        [Description("分销人员管理")] 分销人员管理 = 200402,
        [Description("录入回款金额")] 录入回款金额 = 200403,
        [Description("提现管理")] 提现管理 = 200404,
        [Description("分销设置")] 分销设置 = 200405,
        [Description("佣金查询")] 佣金查询 = 200406,

        [Description("物流管理")] 物流管理 = 2005,
        [Description("运费模板")] 运费模板 = 2006,
        [Description("打款管理")] 打款管理 = 2007,
        [Description("重结")] 重结 = 21,
        [Description("退出")] 退出 = 22,
        [Description("手机端")] 手机端 = 23,
        [Description("手机端回访")] 手机端回访 = 2370,
        [Description("手机端进销存")] 手机端进销存 = 2369,
        [Description("商品库存价格")] 商品库存价格 = 2301,
        [Description("时间查询上限到上月")] 时间查询上限到上月 = 2302,
        
    }

    public enum RolePermissionEnum
    {
        [Description("不限")] 不限 = 0,
        [Description("编辑")] 编辑 = 98,
        [Description("删除")] 删除 = 97,
        [Description("查看")] 查看 = 96,
        [Description("销售成本")] 查看_销售成本 = 9601,
        [Description("毛利")] 查看_毛利 = 9602,
        [Description("毛利率")] 查看_毛利率 = 9603,
        [Description("成本价")] 查看_成本价 = 9699,
        [Description("品牌")] 查看_品牌 = 9698,
        [Description("只看本店")] 查看_只看本店 = 9697,
        [Description("备注")] 查看_备注 = 9696,
        [Description("冲单")] 冲单 = 95,
        [Description("重做")] 重做 = 94,
        [Description("单据时间")] 重做_单据时间 = 9401,
        [Description("提单")] 提单 = 93,
        [Description("打印")] 打印 = 92,
        [Description("导入")] 导入 = 91,
        [Description("导出")] 导出 = 90,
        [Description("挂单")] 挂单 = 89,
        [Description("抹零")] 抹零 = 88,
        [Description("发货")] 发货 = 87,
        [Description("拒绝")] 拒绝 = 86,
        [Description("充值")] 充值 = 85,
        [Description("收货")] 收货 = 84,
        [Description("审核")] 审核 = 83,
        [Description("发放优惠券")] 发放优惠券 = 82,
        [Description("开卡")] 开卡 = 81,
        [Description("付款")] 付款 = 80,
        [Description("取消")] 取消 = 79,
        [Description("设置")] 设置 = 78,
        [Description("退货")] 退货 = 77,
        [Description("新增下线")] 新增下线 = 76,
        [Description("操作")] 操作 = 75,
        [Description("下架")] 下架 = 74,
        [Description("上架")] 上架 = 73,
        [Description("启用")] 启用 = 72,
        [Description("禁用")] 禁用 = 71,
        [Description("单据时间")] 单据时间 = 68,
        /*[Description("回访")] 回访 = 70,
        [Description("进销存")] 进销存 = 69
        70,69该值已被使用
         */
    }
}
