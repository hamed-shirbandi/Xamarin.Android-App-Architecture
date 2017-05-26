using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using DataService.Users;
using System.IO;
using DataAccess.Domain;
using DataAccess.DbContext;
using System.Linq;
using Common.Models.Users;
using RestService.UserManagement;

namespace NotesAnnalist
{
    [Activity(Label = "Notes Annalist", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        #region Properties

        private readonly IUserDataService _userService;
        private readonly IRegistrationApiService _registrationApiService;
        private ListView userListView;
        private Button btn_add;
        private Button btn_clear_all;
        private EditText txt_name;
        private ArrayAdapter<string> adapter;
        private IEnumerable<string> usersList;
        private string dbPath;

        #endregion

        #region Ctor

        public MainActivity()
        {
            dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "userDb.db3");
            _userService = new UserDataService(dbPath);
            _registrationApiService = new RegistrationApiService();
        }




        #endregion



        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            CreateDatabase();

            btn_add = FindViewById<Button>(Resource.Id.btn_add);
            btn_add.Click += Btn_add_Click;

            btn_clear_all = FindViewById<Button>(Resource.Id.btn_clear_all);
            btn_clear_all.Click += Btn_clear_all_Click;
            userListView = FindViewById<ListView>(Resource.Id.user_list_view);
            userListView.ItemClick += UserListView_ItemClick;

            ShowUsersListInListView();

        }






        /// <summary>
        /// 
        /// </summary>
        private void Btn_clear_all_Click(object sender, EventArgs e)
        {
            _userService.DeleteAll();
            ShowUsersListInListView();
        }



        /// <summary>
        /// 
        /// </summary>
        private void ShowUsersListInListView()
        {
            usersList = _userService.SearchName(name: "");

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, usersList.ToArray());
            userListView.Adapter = adapter;
        }




        /// <summary>
        /// 
        /// </summary>
        private void Btn_add_Click(object sender, EventArgs e)
        {
            var txt_name = FindViewById<EditText>(Resource.Id.txt_name);
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                txt_name.Error = "please insert user name";
                return;
            }

            var result = _registrationApiService.CheckUserName(userName:txt_name.Text);
            if (result==false)
            {
                txt_name.Error = "this userName taken !!!";
                return;
            }


            var user = new UserInput
            {
                UserName = txt_name.Text,
                Name = txt_name.Text,
                Family = txt_name.Text,
            };

            _userService.Create(user);
            ShowUsersListInListView();
        }





        /// <summary>
        /// 
        /// </summary>
        private void UserListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Position + " clicked", ToastLength.Short).Show();
        }




        /// <summary>
        /// First Inint Database 
        /// </summary>
        private void CreateDatabase()
        {
            var con = new MainContext(dbPath);
            con.CreateDatabase();
            con.Seed();
        }
    }
}

