using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsgElf.Core.Models
{
    public class MessageInfo : BindableBase
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private TimeSpan _interval;
        public TimeSpan Interval
        {
            get => _interval;
            set => SetProperty(ref _interval, value);
        }

        private bool _hasBeenSent;
        public bool HasBeenSent
        {
            get => _hasBeenSent;
            set => SetProperty(ref _hasBeenSent, value);
        }
    }
}
