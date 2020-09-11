using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpfclient.ViewModels
{
    class BaseViewModel : Screen
    {
      
        protected readonly IEventAggregator events;

        public IEventAggregator EventAggregator => events;

        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Default constructs without event aggregator.
        /// </summary>
        public BaseViewModel()
        {
            
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="events"></param>
        public BaseViewModel(IEventAggregator events)
        {
            this.events = events;
            events?.Subscribe(this);
        }

        /// <summary>
        /// Publishes an event message on UI thread.
        /// </summary>
        /// <param name="eventMessage"></param>
        protected void PublishOnUIThread(object eventMessage)
        {
            events?.PublishOnUIThread(eventMessage);
        }

        /// <summary>
        /// Publishes an event message on a background thread.
        /// </summary>
        /// <param name="eventMessage"></param>
        protected void PublishOnBackgroundThread(object eventMessage)
        {
            events?.PublishOnBackgroundThread(eventMessage);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            events?.Unsubscribe(this);

            if (GetView() is IHandle view)
            {
                events?.Unsubscribe(view);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);

            if (view is IHandle)
            {
                events?.Unsubscribe(view);
                events?.Subscribe(view);
            }
        }
    }
}
