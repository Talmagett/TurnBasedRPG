using System.Collections.Generic;

namespace Battle.EventBus.Game.Pipeline.Visual.Tasks
{
    public sealed class CompositeVisualTask : Task
    {
        private readonly List<Task> _tasks = new();

        private int _currentIndex;

        public CompositeVisualTask(params Task[] tasks)
        {
            foreach (var task in tasks) _tasks.Add(task);
        }

        protected override void OnRun()
        {
            foreach (var task in _tasks) task.Run(OnTaskFinished);
        }

        private void OnTaskFinished()
        {
            _currentIndex++;
            if (_currentIndex >= _tasks.Count)
                Finish();
        }
    }
}