using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASampleApp.BlobStorage;
using ASampleApp.Data;
using ASampleApp.Models;
using ASampleApp.Pages;
using Microsoft.WindowsAzure.Storage.Blob;
using Xamarin.Forms;

namespace ASampleApp
{
    public class App : Application
    {

        public static DogRepository DogRep { get; private set; }
        public static DogPhotoRepository DogPhotoRep { get; set; }
        public static DogRepositoryBaseSixtyFour DogRepBaseSixtyFour { get; private set; }
		public static DogRepositoryBlob DogRepBlob { get; private set; }

		public static DogListMVVMPage MyDogListMVVMPage { get; set; }
        public static DogListPhotoPage MyDogListPhotoPage { get; set; }
        public static DogListPhotoBase64Page MyDogListPhotoBase64Page  { get;set;}
		public static DogListPhotoBlobPage MyDogListPhotoBlobPage { get; set; }



		public static CloudBlobClient MyCloudBlobClient { get; set; }

        public static CloudBlobContainer MyCloudBlobContainer { get; set; }

        public static AzureBlobStorage MyAzureBlobStorage { get; set; }

        public static String ContainerName = "my10container";

        public App ()
		{


            //MAKE THIS ASYNC AND PULL THIS OUT OF THE CONSTRUCTOR
            MyAzureBlobStorage = new AzureBlobStorage();
            MyCloudBlobClient = MyAzureBlobStorage.CreateCloudBlobClient();
            MyCloudBlobContainer = MyAzureBlobStorage.CreateCloudBlobClientAndContainer(ContainerName);

            string dbPath = FileAccessHelper.GetLocalFilePath("adog2.db3");
            //USE THIS FOR LIST PAGE
            DogRep = new DogRepository(dbPath);

			//USE THIS FOR LIST PHOTO PAGE
			DogPhotoRep = new DogPhotoRepository(dbPath);

            //USE THIS FOR LIST PHOTO BASE SIXTY FOUR PAGE
            DogRepBaseSixtyFour = new DogRepositoryBaseSixtyFour(dbPath);

            DogRepBlob = new DogRepositoryBlob(dbPath);

			var applicationStartPage = new FirstPage ();

            var myNavigationPage = new NavigationPage(applicationStartPage);
            MainPage = myNavigationPage;

            //Initialize Dog Photo View Page
		    MyDogListMVVMPage = new DogListMVVMPage();
            MyDogListPhotoPage = new DogListPhotoPage();
            MyDogListPhotoBase64Page = new DogListPhotoBase64Page();
			MyDogListPhotoBlobPage = new DogListPhotoBlobPage();

		}


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
