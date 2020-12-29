using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Mvvm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Mvvm.ViewModels
{
    public class MvvmViewModel : BindableBase
    {
        private string title = "MVVM";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }

        public MvvmViewModel(IEventAggregator eventAggregator)
        {
            #region DelegateCommand

            ClickCommand = new DelegateCommand(() =>
              {
                  Content = "Clear content!";
              });

            ClickTCommand = new DelegateCommand<string>(arg =>
              {
                  Content += $"{arg}\r\n";
              });

            #endregion

            #region CompositeCommand

            Command1 = new DelegateCommand(() =>
            {
                Content += "Command1\r\n";
            }).ObservesCanExecute(() => Cmd1CanUpdate);
            Command2 = new DelegateCommand(() =>
            {
                Content += "Command2\r\n";
            }).ObservesCanExecute(() => Cmd2CanUpdate);

            CommandAll = new CompositeCommand();
            CommandAll.RegisterCommand(Command1);
            CommandAll.RegisterCommand(Command2);

            #endregion

            #region IEventAggregator

            PublishCommand = new DelegateCommand<string>(PublishMessage);
            SubscribeCommand = new DelegateCommand(SubscribeMessage);
            UnsubscribeCommand = new DelegateCommand(UnsubscribeMessage);
            FilterCommand = new DelegateCommand(Filter);
            this.eventAggregator = eventAggregator;

            #endregion
        }

        #region DelegateCommand

        public DelegateCommand ClickCommand { get; private set; }

        public DelegateCommand<string> ClickTCommand { get; private set; }

        #endregion

        #region CompositeCommand

        private bool cmd1CanUpdate = true;
        private bool cmd2CanUpdate = true;
        private readonly IEventAggregator eventAggregator;

        public bool Cmd1CanUpdate
        {
            get { return cmd1CanUpdate; }
            set { cmd1CanUpdate = value; RaisePropertyChanged(); }
        }

        public bool Cmd2CanUpdate
        {
            get { return cmd2CanUpdate; }
            set { cmd2CanUpdate = value; RaisePropertyChanged(); }
        }


        public CompositeCommand CommandAll { get; private set; }
        public DelegateCommand Command1 { get; private set; }
        public DelegateCommand Command2 { get; private set; }

        #endregion

        #region IEventAggregator

        public DelegateCommand<string> PublishCommand { get; private set; }
        public DelegateCommand SubscribeCommand { get; private set; }
        public DelegateCommand UnsubscribeCommand { get; private set; }

        public DelegateCommand FilterCommand { get; private set; }

        void SubscribeMessage()
        {
            this.UnsubscribeMessage();

            eventAggregator.GetEvent<MessageEvent>().Subscribe(OnMessageReceived);
        }

        void UnsubscribeMessage()
        {
            eventAggregator.GetEvent<MessageEvent>().Unsubscribe(OnMessageReceived);
        }

        void PublishMessage(string message)
        {
            eventAggregator.GetEvent<MessageEvent>().Publish(message);
        }

        /// <summary>
        /// Filter
        /// </summary>
        private void Filter()
        {
            //Unsubscribe
            eventAggregator.GetEvent<MessageEvent>().Unsubscribe(OnMessageReceived);

            //Filtering Events
            eventAggregator.GetEvent<MessageEvent>()
                .Subscribe(OnMessageReceived, ThreadOption.PublisherThread, false, msg =>
                {
                    if (msg.Equals("Hello")) return true;
                    else
                    {
                        Content += $"{DateTime.Now} : Filter data :{msg} \r\n";
                        return false;
                    }
                });
        }

        void OnMessageReceived(string message)
        {
            Content += $"{DateTime.Now} Subscribe : {message} \r\n";
        }

        #endregion
    }
}
