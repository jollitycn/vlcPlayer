namespace CJBasic.Threading.Engines
{
    using CJBasic;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class SequentialEngine : ISequentialEngine, IEngineTacheUtil
    {
        private IEngineTache currentTache;
        private IDictionary<string, object> dicUtil = new Dictionary<string, object>();
        private IList<IEngineTache> engineTacheList;
        private bool hasNecceryEnder = false;
        private bool running = false;

        public event CbSimple EngineCompleted;

        public event CbSimpleStr EngineDisruptted;

        public event CbSimpleObj EngineStatusChanged;

        public event CbSimpleStr IgnoredMessagePublished;

        public event CbSimpleStr MessagePublished;

        public event CbProgress PartProgressPublished;

        public event CbSimpleStr TitleChanged;

        public void Clear()
        {
            this.dicUtil.Clear();
        }

        public void Continue()
        {
            if (this.currentTache != null)
            {
                this.currentTache.Continue();
            }
        }

        public void Excute()
        {
            if (!this.running)
            {
                this.running = true;
                new CbSimple(this.Worker).BeginInvoke(new AsyncCallback(this.WorkerCallBack), null);
            }
        }

        public IEngineTache GetEngineTache(int tacheID)
        {
            foreach (IEngineTache tache in this.engineTacheList)
            {
                if (tache.EngineTacheID == tacheID)
                {
                    return tache;
                }
            }
            return null;
        }

        public object GetObject(string name)
        {
            if (!this.dicUtil.ContainsKey(name))
            {
                return null;
            }
            return this.dicUtil[name];
        }

        public void Initialize(IList<IEngineTache> tacheList, bool has_NecceryEnder)
        {
            this.hasNecceryEnder = has_NecceryEnder;
            this.engineTacheList = tacheList;
            this.InitializeEventHandler();
            foreach (IEngineTache tache in this.engineTacheList)
            {
                tache.Initialize(this);
                tache.IgnoredMessagePublished += new CbSimpleStr(this.tache_IgnoredMessagePublished);
                tache.ProgressPublished += new CbProgress(this.tache_ProgressPublished);
                tache.MessagePublished += new CbSimpleStr(this.tache_MessagePublished);
                tache.EngineStatusChanged += new CbSimpleObj(this.tache_EngineStatusChanged);
            }
        }

        private void InitializeEventHandler()
        {
            this.PartProgressPublished += delegate {
            };
            this.MessagePublished += delegate {
            };
            this.IgnoredMessagePublished += delegate {
            };
            this.EngineCompleted += delegate {
            };
            this.EngineDisruptted += delegate {
            };
            this.TitleChanged += delegate {
            };
            this.EngineStatusChanged += delegate {
            };
        }

        public void Pause()
        {
            if (this.currentTache != null)
            {
                this.currentTache.Pause();
            }
        }

        public void RegisterObject(string name, object obj)
        {
            this.dicUtil.Add(name, obj);
        }

        public void Remove(string name)
        {
            if (this.dicUtil.ContainsKey(name))
            {
                this.dicUtil.Remove(name);
            }
        }

        public void Stop()
        {
            if (this.currentTache != null)
            {
                this.currentTache.Stop();
            }
        }

        private void tache_EngineStatusChanged(object obj)
        {
            this.EngineStatusChanged(obj);
        }

        private void tache_IgnoredMessagePublished(string str)
        {
            this.IgnoredMessagePublished(str);
        }

        private void tache_MessagePublished(string str)
        {
            this.MessagePublished(str);
        }

        private void tache_ProgressPublished(int val, int total)
        {
            this.PartProgressPublished(val, total);
        }

        private void Worker()
        {
            string failureCause = "";
            for (int i = 0; i < this.engineTacheList.Count; i++)
            {
                this.currentTache = this.engineTacheList[i];
                this.TitleChanged(this.currentTache.Title);
                bool flag = false;
                try
                {
                    flag = this.currentTache.Excute(out failureCause);
                }
                catch (Exception exception)
                {
                    failureCause = failureCause + string.Format("EngineTache({0}) Exception Message : {1}", this.currentTache.EngineTacheID, exception.Message);
                }
                if (!flag)
                {
                    if (this.hasNecceryEnder && (i != (this.engineTacheList.Count - 1)))
                    {
                        string str2 = null;
                        this.currentTache = this.engineTacheList[this.engineTacheList.Count - 1];
                        this.currentTache.Excute(out str2);
                    }
                    this.EngineDisruptted(failureCause);
                    return;
                }
            }
            this.EngineCompleted();
        }

        private void WorkerCallBack(IAsyncResult res)
        {
            this.running = false;
        }

        public bool Running
        {
            get
            {
                return this.running;
            }
        }
    }
}

