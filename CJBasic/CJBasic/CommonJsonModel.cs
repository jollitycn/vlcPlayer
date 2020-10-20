namespace CJBasic
{
    using System;
    using System.Collections.Generic;

    public class CommonJsonModel : CommonJsonModelAnalyzer
    {
        private bool isCollection = false;
        private bool isModel = false;
        private bool isValue = false;
        private string rawjson;

        internal CommonJsonModel(string rawjson)
        {
            this.rawjson = rawjson;
            if (string.IsNullOrEmpty(rawjson))
            {
                throw new Exception("missing rawjson");
            }
            rawjson = rawjson.Trim();
            if (rawjson.StartsWith("{"))
            {
                this.isModel = true;
            }
            else if (rawjson.StartsWith("["))
            {
                this.isCollection = true;
            }
            else
            {
                this.isValue = true;
            }
        }

        public static CommonJsonModel DeSerialize(string json)
        {
            return new CommonJsonModel(json);
        }

        public List<CommonJsonModel> GetCollection()
        {
            List<CommonJsonModel> list = new List<CommonJsonModel>();
            if (!this.IsValue())
            {
                foreach (string str in base._GetCollection(this.rawjson))
                {
                    list.Add(new CommonJsonModel(str));
                }
            }
            return list;
        }

        public CommonJsonModel GetCollection(string key)
        {
            if (this.isModel)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return null;
                }
                foreach (string str in base._GetCollection(this.rawjson))
                {
                    CommonJsonModel model = new CommonJsonModel(str);
                    if (model.IsValue() && (model.Key == key))
                    {
                        CommonJsonModel model2 = new CommonJsonModel(model.Value);
                        if (!model2.IsCollection())
                        {
                            return null;
                        }
                        return model2;
                    }
                }
            }
            return null;
        }

        public List<string> GetKeys()
        {
            if (!this.isModel)
            {
                return null;
            }
            List<string> list = new List<string>();
            foreach (string str in base._GetCollection(this.rawjson))
            {
                string key = new CommonJsonModel(str).Key;
                if (!string.IsNullOrEmpty(key))
                {
                    list.Add(key);
                }
            }
            return list;
        }

        public CommonJsonModel GetModel(string key)
        {
            if (this.isModel)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return null;
                }
                foreach (string str in base._GetCollection(this.rawjson))
                {
                    CommonJsonModel model = new CommonJsonModel(str);
                    if (model.IsValue() && (model.Key == key))
                    {
                        CommonJsonModel model2 = new CommonJsonModel(model.Value);
                        if (!model2.IsModel())
                        {
                            return null;
                        }
                        return model2;
                    }
                }
            }
            return null;
        }

        public string GetValue(string key)
        {
            if (this.isModel)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return null;
                }
                foreach (string str in base._GetCollection(this.rawjson))
                {
                    CommonJsonModel model = new CommonJsonModel(str);
                    if (model.IsValue() && (model.Key == key))
                    {
                        return model.Value;
                    }
                }
            }
            return null;
        }

        public bool IsCollection()
        {
            return this.isCollection;
        }

        public bool IsCollection(string key)
        {
            if (this.isModel)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return false;
                }
                foreach (string str in base._GetCollection(this.rawjson))
                {
                    CommonJsonModel model = new CommonJsonModel(str);
                    if (model.IsValue() && (model.Key == key))
                    {
                        CommonJsonModel model2 = new CommonJsonModel(model.Value);
                        return model2.IsCollection();
                    }
                }
            }
            return false;
        }

        public bool IsModel()
        {
            return this.isModel;
        }

        public bool IsModel(string key)
        {
            if (this.isModel)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return false;
                }
                foreach (string str in base._GetCollection(this.rawjson))
                {
                    CommonJsonModel model = new CommonJsonModel(str);
                    if (model.IsValue() && (model.Key == key))
                    {
                        CommonJsonModel model2 = new CommonJsonModel(model.Value);
                        return model2.IsModel();
                    }
                }
            }
            return false;
        }

        public bool IsValue()
        {
            return this.isValue;
        }

        public bool IsValue(string key)
        {
            if (this.isModel)
            {
                if (string.IsNullOrEmpty(key))
                {
                    return false;
                }
                foreach (string str in base._GetCollection(this.rawjson))
                {
                    CommonJsonModel model = new CommonJsonModel(str);
                    if (model.IsValue() && (model.Key == key))
                    {
                        CommonJsonModel model2 = new CommonJsonModel(model.Value);
                        return model2.IsValue();
                    }
                }
            }
            return false;
        }

        public string Key
        {
            get
            {
                if (this.IsValue())
                {
                    return base._GetKey(this.rawjson);
                }
                return null;
            }
        }

        public string Rawjson
        {
            get
            {
                return this.rawjson;
            }
        }

        public string Value
        {
            get
            {
                if (!this.IsValue())
                {
                    return null;
                }
                return base._GetValue(this.rawjson);
            }
        }
    }
}

