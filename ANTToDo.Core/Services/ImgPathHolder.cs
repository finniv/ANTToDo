using System.ComponentModel;
using System.Runtime.CompilerServices;
using ANTToDo.Core.Annotations;

namespace ANTToDo.Core.Services
{
    public class ImgPathHolder:INotifyPropertyChanged
    {
        public static string Current = new ImgPathHolder().ImgPathString;

        private  string _imgPathString;
        public  string ImgPathString
        {
            get
            {
                return _imgPathString; 

            }
            set
            {
                _imgPathString = value;
                OnImgPathChanged("ImgPathString");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnImgPathChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}