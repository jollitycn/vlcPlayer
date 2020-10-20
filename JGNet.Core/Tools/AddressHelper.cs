using System;
using System.Collections.Generic;
using System.Text;

namespace JGNet.Core.Tools
{
    public static class AddressHelper
    {
        public static DeliveryAddress WxMemberAddressToDeliveryAddress(WxMemberAddress wxMemberAddress)
        {
            if (wxMemberAddress == null)
                return null;
            return new DeliveryAddress()
            {
                AutoID = wxMemberAddress.AutoID,
                UserID = wxMemberAddress.PhoneNumber,
                Name = wxMemberAddress.Name,
                Telphone = wxMemberAddress.Telphone1,
                CityZone = wxMemberAddress.CityZone,
                DetailAddress = wxMemberAddress.DetailAddress
            };
        }

        public static DeliveryAddress PfCustomerAddressToDeliveryAddress(PfCustomerAddress pfCustomerAddress)
        {
            if (pfCustomerAddress == null)
                return null;
            return new DeliveryAddress()
            {
                AutoID = pfCustomerAddress.AutoID,
                UserID = pfCustomerAddress.PfCustomerID,
                Name = pfCustomerAddress.Name,
                Telphone = pfCustomerAddress.Telphone,
                CityZone = pfCustomerAddress.CityZone,
                DetailAddress = pfCustomerAddress.DetailAddress
            };
        }

        public static WxMemberAddress DeliveryAddressToWxMemberAddress(DeliveryAddress deliveryAddress)
        {
            if (deliveryAddress == null)
                return null;
            return new WxMemberAddress()
            {
                AutoID = deliveryAddress.AutoID,
                PhoneNumber = deliveryAddress.UserID,
                Name = deliveryAddress.Name,
                Telphone1 = deliveryAddress.Telphone,
                Telphone2 = "",
                CityZone = deliveryAddress.CityZone,
                DetailAddress = deliveryAddress.DetailAddress
            };
        }

        public static PfCustomerAddress DeliveryAddressToPfCustomerAddress(DeliveryAddress deliveryAddress)
        {
            if (deliveryAddress == null)
                return null;
            return new PfCustomerAddress()
            {
                AutoID = deliveryAddress.AutoID,
                PfCustomerID = deliveryAddress.UserID,
                Name = deliveryAddress.Name,
                Telphone = deliveryAddress.Telphone,
                CityZone = deliveryAddress.CityZone,
                DetailAddress = deliveryAddress.DetailAddress                
            };
        }
    }

    /// <summary>
    /// 收货地址  （用于整合零售与批发 公用显示）
    /// </summary>
    public class DeliveryAddress
    {
        #region AutoID
        private System.Int32 m_AutoID = 0;
        /// <summary>
        /// AutoID 自增ID(主键)，从1开始
        /// </summary>
        public System.Int32 AutoID
        {
            get
            {
                return this.m_AutoID;
            }
            set
            {
                this.m_AutoID = value;
            }
        }
        #endregion

        #region UserID
        private System.String m_UserID = "";
        /// <summary>
        /// UserID 客户账号ID
        /// </summary>
        public System.String UserID
        {
            get
            {
                return this.m_UserID;
            }
            set
            {
                this.m_UserID = value;
            }
        }
        #endregion

        #region Name
        private System.String m_Name = "";
        /// <summary>
        /// Name 收货人姓名
        /// </summary>
        public System.String Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }
        #endregion

        #region Telphone
        private System.String m_Telphone = "";
        /// <summary>
        /// Telphone1 收货人电话
        /// </summary>
        public System.String Telphone
        {
            get
            {
                return this.m_Telphone;
            }
            set
            {
                this.m_Telphone = value;
            }
        }
        #endregion

        #region CityZone
        private System.String m_CityZone = "";
        /// <summary>
        /// CityZone 所在城市，格式：xx省xx市xx区
        /// </summary>
        public System.String CityZone
        {
            get
            {
                return this.m_CityZone;
            }
            set
            {
                this.m_CityZone = value;
            }
        }
        #endregion

        #region DetailAddress
        private System.String m_DetailAddress = "";
        /// <summary>
        /// DetailAddress 收货详细地址：xx街道xx小区xx栋xx号
        /// </summary>
        public System.String DetailAddress
        {
            get
            {
                return this.m_DetailAddress;
            }
            set
            {
                this.m_DetailAddress = value;
            }
        }
        #endregion
    }
}
