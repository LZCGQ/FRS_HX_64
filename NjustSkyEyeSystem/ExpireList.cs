using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjustSkyEyeSystem
{
    class ExpiringVector<T>
    {
        class Entity<T>
        {
            public Entity()
            {
                Timestamp = DateTime.Now;
            }
            public Entity(T obj)
            {
                Obj = obj;
                Timestamp = DateTime.Now;
            }
            /// <summary>
            /// 用户信息
            /// </summary>
            public T Obj { get; set; }

            /// <summary>
            /// 添加到列表的时间戳
            /// </summary>
            public DateTime Timestamp { get; set; }
        }
       
    /// <summary>
    /// 链表最大长度
    /// </summary>
        public int MaxLength {
            get { return maxLenght; }
            set { maxLenght = value; }
        }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length
        {
            get { return content.Count; }
            
        }
        /// <summary>
        /// 链表中对象过期时间
        /// </summary>
        public TimeSpan Expiration
        {
            get { return expirationSpan; }
            set { expirationSpan = value; }
        }
        /// <summary>
        /// 最大长度
        /// </summary>
        private int  maxLenght=0;
        /// <summary>
        /// 过期时长
        /// </summary>
        private TimeSpan expirationSpan = new TimeSpan(0, 0, 0);
        /// <summary>
        /// 存储内容
        /// </summary>
        private HashSet<Entity<T>> content;

      
        private Func<T, T, int> cmp =null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxLenght">最大长度</param>
        /// <param name="expirationSpan">过期事件</param>
        /// <param name="cmp">比较函数</param>
        public ExpiringVector(int maxLenght, TimeSpan expirationSpan,Func<T,T,int> cmp)
        {
            this.maxLenght = maxLenght;
            this.expirationSpan = expirationSpan;
            content = new HashSet<Entity<T>>();
            this.cmp = cmp;
        }
        /// <summary>
        /// 添加一个元素
        /// </summary>
        /// <param name="obj"></param>
        public void Add(T obj)
        {
            lock (this)
            {
                Entity<T> en = new Entity<T>(obj);
                if (content.Count < maxLenght)

                    content.Add(en);
                else
                {
                    RemoveOne();
                    content.Add(en);
                }
            }
        }
        /// <summary>
        /// 移除时间最早的一个
        /// </summary>
        private void RemoveOne()
        {
            lock (this)
            {
                
                Entity<T> cache = content.ElementAt<Entity<T>>(0);
                foreach (var e in content)
                {
                    if (DateTime.Compare(cache.Timestamp, e.Timestamp) < 0)
                    {
                        cache = e;
                    }
                }
                content.Remove(cache);
            }
        }
        /// <summary>
        /// 判断是否包含某元素
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsContain(T obj)
        {
            lock (this)
            {
                bool res = false;
                List<Entity<T>> removeList = new List<Entity<T>>();
                foreach (var e in content)
                {
                    if (DateTime.Now.Subtract(e.Timestamp) > expirationSpan)
                    {
                        removeList.Add(e);
                        
                        continue;
                    }
                    if (cmp(e.Obj, obj) == 0)
                    {
                        res = true;
                        break;
                    }
                }
                foreach (var e in removeList)
                {
                    content.Remove(e);
                }
                Add(obj);
                return res;
            }
        }

    }
}
