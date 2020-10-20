namespace CJBasic.ObjectManagement.Increasing
{
    using System;

    public class SingleSource
    {
        private static SingleSource singleton = new SingleSource();

        private SingleSource()
        {
        }

        public static SingleSource Singleton
        {
            get
            {
                return singleton;
            }
        }
    }
}

