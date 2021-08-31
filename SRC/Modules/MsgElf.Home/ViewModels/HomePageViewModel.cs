using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System = System.Timers;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using MsgElf.Core.Models;

namespace MsgElf.Home.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
        private DispatcherTimer _messageTimer;
        private TimeSpan _nextMessageTime;

        public TimeSpan NextMessageTime
        {
            get => _nextMessageTime;
            set => SetProperty(ref _nextMessageTime, value);
        }

        private ObservableCollection<MessageInfo> _messages;
        public ObservableCollection<MessageInfo> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        private MessageInfo _comingSoon;
        public MessageInfo ComingSoon
        {
            get => _comingSoon;
            set => SetProperty(ref _comingSoon, value);
        }

        public DelegateCommand NewMessageCommand { get; }
        private void NewMessage()
        {
            Messages.Add(new MessageInfo
            {
                Id = Guid.NewGuid(),
                Interval = TimeSpan.FromSeconds(2)
            });
        }

        private void TimerTick(object sender, EventArgs e)
        {
            ComingSoon.Interval -= TimeSpan.FromMilliseconds(10);
            if (ComingSoon.Interval.TotalSeconds > 0) return;

            SendKeys.SendWait(ComingSoon.Text);
            ComingSoon.HasBeenSent = true;

            _messageTimer.Stop();

            if (MoveToNextMessage())
            {
                _messageTimer.Start();
                return;
            }

            ComingSoon = Messages.First();
        }

        private bool MoveToNextMessage()
        {
            int index = Messages.IndexOf(ComingSoon);
            if ((index + 1) == Messages.Count)
                return false;

            ComingSoon = Messages[index + 1];
            return true;
        }

        public DelegateCommand SendCommand { get; }
        private void Send()
        {
            _messageTimer.Start();
        }
        public HomePageViewModel()
        {
            _messageTimer = new DispatcherTimer();
            _messageTimer.Tick += TimerTick;
            _messageTimer.Interval = TimeSpan.FromMilliseconds(10);

            Messages = new ObservableCollection<MessageInfo>();
            NewMessage();
            ComingSoon = Messages.First();
            NewMessageCommand = new DelegateCommand(NewMessage);
            SendCommand = new DelegateCommand(Send);
        }
    }
}
