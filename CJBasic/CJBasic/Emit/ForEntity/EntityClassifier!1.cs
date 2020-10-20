namespace CJBasic.Emit.ForEntity
{
    using CJBasic.Collections;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [Serializable]
    public class EntityClassifier<TObject> : IObjectClassifier<TObject>
    {
        private SortedArray<int> ageDistinctArray;
        private List<IObjectContainer<TObject>> allContainerList;
        [NonSerialized]
        private IObjectContainerCreator<TObject> creator;
        private Dictionary<string, Dictionary<int, IObjectContainer<TObject>>> dic;
        private SortedArray<string> idDistinctArray;
        private string[] properties4Classify;
        [NonSerialized]
        private IPropertyQuicker<TObject> quicker;

        public EntityClassifier(string[] _propertys4Classify)
        {
            this.dic = new Dictionary<string, Dictionary<int, IObjectContainer<TObject>>>();
            this.allContainerList = new List<IObjectContainer<TObject>>();
            this.idDistinctArray = new SortedArray<string>();
            this.ageDistinctArray = new SortedArray<int>();
            this.properties4Classify = _propertys4Classify;
        }

        public void Add(TObject entity)
        {
            string propertyValue = (string) this.quicker.GetPropertyValue(entity, this.properties4Classify[0]);
            this.idDistinctArray.Add(propertyValue);
            if (!this.dic.ContainsKey(propertyValue))
            {
                this.dic.Add(propertyValue, new Dictionary<int, IObjectContainer<TObject>>());
            }
            int t = (int) this.quicker.GetPropertyValue(entity, this.properties4Classify[1]);
            this.ageDistinctArray.Add(t);
            if (!this.dic[propertyValue].ContainsKey(t))
            {
                IObjectContainer<TObject> item = this.creator.CreateNewContainer();
                this.allContainerList.Add(item);
                this.dic[propertyValue].Add(t, item);
            }
            this.dic[propertyValue][t].Add(entity);
        }

        private IObjectContainer<TObject> DoGetContainer(object[] propertyValues4Classify)
        {
            string key = (string) propertyValues4Classify[0];
            if (!this.dic.ContainsKey(key))
            {
                return null;
            }
            int num = (int) propertyValues4Classify[1];
            if (!this.dic[key].ContainsKey(num))
            {
                return null;
            }
            return this.dic[key][num];
        }

        public List<IObjectContainer<TObject>> GetAllContainers()
        {
            return this.allContainerList;
        }

        public List<IObjectContainer<TObject>> GetContainers(object[] propertyValues4Classify)
        {
            IList[] distinctValList = new IList[] { this.idDistinctArray.GetAll(), this.ageDistinctArray.GetAll() };
            List<object[]> list = DynamicObjectClassifierEmitter.AdjustMappingValues(propertyValues4Classify, distinctValList);
            List<IObjectContainer<TObject>> list2 = new List<IObjectContainer<TObject>>();
            for (int i = 0; i < list.Count; i++)
            {
                IObjectContainer<TObject> item = this.DoGetContainer(list[i]);
                if (item != null)
                {
                    list2.Add(item);
                }
            }
            return list2;
        }

        public IList GetDistinctValues(string property4Classify)
        {
            if (property4Classify == this.properties4Classify[0])
            {
                return this.idDistinctArray.GetAll();
            }
            if (property4Classify == this.properties4Classify[1])
            {
                return this.ageDistinctArray.GetAll();
            }
            return null;
        }

        public void Initialize(IObjectContainerCreator<TObject> creator)
        {
        }

        public string[] Properties4Classify
        {
            get
            {
                return this.properties4Classify;
            }
        }
    }
}

