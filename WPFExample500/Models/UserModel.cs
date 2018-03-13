namespace WPFExample500.Models
{
    public class UserModel : PropChanged

    {
        private string _username;
        public string FK_Username
        {
            get
            {
                //if (string.IsNullOrEmpty(_Username))
                //    return "Unknown";
                return _username;
            }
            set
            {
                _username = value;
                NotifyPropertyChanged("FK_Username");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private string _profilename;
        public string Profilename
        {
            get
            {
                return _profilename;
            }
            set
            {
                _profilename = value;
                NotifyPropertyChanged("Profilename");
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                //if (string.IsNullOrEmpty(_Username))
                //    return "Unknown";
                return _email;
            }
            set
            {
                _email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private string _picture;
        public string Picture
        {
            get
            {
                //if (string.IsNullOrEmpty(_Username))
                //    return "Unknown";
                return _picture;
            }
            set
            {
                _picture = value;
                NotifyPropertyChanged("Picture");
            }
        }

        private string _gender;

        public string Gender { get { return _gender; } set { _gender = value; NotifyPropertyChanged("Gender"); } }

        private string _haircolor;

        public string Haircolor { get { return _haircolor; } set { _haircolor = value; NotifyPropertyChanged("Haircolor"); } }



    }



    //public class Gender : PropChange
    //    {

    //    private List<> _gender;
    //    public string Gender { get { return _gender; } set { _gender = value; OnPropertyChanged("Gender"); } }


    //}






    //public class PropChange
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected void OnPropertyChanged(string name)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(name));
    //        }
    //    }

    //}


}
