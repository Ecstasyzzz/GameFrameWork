using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFramework
{
    /// <summary>
    /// 定时器
    /// </summary>
    public class TimeAction
    {
        #region 参数
        // 开始运行
        public Action onStart;

        // 运行中
        public Action<int> onUpdate;

        // 运行结束
        public Action onComplete;

        // 是否运行中
        public bool IsRuning { get; private set; }

        // 当前运行的时间
        private float currRunTime;

        // 当前循环次数
        private int currLoop;

        // 延迟时间
        private float delayTime;

        // 间隔(s)
        private float interval;

        // 总循环次数(-1表示无限循环 0也会循环一次)
        private int loop;

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="delayTime">延迟时间</param>
        /// <param name="interval">间隔</param>
        /// <param name="loop">总循环次数(-1表示无限循环 0也会循环一次)</param>
        /// <param name="onStart">开始循环的回调</param>
        /// <param name="onUpdate">每次循环的回调</param>
        /// <param name="onComplete">结束循环的回调</param>
        /// <returns>TimeAction</returns>
        public TimeAction Init(float delayTime, float interval, int loop, Action onStart = null, Action<int> onUpdate = null, Action onComplete = null)
        {
            this.delayTime = delayTime;
            this.interval = interval;
            this.loop = loop;
            this.onStart = onStart;
            this.onUpdate = onUpdate;
            this.onComplete = onComplete;
            return this;
        }

        // 运行
        public void Run()
        {
            // 需要把自己加入到TimeManager的时间列表中
            GameEntry.TimeComponent.RegisterTimeAction(this);

            currRunTime = Time.time;

            //IsRuning = true; // 错误写法，应该在延迟时间结束后才真正开始执行
        }

        // 暂停
        public void Pause()
        {
            IsRuning = false;
        }

        // 停止
        public void Stop()
        {
            onComplete?.Invoke();

            IsRuning = false;

            GameEntry.TimeComponent.RemoveTimeAction(this); // 把自己从定时器列表中移除
        }

        //
        public void OnUpdate()
        {
            float worldTime = Time.time;

            // 第一次过了延迟时间
            if(!IsRuning && worldTime > currRunTime + delayTime)
            {
                IsRuning = true;
                currRunTime = worldTime;
                onStart?.Invoke();
            }

            if (!IsRuning) return;

            if (worldTime >= currRunTime)
            {
                currRunTime = worldTime + interval;

                onUpdate?.Invoke(loop - currLoop);

                if (loop > -1)
                {
                    currLoop++;

                    if (currLoop >= loop)
                    {
                        this.Stop();
                    }
                }
            }
        }
    }
}

