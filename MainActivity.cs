using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.Animations;
using System.Linq;
using Android.Graphics;
 
namespace AndroidGesture
{
  [Activity ( Label = "SlidingMenu" , MainLauncher = true , Icon = "@drawable/icon" )]
  public class MainActivity : Activity { 
    public GestureDetector gestureDetector;
    GestureListener gestureListener;

    ListView menuListView; 
    MenuListAdapterClass objAdapterMenu;
    ImageView menuIconImageView;
    int intDisplayWidth;
    bool isSingleTapFired=false;
    TextView txtActionBarText;
    ListView txtPageName;
    TextView txtDescription;
    ImageView btnDescExpander;

    protected override void OnCreate ( Bundle bundle ) {
      base.OnCreate ( bundle );
      Window.RequestFeature ( WindowFeatures.NoTitle );
      SetContentView ( Resource.Layout.Main ); 
      FnInitialization (); 
      TapEvent ();  
      FnBindMenu (); 
    }


    void TapEvent() {
      menuIconImageView.Click += delegate(object sender , EventArgs e ) {
        if ( !isSingleTapFired ) {
//          FnToggleMenu ();
//          isSingleTapFired = false;
        }
      };
      btnDescExpander.Click += delegate(object sender , EventArgs e ) {
        FnDescriptionWindowToggle();
      };
    }


    void FnInitialization() {
      //gesture initialization
      gestureListener = new GestureListener ();  
      gestureListener.LeftEvent += GestureLeft; 
      gestureListener.RightEvent += GestureRight; 
      gestureListener.SingleTapEvent += SingleTap;  
      gestureDetector = new GestureDetector (this,gestureListener);
 
      menuListView = FindViewById<ListView> ( Resource.Id.menuListView );
      menuIconImageView = FindViewById<ImageView> ( Resource.Id.menuIconImgView );
      txtActionBarText = FindViewById<TextView> ( Resource.Id.txtActionBarText );
      txtPageName = FindViewById<ListView> ( Resource.Id.txtPage );
      string[] strMnuText={"Home","AboutUs","Products","Events","Serivce","Clients","Help","Solution","ContactUs"};
      ItemTouchListener itl = new ItemTouchListener(menuListView);
      ListAdapterClass adapter = new ListAdapterClass(this, strMnuText, itl);
      isSingleTapFired = itl.clgt;
      txtPageName.Adapter = adapter;

      txtDescription=FindViewById<TextView> ( Resource.Id.txtDescription );
      btnDescExpander =FindViewById<ImageView> ( Resource.Id.btnImgExpander );
      //changed sliding menu width to 1/3 of screen width 
      Display display = this.WindowManager.DefaultDisplay; 
      var point = new Point ();
      display.GetSize (point);
      intDisplayWidth = point.X;
      intDisplayWidth=intDisplayWidth - (intDisplayWidth/3);
      using ( var layoutParams = ( RelativeLayout.LayoutParams ) menuListView.LayoutParameters  ) {
        layoutParams.Width = intDisplayWidth;
        layoutParams.Height = ViewGroup.LayoutParams.MatchParent;
        menuListView.LayoutParameters = layoutParams;
      } 
      //menuListView.LayoutParameters = new RelativeLayout.LayoutParams(intDisplayWidth, ViewGroup.LayoutParams.MatchParent);
    }


    void FnBindMenu() {  
      string[] strMnuText={"Home","AboutUs","Products","Events","Serivce","Clients","Help","Solution","ContactUs"};
      int [] strMnuUrl={Resource.Drawable.icon_home,Resource.Drawable.icon_aboutus,Resource.Drawable.icon_product,Resource.Drawable.icon_event,Resource.Drawable.icon_service,Resource.Drawable.icon_client,Resource.Drawable.icon_help,Resource.Drawable.icon_solution,Resource.Drawable.icon_contactus}; 
      if ( objAdapterMenu != null ) {
        objAdapterMenu.actionMenuSelected -= FnMenuSelected;
        objAdapterMenu = null;
      }
      objAdapterMenu = new MenuListAdapterClass (this,strMnuText,strMnuUrl); 
      objAdapterMenu.actionMenuSelected += FnMenuSelected;
      menuListView.Adapter = objAdapterMenu;   
    }


    void FnMenuSelected(string strMenuText) {
      txtActionBarText.Text = strMenuText;
    }


    void FnToggleMenu() {
      Console.WriteLine ( menuListView.IsShown );
      if(menuListView.IsShown) { 
        menuListView.Animation = new  TranslateAnimation ( 0f , -menuListView.MeasuredWidth , 0f , 0f );
        menuListView.Animation.Duration = 1000;
        menuListView.Visibility = ViewStates.Gone;  
      } else {  
        menuListView.Visibility =   ViewStates.Visible; 
        menuListView.RequestFocus (); 
        menuListView.Animation = new  TranslateAnimation ( -menuListView.MeasuredWidth, 0f , 0f , 0f );//starting edge of layout 
        menuListView.Animation.Duration = 1000;  
      }
    } 


    void GestureLeft() {
      if(!menuListView.IsShown)
        FnToggleMenu (); 
      isSingleTapFired = false; 
    }


    void GestureRight() {
      if(menuListView.IsShown)
        FnToggleMenu (); 
      isSingleTapFired = false; 
    }


    void SingleTap() {
      if ( menuListView.IsShown ) {
        FnToggleMenu ();
        isSingleTapFired = true;
      } else {
        isSingleTapFired = false;
      }
    }


//    public override bool DispatchTouchEvent (MotionEvent ev) {
//      gestureDetector.OnTouchEvent ( ev );
//      return base.DispatchTouchEvent (ev); 
//    }



    void FnDescriptionWindowToggle() {
      if(txtDescription.IsShown) {
        txtDescription.Visibility = ViewStates.Gone; 
        txtDescription.Animation = new  TranslateAnimation ( 0f ,0f,0f,txtDescription.MeasuredHeight  );
        txtDescription.Animation.Duration = 300;
        btnDescExpander.SetImageResource ( Resource.Drawable.up_arrow ); 
      } else {    
        txtDescription.Visibility =   ViewStates.Visible;
        txtDescription.RequestFocus (); 
        txtDescription.Animation = new  TranslateAnimation ( 0f , 0f ,txtDescription.MeasuredHeight,0f);
        txtDescription.Animation.Duration = 300;   
        btnDescExpander.SetImageResource ( Resource.Drawable.down_arrow );
      }
    }
  }


  public class MenuListAdapterClass : BaseAdapter<string> {
    Activity _context; 
    string[] _mnuText;
    int[] _mnuUrl;  
    internal event Action<string> actionMenuSelected;
    public MenuListAdapterClass(Activity context,string[] strMnu,int[] intImage)
    { 
      _context = context; 
      _mnuText = strMnu;
      _mnuUrl = intImage; 
    } 
    public override string this[int position]
    {
      get { return this._mnuText[position]; }
    }

    public override int Count
    {
      get { return this._mnuText.Count(); }
    }


    public override long GetItemId(int position)
    {
      return position;
    } 


    public override View GetView(int position, View convertView, ViewGroup parent) {    
      MenuListViewHolderClass objMenuListViewHolderClass;
      View view;
      view = convertView;
      if ( view == null ) {
        view= _context.LayoutInflater.Inflate ( Resource.Layout.MenuCustomLayout , parent , false ); 
        objMenuListViewHolderClass = new MenuListViewHolderClass (); 

        objMenuListViewHolderClass.txtMnuText = view.FindViewById<TextView> ( Resource.Id.txtMnuText );
        objMenuListViewHolderClass.ivMenuImg=view.FindViewById<ImageView> ( Resource.Id.ivMenuImg );

        objMenuListViewHolderClass.initialize ( view );
        view.Tag = objMenuListViewHolderClass;
      } else {
        objMenuListViewHolderClass = ( MenuListViewHolderClass ) view.Tag;
      }
      objMenuListViewHolderClass.viewClicked = () => {
        if ( actionMenuSelected != null )
        {
          actionMenuSelected ( _mnuText[position] );
        } 
      }; 
      objMenuListViewHolderClass.txtMnuText.Text = _mnuText [position];
      objMenuListViewHolderClass.ivMenuImg.SetImageResource ( _mnuUrl [position] );
      return view;
    }
  }


  internal class MenuListViewHolderClass:Java.Lang.Object { 
    internal Action viewClicked{ get; set;} 
    internal TextView txtMnuText;
    internal ImageView ivMenuImg;


    public void initialize(View view) {
      view.Click += delegate {
        viewClicked();
      };
    }

  }

  public class ListAdapterClass : BaseAdapter<string> {
    Activity _context; 
    string[] _mnuText;
    View.IOnTouchListener iGesture;
    internal event Action<string> actionMenuSelected;

    public ListAdapterClass(Activity context,string[] strMnu, View.IOnTouchListener gesture)
    { 
      _context = context; 
      _mnuText = strMnu;
      iGesture = gesture;
    } 
    public override string this[int position]
    {
      get { return this._mnuText[position]; }
    }

    public override int Count
    {
      get { return this._mnuText.Count(); }
    }


    public override long GetItemId(int position)
    {
      return position;
    }
      

    public override View GetView(int position, View convertView, ViewGroup parent) {    
      ListViewHolderClass objMenuListViewHolderClass;
      View view;
      view = convertView;
      if ( view == null ) {
        view= _context.LayoutInflater.Inflate ( Resource.Layout.textview , parent , false ); 
        objMenuListViewHolderClass = new ListViewHolderClass (); 

        objMenuListViewHolderClass.txtMnuText = view.FindViewById<TextView> ( Resource.Id.txtHehe );

        objMenuListViewHolderClass.initialize ( view );
        view.Tag = objMenuListViewHolderClass;
      } else {
        objMenuListViewHolderClass = ( ListViewHolderClass ) view.Tag;
      }
      objMenuListViewHolderClass.viewClicked = () => {
        if ( actionMenuSelected != null )
        {
          actionMenuSelected ( _mnuText[position] );
        } 
      }; 
      objMenuListViewHolderClass.txtMnuText.Text = _mnuText [position];
      view.Touch += (object sender, View.TouchEventArgs e) => {
        
      };
      if (iGesture != null) {
        view.SetOnTouchListener(iGesture);
      } // if
      return view;
    }
  }


  public class ListViewHolderClass:Java.Lang.Object { 
    internal Action viewClicked{ get; set;} 
    internal TextView txtMnuText;


    public void initialize(View view) {
      view.Click += delegate {
        viewClicked();
      };
    }

  }

}