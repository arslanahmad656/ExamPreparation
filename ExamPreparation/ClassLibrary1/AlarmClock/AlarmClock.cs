using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.AlarmClock
{
    class AlarmClock
    {
        private static int _interval;
        private object _lock = new object();
        private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private Task _clockRunner;

        public Action OnAlarmRaised;

        public int Interval
        {
            get => _interval;
            set => _interval = value;
        }

        public AlarmClock(int intervalMilliseconds)
        {
            _interval = intervalMilliseconds;
        }

        public bool StartClock()
        {
            if (_clockRunner == null)
            {
                _clockRunner = new Task(() =>
                {
                    OnAlarmRaised?.Invoke();
                    Thread.Sleep(Interval);
                }, _cancellationToken.Token);
            }

            if (_clockRunner.Status == TaskStatus.Running)
            {
                return false;
            }

            _clockRunner.Start();
            return true;
        }

        public bool StopClock()
        {
            if (_clockRunner != null && _clockRunner.Status == TaskStatus.Running)
            {
                _cancellationToken.Cancel();
                return true;
            }

            return false;
        }
    }
}
