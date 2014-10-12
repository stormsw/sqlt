using System;
using System.ComponentModel;

namespace SQLt.DataModel
{
    [Serializable]
    public class InformixConnectionAttributes : INotifyPropertyChanged
    {
        private string server;
        private string user;
        private string password;
        private string instance;

        public string Server
        {
            get { return server; }
            set
            {
                server = value;
                OnPropertyChanged("Server");
            }
        }

        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                OnPropertyChanged("Instance");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string attribute)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(attribute));
            }
        }
    }
}