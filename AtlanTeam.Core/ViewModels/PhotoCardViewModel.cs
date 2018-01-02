using MvvmCross.Core.ViewModels;
using System;

namespace AtlanTeam.Core.ViewModels
{
    public class PhotoCardViewModel : MvxViewModel
    {

        public PhotoCardViewModel()
        {
            ImageUrl = string.Format("http://placekitten.com/500/500/?image={0}", Random(16));
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { SetProperty(ref _imageUrl, value); }
        }

        private readonly Random _random = new Random(DateTime.Now.Millisecond);
        protected int Random(int count)
        {
            return _random.Next(count);
        }
    }
}
