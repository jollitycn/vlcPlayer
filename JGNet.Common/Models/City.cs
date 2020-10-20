using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JGNet.Common.Models
{
    public class CarriageCostUtil
    {
        /// <summary>
        /// 只返回被选中的项
        /// </summary>
        /// <param name="zones"></param>
        /// <returns></returns>
        public static CarriageCost ZoneToCarriageCost(List<Zone> zones)
        {
            CarriageCost cost = new CarriageCost();
            //
            if (zones != null)
            {
                cost.Zones = new List<Zone>();
                cost.Cost = 0;
                cost.AreaStr = string.Empty;
                foreach (Zone item in zones)
                {


                  Zone newZone =  GetSelectedZone(item);
                    cost.Zones.Add(newZone);

                    if (item.Province != null)
                    {
                        foreach (Province p in item.Province)
                        {
                            if (p.SelectAll)
                            {
                                cost.AreaStr += p.Name + "、";
                            }
                            else
                            {
                                if (p.Selected)
                                {
                                    if (cost.AreaStr.Length > 0) { 
                                    cost.AreaStr = cost.AreaStr.Substring(0, cost.AreaStr.Length - 1) + "；";
                                    }
                                    cost.AreaStr += p.Name + "：";
                                    if (p.Sub != null)
                                    {
                                        foreach (City c in p.Sub)
                                        {
                                            if (c.Selected)
                                            {

                                                cost.AreaStr += c.Name + "、";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (cost.AreaStr.Length > 0) { 
            cost.AreaStr = cost.AreaStr.Substring(0, cost.AreaStr.Length - 1)+"；";
            }
            return cost;

        }

        private static Zone GetSelectedZone(Zone item)
        {   //zones
            Zone zone = new Zone();
            zone.Province = new List<Province>();
            foreach (var p in item.Province)
            {
                if (p.Selected) {
                    Province province = new Province();
                    province.Name = p.Name;
                    province.Selected = p.Selected;
                    province.Sub = p.Sub.FindAll(t=>t.Selected);
                    zone.Province.Add(province);
                }

            }
            return zone;
        }

        public static List<CarriageCost>  GetAllCarriageCost(List<EmCarriageCostDetail> all) {
            List<CarriageCost> costs = new List<CarriageCost>();
            List<EmCarriageCostDetail> temp = new List<EmCarriageCostDetail>();
            List<EmCarriageCostDetail> sameDetails = new List<EmCarriageCostDetail>();
            foreach (var item in all)
            {
                temp.Add(item);
            }
            while (temp.Count > 0)
            {
                foreach (var item in temp)
                {
                    //相同运费的信息构建在一起
                    sameDetails = temp.FindAll(t => item.CarriageCost == t.CarriageCost);
                    CarriageCost cost= GetCarriageCost(sameDetails);
                    costs.Add(cost);
                    break;
                }

                foreach (var item in sameDetails)
                {
                    temp.Remove(item);
                }
            }

            return costs;
        }

        //获取相同运费的详情,构造一起成为一个CarriageCost
        public static CarriageCost GetCarriageCost(List<EmCarriageCostDetail> source)
        {
            CarriageCost cost = new CarriageCost();
            List<Zone> zones = new List<Zone>();
            if (source!=null)
            {
                List<EmCarriageCostDetail> temp = new List<EmCarriageCostDetail>();
                foreach (EmCarriageCostDetail item in source)
                {
                    temp.Add(item);
                }



                if (temp != null)
                {
                    //将相同的省份拼起来，再拼全部。
                    cost.Cost = temp[0].CarriageCost;

                    //zones
                    Zone zone = new Zone();
                    zone.Province = new List<Province>();
                    List<EmCarriageCostDetail> allSameList = null;

                    while (temp.Count > 0)
                    {
                        foreach (EmCarriageCostDetail item in temp)
                        {
                            Province province = new Province();
                            province.Name = item.Province;
                            province.Selected = true;
                            //找到所有相同的省份,
                            allSameList = temp.FindAll(t => t.Province == item.Province);
                            CommonGlobalUtil.Debug("找到省份：" + item.Province + " " + allSameList.Count);
                            if (!String.IsNullOrEmpty(item.City))
                            {
                                cost.AreaStr += item.Province + "：";
                                //找出所有相同省份的城市信息
                                foreach (EmCarriageCostDetail cityData in allSameList)
                                {
                                    if (province.Sub == null)
                                    {
                                        province.Sub = new List<City>();
                                    }
                                    City city = new City();
                                    city.Name = cityData.City;
                                    city.Selected = true;
                                    province.Sub.Add(city);
                                    cost.AreaStr += cityData.City + "、";
                                }
                                if (cost.AreaStr.Length > 0)
                                {
                                    cost.AreaStr = cost.AreaStr.Substring(0, cost.AreaStr.Length - 1) + "；";
                                }
                            }
                            else
                            {
                                cost.AreaStr += item.Province + ";";
                            }
                            CommonGlobalUtil.Debug("添加：" + province);
                            zone.Province.Add(province);
                            break;
                        }

                        foreach (var removed in allSameList)
                        {
                            temp.Remove(removed);
                        }
                    }

                    zones.Add(zone);

                    if (cost.AreaStr.Length > 0)
                    {
                        cost.AreaStr = cost.AreaStr.Substring(0, cost.AreaStr.Length - 1) + "；";
                    }
                }
            }


            cost.Zones = zones;

            return cost;
        }


        /// <summary>
        /// 根据source选中的内容，重新构造EmCarriageCostDetail，主要针对省份是否是全选城市的状态进行包装。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<EmCarriageCostDetail> GetEmCarriageCostDetails(List<CarriageCost> costs)
        {


            List<EmCarriageCostDetail> result = new List<EmCarriageCostDetail>();
            if (costs != null)
            {
                List<Zone> zones = new List<Zone>();
                foreach (var item in costs)
                {
                    List<Zone> resultList = (List<Zone>)JavaScriptConvert.DeserializeObject(File.ReadAllText(@"CitySelectForm.dat"), typeof(List<Zone>));

                    zones = item.Zones;
                    //   zones.AddRange(item.Zones);

                    //读取所有地区
                    //根据datagridview 中的值
                    //转换成对应EmCarriageCostDetail
                    foreach (var sZone in zones)
                    {
                        foreach (var sProvince in sZone.Province)
                        {

                            foreach (var rZone in resultList)
                            {
                                foreach (var rProvince in rZone.Province)
                                {
                                    if (sProvince.Name == rProvince.Name)
                                    {
                                        rProvince.Selected = true;

                                        foreach (var rCity in rProvince.Sub)
                                        {

                                            if (sProvince.Sub != null)
                                            {
                                                foreach (var sCity in sProvince.Sub)
                                                {
                                                    if (rCity.Name == sCity.Name)
                                                    {
                                                        rCity.Selected = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                rCity.Selected = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //设置完毕
                    //获取
                    result.AddRange(ZoneToEmCarriageCostDetail(resultList, item.Cost));
                }
            }

            return result;
        }



        public static List<EmCarriageCostDetail> ZoneToEmCarriageCostDetail(List<Zone> resultList, decimal cost)
        {
            List<EmCarriageCostDetail> result = new List<EmCarriageCostDetail>();
            foreach (var zone in resultList)
            {
                foreach (var province in zone.Province)
                {

                    if (province.Selected)
                    {
                        if (province.SelectAll)
                        {
                            result.Add(new EmCarriageCostDetail() { Province = province.Name, City = String.Empty, CarriageCost = cost, TemplateID = 0 });
                        }
                        else
                        {

                            foreach (var city in province.Sub)
                            {
                                if (city.Selected)
                                {
                                    result.Add(new EmCarriageCostDetail() { Province = province.Name, City = city.Name, CarriageCost = cost, TemplateID = 0 });
                                }
                            }

                        }
                    }
                }

            }
            return result;
        }
    }
    public class City
    {
        public string Name { get; set; }
        public List<CityArea> Sub { get; set; }
        public string Code { get; set; }
        public bool Selected { get; set; }
        private bool enabled = true;
        public bool Enabled { get { return enabled; } set { enabled = value; } }

    }
    public class CityArea
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Selected { get; set; }
        private bool enabled = true;
        public bool Enabled { get { return enabled; } set { enabled = value; } }

    }

    public class CarriageCost
    {
        public String AreaStr { get; set; }
        public decimal Cost { get; set; }
        public List<Zone> Zones { get; set; }

    }




    public class Province
    {
        public string Name { get; set; }
        public List<City> Sub { get; set; }
        public string Code { get; set; }
        public bool Selected { get; set; }
        private bool enabled = true;
        public bool Enabled { get { return enabled; } set { enabled = value; } }
        public bool SelectAll
        {
            get
            {
                bool all = true;
                if (Sub != null) { 
                foreach (var item in Sub)
                {
                    if (!item.Selected)
                    {
                        all = false;
                        break;
                    }
                    }
                }
                return all;


            }
        }
    }

    public class Zone
    {
        public bool Selected { get; set; }
        private bool enabled = true;
        public bool Enabled { get { return enabled; } set { enabled = value; } }
        public bool SelectAll
        {
            get
            {
                bool all = true;

                if (Province != null)
                {
                    foreach (var item in Province)
                    {
                        if (!item.Selected)
                        {
                            all = false;
                            break;
                        }

                    }
                }
                return all;


            }
        }
        public string Name { get; set; }
        public List<Province> Province { get; set; }
    }
}
