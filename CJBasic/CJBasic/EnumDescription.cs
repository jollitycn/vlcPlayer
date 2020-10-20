namespace CJBasic
{
    using CJBasic.Collections;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum)]
    public class EnumDescription : Attribute
    {
        private string description;
        private static IDictionary<string, IList<EnumDescription>> EnumDescriptionCache = new Dictionary<string, IList<EnumDescription>>();
        private object enumValue;
        private static object locker = new object();
        private object tag;

        public EnumDescription(string _description) : this(_description, null)
        {
        }

        public EnumDescription(string _description, object _tag)
        {
            this.description = "";
            this.enumValue = null;
            this.tag = null;
            this.description = _description;
            this.tag = _tag;
        }

        private static IList<EnumDescription> DoGetFieldTexts(Type enumType)
        {
            lock (locker)
            {
                if (!EnumDescriptionCache.ContainsKey(enumType.FullName))
                {
                    FieldInfo[] fields = enumType.GetFields();
                    IList<EnumDescription> list = new List<EnumDescription>();
                    foreach (FieldInfo info in fields)
                    {
                        object[] customAttributes = info.GetCustomAttributes(typeof(EnumDescription), false);
                        if (customAttributes.Length == 1)
                        {
                            EnumDescription item = (EnumDescription) customAttributes[0];
                            item.enumValue = info.GetValue(null);
                            list.Add(item);
                        }
                    }
                    EnumDescriptionCache.Add(enumType.FullName, list);
                }
                return EnumDescriptionCache[enumType.FullName];
            }
        }

        public static string GetEnumDescriptionText(Type enumType)
        {
            EnumDescription[] customAttributes = (EnumDescription[]) enumType.GetCustomAttributes(typeof(EnumDescription), false);
            if (customAttributes.Length < 1)
            {
                return string.Empty;
            }
            return customAttributes[0].Description;
        }

        public static object GetEnumTag(Type enumType)
        {
            EnumDescription[] customAttributes = (EnumDescription[]) enumType.GetCustomAttributes(typeof(EnumDescription), false);
            if (customAttributes.Length != 1)
            {
                return string.Empty;
            }
            return customAttributes[0].Tag;
        }

        public static object GetEnumValueByTag(Type enumType, object tag)
        {
            IList<EnumDescription> source = DoGetFieldTexts(enumType);
            if (source == null)
            {
                return null;
            }
            return CollectionConverter.ConvertFirstSpecification<EnumDescription, object>(source, delegate (EnumDescription des) {
                return des.enumValue;
            }, delegate (EnumDescription des) {
                return des.tag.ToString() == tag.ToString();
            });
        }

        public static object GetFieldTag(object enumValue)
        {
            IList<EnumDescription> source = DoGetFieldTexts(enumValue.GetType());
            if (source == null)
            {
                return null;
            }
            return CollectionConverter.ConvertFirstSpecification<EnumDescription, object>(source, delegate (EnumDescription ed) {
                return ed.Tag;
            }, delegate (EnumDescription ed) {
                return ed.enumValue.ToString() == enumValue.ToString();
            });
        }

        public static string GetFieldText(object enumValue)
        {
            IList<EnumDescription> source = DoGetFieldTexts(enumValue.GetType());
            if (source == null)
            {
                return null;
            }
            return CollectionConverter.ConvertFirstSpecification<EnumDescription, string>(source, delegate (EnumDescription ed) {
                return ed.Description;
            }, delegate (EnumDescription ed) {
                return ed.enumValue.ToString() == enumValue.ToString();
            });
        }

        public override string ToString()
        {
            return this.description;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object EnumValue
        {
            get
            {
                return this.enumValue;
            }
        }

        public object Tag
        {
            get
            {
                return this.tag;
            }
        }
    }
}

