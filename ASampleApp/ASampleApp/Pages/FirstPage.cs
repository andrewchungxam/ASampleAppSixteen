using System;
using System.Threading.Tasks;
using ASampleApp.BlobStorage;
using ASampleApp.Pages;
using Xamarin.Forms;
namespace ASampleApp
{
	public class FirstPage : BaseContentPage<FirstViewModel>
	{

//        Image _tempImage;
//        String _tempImageSource;

		Label _firstLabel;
		Entry _firstEntry;
        Entry _secondEntry;
		Button _firstButton;
        Button _goToDogListButton;

		Button _addAddDogPhotoButton;
		Button _addAddDogPhotoURLButton;
        Button _goToDogPhotoListButton;

		Button _addAddDogPhotoBase64Button;
		Button _goToDogPhotoBase64ListButton;

        //BLOB STORAGE
        Button _addAddDogPhotoBlobButton;
        Button _goToDogPhotoBlobListButton;

		Label _emptyLabel;
        Label _emptyLabel2;

		public FirstPage ()
		{
 //           _tempImage = new Image();

            this.Title = "A Sample App 16";


			//METHOD#1 non-MVVM
			//BindingContext = new FirstViewModel ();

			_firstLabel = new Label (); //{ Text = "Hello"};
            _firstEntry = new Entry () {Placeholder = "Dog Name"};
            _secondEntry = new Entry() { Placeholder = "Fur color" };
			_firstButton = new Button () { Text = "Submit" };
            _goToDogListButton = new Button () { Text = "Go to Dog List" };
			_emptyLabel = new Label () { Text = " " };
			_emptyLabel2 = new Label() { Text = " " };


            //ADD PHOTO BUTTONS
			_addAddDogPhotoButton = new Button() { Text = "Add Dog Photo" };
            _addAddDogPhotoURLButton = new Button { Text = "Add Dog Photo URL" };
			_addAddDogPhotoBase64Button = new Button { Text = "Add Dog Photo Base64" };
            _addAddDogPhotoBlobButton = new Button() { Text = "Add Dog Photo Blob" }; 
		
			//ADD LIST BUTTON
			_goToDogPhotoListButton = new Button() { Text = "Go to Dog Photo List"};
 //           _goToDogPhotoBase64ListButton = new Button() { Text = "Go to Dog Photo Base64 List" }; 
            _goToDogPhotoBlobListButton = new Button() { Text = "Go to Dog Photo Blob List"};

			//METHOD#2 MVVM
			//
            _firstLabel.SetBinding (Label.TextProperty, nameof (MyViewModel.FirstLabel), BindingMode.TwoWay);
			_firstEntry.SetBinding (Entry.TextProperty, nameof (MyViewModel.FirstEntryText));
			_secondEntry.SetBinding(Entry.TextProperty, nameof(MyViewModel.SecondEntryText));

			_firstButton.SetBinding (Button.CommandProperty, nameof (MyViewModel.MyFavoriteCommand));



            var mainStackLayout = new StackLayout() { 
                Margin = 20,
				Children =
				{
//                    _tempImage,


					_firstLabel,
					_firstEntry,
					_secondEntry,
					_firstButton,
					_goToDogListButton,
					_emptyLabel,
					_addAddDogPhotoButton,
					_addAddDogPhotoURLButton,
					_goToDogPhotoListButton,
					_emptyLabel2,
					//_addAddDogPhotoBase64Button,
					//_goToDogPhotoBase64ListButton
                    _addAddDogPhotoBlobButton,
                    _goToDogPhotoBlobListButton

				}
            
            };

			var myScrollView = new ScrollView() { };
            myScrollView.Content = mainStackLayout;

            Content = myScrollView;

   //         Content = new StackLayout 
   //         {
			//	Margin = 20,
			//	Children =
			//	{
			//		_firstLabel,
			//		_firstEntry,
   //                 _secondEntry,
			//		_firstButton,
			//		_goToDogListButton,
			//		_emptyLabel,
   //                 _addAddDogPhotoButton,
   //                 _addAddDogPhotoURLButton,
   //                 _goToDogPhotoListButton,
   //                 _emptyLabel2,
			//		_addAddDogPhotoBase64Button,
   //                 _goToDogPhotoBase64ListButton


			//	}

			//};
		}

		protected override void OnAppearing ()
		{

            Task.Run(async () => await BlobStorage.AzureBlobStorage.performBlobOperation());

            //            var tempImageSource// = MyClass.getTheUrlFromBlob();

            //            Task.Run(() => _tempImageSource = MyClass.getTheUrlFromBlob());

            //BLOB STORAGE SAMPLE THAT WORKS BUT NOT NEEDED
            //_tempImageSource = BlobStorage.AzureBlobStorage.getTheUrlFromBlob();
			//_tempImage.Source = ImageSource.FromUri(new Uri("https://asampleappfive.blob.core.windows.net/my9container/HelloWorld.png"));


            //VARIATIONS
			//            _tempImage.Source = ImageSource.FromUri(new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"));

			//            _tempImage.Source = new Uri("https://asampleappfive.blob.core.windows.net/my8container/HelloWorld.png")

			//            _tempImage.Source = ImageSource.FromUri(new Uri(_tempImageSource));

			//			_tempImage.Source = new Uri("https://asampleappfive.blob.core.windows.net/my8container/HelloWorld.png");

			//			bitmapImage.UriSource = new Uri("http://sweetapp.blob.core.windows.net/userprofiles/" + imagename, UriKind.RelativeOrAbsolute);
			//https://stackoverflow.com/questions/22014384/getting-images-in-the-azure-blob-storage


			//var bitmapImage = new BitmapImage();
			//bitmapImage.UriSource = new Uri("http://sweetapp.blob.core.windows.net/userprofiles/" + imagename, UriKind.RelativeOrAbsolute);
			//imgProf.Source = bitmapImage;

			base.OnAppearing ();

            if (_firstEntry.Text != null)
            {
                _firstEntry.Text = string.Empty;
            }

            if(_secondEntry.Text != null)
            {
                _secondEntry.Text = string.Empty;
            }



			//METHOD 1
			//			_firstButton.Clicked += OnFirstButtonClicked;

			_goToDogListButton.Clicked += OnToDogListClicked;
			_addAddDogPhotoButton.Clicked += OnAddDogPhotoButtonClicked;
			_addAddDogPhotoURLButton.Clicked += OnAddDogPhotoURLButtonClicked;
            _addAddDogPhotoBase64Button.Clicked += OnAddDogPhotoBase64ButtonClicked;
			_goToDogPhotoListButton.Clicked += OnAddDogPhotoListLButtonClicked;

	//		_goToDogPhotoBase64ListButton.Clicked += OnAddDogPhotoBase64ListButtonClicked;



            _addAddDogPhotoBlobButton.Clicked += OnAddDogPhotoBlobButtonClicked;
            _goToDogPhotoBlobListButton.Clicked += OnAddDogPhotoBlogListButtonClicked;



		}



        protected override void OnDisappearing ()
		{
			base.OnDisappearing ();



			//METHOD 1

			//			_firstButton.Clicked -= OnFirstButtonClicked;

			_goToDogListButton.Clicked -= OnToDogListClicked;
            _addAddDogPhotoButton.Clicked -= OnAddDogPhotoButtonClicked;
			_addAddDogPhotoURLButton.Clicked -= OnAddDogPhotoURLButtonClicked;
			_addAddDogPhotoBase64Button.Clicked -= OnAddDogPhotoBase64ButtonClicked;
			_goToDogPhotoListButton.Clicked -= OnAddDogPhotoListLButtonClicked;
	//		_goToDogPhotoBase64ListButton.Clicked -= OnAddDogPhotoBase64ListButtonClicked;


			_addAddDogPhotoBlobButton.Clicked -= OnAddDogPhotoBlobButtonClicked;
			_goToDogPhotoBlobListButton.Clicked -= OnAddDogPhotoBlogListButtonClicked;


		}


		private void OnAddDogPhotoButtonClicked(object sender, EventArgs e)
        {
//            throw new NotImplementedException();
            Device.BeginInvokeOnMainThread(()=> Navigation.PushAsync(new AddPuppyPhotoPage()));
        }

		void OnAddDogPhotoURLButtonClicked (object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread (()=>Navigation.PushAsync (new AddDogPhotoURLPage()));	
		}





		//ADD PHOTO
		private void OnAddDogPhotoBase64ButtonClicked(object sender, EventArgs e)
		{
			Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new AddDogPhotoBaseSixtyFourPage()));
		}



		private void OnAddDogPhotoBlobButtonClicked(object sender, EventArgs e)
		{

            Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new AddDogPhotoBlobPage()));

			//          Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new AddDogPhotoBlobPage()));
			//          throw new NotImplementedException();
		}


		private void OnAddDogPhotoBlogListButtonClicked(object sender, EventArgs e)
		{
            Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(App.MyDogListPhotoBlobPage));

			//          Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(App.MyDogListPhotoBlobPage));
			//          throw new NotImplementedException();
		}




		void OnToDogListClicked(object sender, EventArgs e)
		{
			//OPTION 1
			//Device.BeginInvokeOnMainThread (() => Navigation.PushAsync (new DogListPage ()));

			//OPTION 2
            Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(App.MyDogListMVVMPage));
		}



		void OnAddDogPhotoListLButtonClicked(object sender, EventArgs e)
		{
			//Option 1 - creating a new DogListPhotoPage
			//THIS OPTION IS NOT COMPATIBLE WITH //ADD DOG TO OBSERVABLE COLLECTION OF THE LISTVIEW
			//Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new DogListPhotoPage()));

			//TODO - using a static DogListPhotoPage
			//Option 2 - using a static DogListPhotoBase64Page
            Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(App.MyDogListPhotoPage));

		}

		//LIST
		void OnAddDogPhotoBase64ListButtonClicked(object sender, EventArgs e)
		{
			//Option 1 - creating a new DogListPhotoPage
			//Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(new DogListPhotoBase64Page()));

			//TODO - using a static DogListPhotoBase64Page
			//Option 2 - using a static DogListPhotoBase64Page
			Device.BeginInvokeOnMainThread(() => Navigation.PushAsync(App.MyDogListPhotoBase64Page));

		}






		//EventHandler OnToDogListClicked ()
		//{
		//	//throw new NotImplementedException ();
		//	Device.BeginInvokeOnMainThread (()=> Navigation.PushAsync (new DogListPage()));
		//}

		//void OnFirstButtonClicked (object sender, EventArgs e)
		//{
		//	Console.WriteLine ("Hello there;");
		//	string ft = _firstEntry.Text;

		//	//SIMPLE ACTION 1
		//	//Device.BeginInvokeOnMainThread (() => 
		//	//                                _firstLabel.Text = ft
		//	//                               );

		//	//SIMPLE ACTION 2
		//	//ViewModel.FirstLabel = "hi there!";

		//}
	}
}
