using System;
using System.Collections.Generic;

namespace Battle.EventBus.Game.Pipeline
{
    public class Pipeline
    {
        private readonly List<Task> _tasks = new();

        private int _currentIndex;
        public event Action OnFinished;

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public void Clear()
        {
            _tasks.Clear();
        }

        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _tasks.Count)
            {
                OnFinished?.Invoke();
                return;
            }

            _tasks[_currentIndex].Run(OnTaskFinished);
        }

        private void OnTaskFinished()
        {
            _currentIndex++;
            RunNextTask();
        }
    }
}